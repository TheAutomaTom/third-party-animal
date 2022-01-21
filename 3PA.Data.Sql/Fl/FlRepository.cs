using _3PA.Core.Models;
using _3PA.Core.Models.Fl;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Diagnostics;

namespace _3PA.Data.Sql.Fl
{
  public class FlRepository //: IPublicRecordsConsumerRepository
  {
    FlDbContext _context { get; set; }
    IGeoData _geoData { get; set; }
    public FlRepository()
    {
      _context = new FlDbContext();
      _context.Database.EnsureCreated();
      _geoData = new MetaFlGeoData();
    }

    public IEnumerable<FlVoter> ReadAsVoters(string[] list) => list.Select(v => new FlVoter(v)).ToList();
    public IEnumerable<FlHistory> ReadAsHistories(string[] list) => list.Select(v => new FlHistory(v)).ToList();

    public async Task<int> CommitRecords<T>(IEnumerable<object> publicRecords) where T : class
    {
      var tally = new tallyHelper(publicRecords.Count());
      Console.WriteLine($"Processing {tally.Goal.ToString("N0")} records...");
      Console.WriteLine("{0,-15}{1,-20}{2,20}", "COUNT", "DURATION", "PROJECTION");

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
          var existingId = _context.Histories.FirstOrDefault(exists => exists.Id == (x as FlHistory).Id);
          if (existingId == null)
          {
            await _context.Histories.AddAsync(x as FlHistory);
            tally.Updates++;
          }
        }
        tally.Progress++;
        if ( (tally.Updates > 0) && (tally.Updates % 10000 == 0) )
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
      /*
            Console.WriteLine("DATABASE SUMMARY:");
            var vCount = _context.Voters
                  .Where(o => o.VoterId != null)
                  .SelectMany(o => o.VoterId)
                  .Count();
            var hCount = _context.Histories
                  .Where(o => o.Id != null)
                  .SelectMany(o => o.Id)
                  .Count();
            Console.WriteLine($"{vCount} total voters with {hCount} histories.");
      */
      return tally.Updates;
    }

    void updateIncrementally(int progress, int goal, double updateTime, double totalTime)
    {
      _context.SaveChanges();
      var timePer = updateTime / 10_000;
      var timeLeft = (timePer * (goal - progress));
      var estTimeCompleted = (DateTime.Now.AddSeconds(timeLeft)).ToString("t");

      Console.WriteLine("{0,-15}{1,-20}{2,20}",
          progress.ToString("N0"),
          $"{Math.Round(totalTime, 2)}\t({Math.Round(updateTime, 2)}/10k)",
          estTimeCompleted
        );
    }
  }

  class tallyHelper
  {
    public tallyHelper(int goal, bool start = true)
    {
      Goal = goal;
      TotalTime = new Stopwatch();
      UpdateTime = new Stopwatch();
      if (start)
      {
        TotalTime.Start();
        UpdateTime.Start();
      }
    }
    public int Goal { get; set; }
    public int Progress { get; set; }
    public int Updates { get; set; }
    public Stopwatch TotalTime { get; set; }
    public Stopwatch UpdateTime { get; set; }
    public void EndTimers()
    {
      TotalTime.Stop();  
      UpdateTime.Stop();
      Console.Beep();
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
