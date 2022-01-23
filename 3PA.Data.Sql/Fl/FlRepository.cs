using _3PA.Core.Models;
using _3PA.Core.Models.Fl;
using _3PA.Data.Sql.Core;
using _3PA.Data.Sql.Core.Interfaces;
using System.Data;

namespace _3PA.Data.Sql.Fl
{
  public class FlRepository : IPublicRecordsRepository
  {
    FlDbContext _context { get; set; }
    IGeoData _geoData { get; set; }
    public FlRepository()
    {
      _context = new FlDbContext();
      _context.Database.EnsureCreated();
      _geoData = new FlGeoData();
    }

    public IEnumerable<object> ReadVoters(string[] list) => list.Select(v => new FlVoter(v)).ToList();
    public IEnumerable<object> ReadHistories(string[] list) => list.Select(v => new FlHistory(v)).ToList();

    public async Task<int> CommitRecords<T>(IEnumerable<object> publicRecords) where T : class
    {
      var tally = new tallyHelper(publicRecords.Count());
      Console.WriteLine($"Processing {tally.Goal.ToString("N0")} records...");
      Console.WriteLine("{0,-15}{1,-15}{2,-20}{3,20}", "UPDATED", "PROCESSED", "DURATION", "PROJECTION");

      foreach (var x in publicRecords)
      {
        if (typeof(T).Name == nameof(FlVoter))
        {
          var existingId = _context.Voters.FirstOrDefault(exists => exists.VoterId == (x as FlVoter).VoterId);
          if (existingId == null)
          {
            await _context.Voters.AddAsync(x as FlVoter);
            tally.Updates++;
          }
        }
        else
        {
          //Check if this history is new...
          var existingId = _context.Histories.FirstOrDefault(exists => exists.Id == (x as FlHistory).Id) != null;
          if (!existingId)
          {
            //Check if this history is an orphan...
            var existingVoter = _context.Voters.FirstOrDefault(exists => exists.VoterId == (x as FlHistory).VoterId);
            if(existingVoter != null)
            {
                var h = new FlHistoryActive(existingVoter, (x as FlHistory));
                await _context.Histories.AddAsync(h);              
            }
            else
            {
                var h = new FlHistoryOrphan(x as FlHistory);
                await _context.OrphanHistories.AddAsync(h);
            }
            tally.Updates++;
          }
        }
        tally.Progress++;
        if ((tally.Updates > 0) && (tally.Updates % 10000 == 0))
        {
          updateIncrementally(
            tally.Progress,
            tally.Goal,
            tally.UpdateTime.Elapsed.TotalSeconds,
            tally.TotalTime.Elapsed.TotalSeconds
           );
          tally.UpdateTime.Restart();
        }
      }
      Console.WriteLine("FINALIZING UPDATES...");
      updateIncrementally(
        tally.Progress,
        tally.Goal,
        tally.UpdateTime.Elapsed.TotalSeconds,
        tally.TotalTime.Elapsed.TotalSeconds
       );
      return tally.Updates;
    }

    void updateIncrementally(int progress, int goal, double updateTime, double totalTime)
    {

      var currentUpdates = _context.SaveChanges();
      var timePer = updateTime / 10_000;
      var timeLeft = (timePer * (goal - progress));
      var estTimeCompleted = (DateTime.Now.AddSeconds(timeLeft)).ToString("t");

      Console.WriteLine("{0,-15}{1,-15}{2,-20}{3,20}",
          currentUpdates,
          progress.ToString("N0"),
          $"{Math.Round(totalTime, 2)}\t({Math.Round(updateTime, 2)}/10k)",
          estTimeCompleted
        );
    }

  }
}





/*    public void PrintSummary(DbContextBase context)
    {
      Console.ResetColor();
      Console.WriteLine($"DATABASE SUMMARY:");





      var dCount = context.Details.FromSqlRaw("SELECT COUNT(*) FROM dbo.Details");
      var hCount = context.Histories.FromSqlRaw("SELECT COUNT(*) FROM dbo.Histories");


      Console.WriteLine($"{dCount} Voters with {hCount} histories.");


    }*/
