using _3PA.Core.Models;
using _3PA.Core.Models.Fl;
using _3PA.Data.Sql.Core;
using _3PA.Data.Sql.Core.Bases;
using _3PA.Data.Sql.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace _3PA.Data.Sql.Fl
{
  public class FlRepository : PublicRecordsRepositoryBase, IPublicRecordsRepository
  {
    FlDbContext _context { get; set; }
    public FlRepository()
    {
      _context = new FlDbContext();
      _context.Database.EnsureCreated();
    }

    public IEnumerable<PublicRecordBase> ReadVoterRecords(string[] list) => list.Select(v => new FlVoter(v)).ToList();
    public IEnumerable<PublicRecordBase> ReadHistoryRecords(string[] list) => list.Select(v => new FlHistoryBase(v)).ToList();
    public IList<Manifest> GetManifestSummary() => getManifestSummary(_context);

    public async Task<Manifest> CommitVoterRecords(string fileName, IEnumerable<PublicRecordBase> publicRecords)
    {
      if (fileName == "" || !publicRecords.Any()) return new Manifest(fileName, 0, 0);

      printTitle();
      var currentSaves = 0;
      var t = new Tally(publicRecords.Count());
      printHeaders(t.Goal);
      printUpdate(currentSaves, t);

      foreach (var voter in publicRecords)
      {
        var existingId = _context.Voters.FirstOrDefault(exists => exists.Id == (voter as FlVoter).Id);
        if (existingId == null)
        {

          _context.Voters.Add(voter as FlVoter);
          t.Validated++;

        }
        else
        {
          t.Skipped++;
        }
        var updates = t.Validated + t.Skipped;
        if ((updates > 0) && (updates % 10000 == 0))
        {
          currentSaves = _context.SaveChanges();
          printUpdate(currentSaves, t);
          t.UpdateTime.Restart();
        }
      }

      currentSaves = _context.SaveChanges();
      printUpdate(currentSaves, t);

      Console.Write("FINALIZING UPDATES...");
      var results = new Manifest(fileName, t.Validated, t.Orphaned);
      clearManifest(fileName);
      await _context.Manifests.AddAsync(results);

      currentSaves = _context.SaveChanges();
      Console.WriteLine($"{fileName}'s {t.Goal:N0} voters have been processed!\n");

      return results;
    }

    public async Task<Manifest> CommitHistoryRecords(string fileName, IEnumerable<PublicRecordBase> publicRecords)
    {
      if (fileName == "" || !publicRecords.Any()) return new Manifest(fileName, 0, 0);

      printTitle();
      var currentSaves = 0;
      var t = new Tally(publicRecords.Count());
      printHeaders(t.Goal);
      printUpdate(currentSaves, t);

      foreach (var history in publicRecords)
      {
        //Check if this historyBase is new...
        try
        {
          //Check if this history's voter is recorded...
          var existingVoter = _context.Voters.FirstOrDefault(exists => exists.Id == (history as FlHistoryBase).VoterId);
          if (existingVoter != null)
          {
            //...then check if this is already recorded...
            var existingHistory = _context.Histories.FirstOrDefault(exists => exists.Id == (history as FlHistoryBase).Id) != null;
            if (!existingHistory)
            {
              var h = new FlHistoryActive(existingVoter, history as FlHistoryBase);
              await _context.Histories.AddAsync(h);
              t.Validated++;
            }
          }
          else
          {
            // ...this is an orphan history, so check if it already has been recorded...
            var existingOrphan = _context.Orphans.FirstOrDefault(exists => exists.Id == (history as FlHistoryBase).Id);
            if (existingOrphan == null)
            {
              var h = new FlHistoryOrphan(history as FlHistoryBase);
              await _context.Orphans.AddAsync(h);
              t.Orphaned++;
            }
            else
            {
              t.Skipped++;
            }
          }
        }
        catch (Exception ex)
        {
          throw ex;
        }

        var updates = t.Validated + t.Orphaned + t.Skipped;
        if ((updates > 0) && (updates % 10000 == 0))
        {
          currentSaves = _context.SaveChanges();
          printUpdate( currentSaves, t );
          t.UpdateTime.Restart();
        }

      }
 
      currentSaves = _context.SaveChanges();
      printUpdate( currentSaves, t );

      Console.Write("FINALIZING UPDATES...");
      var results = new Manifest(fileName, t.Validated, t.Orphaned);
      clearManifest(fileName);
      await _context.Manifests.AddAsync(results);

      currentSaves = _context.SaveChanges();
      Console.WriteLine($"{fileName}'s {t.Goal:N0} histories have been processed!\n");

      return results;
    }

    public IEnumerable<PublicRecordBase> GetVoters(string countyId, string surname)
		{
      var voters = _context.Voters
        .Where(voter => voter.NameLast== surname)
        .Include(v => v.Histories)
        .ToList();
      return voters;
		}


    void clearManifest(string fileName)
    {
      var manifestExists = _context.Manifests.FirstOrDefault(exists => exists.FileName == fileName);
      if (manifestExists != null)
      {
        _context.Entry(manifestExists).State = EntityState.Deleted;
      }
    }


  }
}


