using _3PA.Core.Models;
using _3PA.Core.Models.Nc;
using _3PA.Data.Sql.Core;
using _3PA.Data.Sql.Core.Interfaces;

namespace _3PA.Data.Sql.Nc
{
  public class NcRepository : IPublicRecordsRepository
  {
    NcDbContext _context { get; set; }
    IGeoData _geoData { get; set; }
    public NcRepository()
    {
      _context = new NcDbContext();
      _context.Database.EnsureCreated();
      _geoData = new NcGeoData();
    }

    public IEnumerable<object> ReadVoters(string[] raw)
    {
      var list = sanitizeInput(raw, 1 /*71*/ );
      var toReturn = list.Select(v => new NcVoter(v)).ToList();
      return toReturn;

    }
      
    public IEnumerable<object> ReadHistories(string[] list) =>
      sanitizeInput(list, 15).Select(v => new NcHistory(v)).ToList();
    string[] sanitizeInput(string[] listWithHeaders, int headerCount)
    {
      var withoutHeaders = listWithHeaders.Skip(headerCount).ToArray();
      var withoutQuotes = withoutHeaders.Select(s => s.Replace("\"","")).ToArray();
      return withoutQuotes;
    }      

    public async Task<int> CommitRecords<T>(IEnumerable<object> publicRecords) where T : class
    {
      var tally = new tallyHelper(publicRecords.Count());
      Console.WriteLine($"Processing {tally.Goal.ToString("N0")} records...");
      Console.WriteLine("{0,-15}{1,-20}{2,20}", "COUNT", "DURATION", "PROJECTION");

      foreach (var x in publicRecords)
      {
        if (typeof(T).Name == nameof(NcVoter))
        {
          var existingId = _context.Voters.FirstOrDefault(exists => exists.VoterRegNum == (x as NcVoter).VoterRegNum);
          if (existingId == null)
          {
            await _context.Voters.AddAsync(x as NcVoter);
            tally.Updates++;
          }
        }
        else
        {
          var existingId = _context.Histories.FirstOrDefault(exists => exists.Id == (x as NcHistory).Id);
          if (existingId == null)
          {
            await _context.Histories.AddAsync(x as NcHistory);
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
}