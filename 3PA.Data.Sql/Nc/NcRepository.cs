using _3PA.Core.Models;
using _3PA.Core.Models.Nc;
using _3PA.Data.Sql.Core;
using _3PA.Data.Sql.Core.Bases;
using _3PA.Data.Sql.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace _3PA.Data.Sql.Nc
{
  public class NcRepository : PublicRecordsRepositoryBase, IPublicRecordsRepository
  {
    NcDbContext _context { get; set; }
    public NcRepository()
    {
      _context = new NcDbContext();
      _context.Database.EnsureCreated();
    }

    public IList<Manifest> GetManifestSummary() => getManifestSummary(_context);

    public IEnumerable<PublicRecordBase> ReadVoterRecords(string[] raw)
    {
      var list = sanitizeInput(raw, 1 /*71*/ );
      return list.Select(v => new NcVoter(v)).ToList();
    }
      
    public IEnumerable<PublicRecordBase> ReadHistoryRecords(string[] list) =>
      sanitizeInput(list, 15).Select(v => new NcHistoryBase(v)).ToList();

    string[] sanitizeInput(string[] listWithHeaders, int headerCount)
    {
      var withoutHeaders = listWithHeaders.Skip(headerCount).ToArray();
      var withoutQuotes = withoutHeaders.Select(s => s.Replace("\"","")).ToArray();
      return withoutQuotes;
    }

    public async Task<Manifest> CommitVoterRecords(string fileName, IEnumerable<PublicRecordBase> publicRecords) 
    {
      if (fileName == "" || !publicRecords.Any()) return new Manifest(fileName, 0, 0);

      printTitle();
      var currentSaves = 0;
      var t = new Tally(publicRecords.Count());
      printHeaders(t.Goal);

      foreach (var voter in publicRecords)
      {
        var existingId = _context.Voters.FirstOrDefault(exists => exists.Id == (voter as NcVoter).Id);
        if (existingId == null)
        {
          var x = _context.Voters.EntityType;

          _context.Voters.Add(voter as NcVoter);
          t.Validated++;

          var updates = t.Validated + t.Skipped;
          if ((t.Validated > 0) && (t.Validated % 10000 == 0))
          {
            currentSaves = _context.SaveChanges();
            printUpdate(currentSaves, t);
            t.UpdateTime.Restart();
          }
        }
        else
        {
          t.Skipped++;
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

      foreach (var history in publicRecords)
      {
        //Check if this history's voter is recorded...
        var existingVoter = _context.Voters.FirstOrDefault(exists => exists.Id == (history as NcHistoryBase).VoterRegistrationNumber);
        if(existingVoter != null)
				{
          //...then check if this is already recorded...
          var existingHistory = _context.Histories.FirstOrDefault(exists => exists.Id == (history as NcHistoryBase).Id) != null;
          if(!existingHistory)
					{
            var h = new NcHistoryActive(existingVoter, history as NcHistoryBase);
            await _context.Histories.AddAsync(h);
            t.Validated++;            
          }        
        } else {
          // ...this is an orphan history, so check if it already has been recorded...
          var existingOrphan = _context.Orphans.FirstOrDefault(exists => exists.Id == (history as NcHistoryBase).Id);
          if (existingOrphan == null)
          {
            var h = new NcHistoryOrphan(history as NcHistoryBase);
            await _context.Orphans.AddAsync(h);
            t.Orphaned++;
          }
          else
          {
            t.Skipped++;
          }
        }

        var updates = t.Validated + t.Orphaned + t.Skipped;
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
      Console.WriteLine($"{fileName}'s {t.Goal:N0} histories have been processed!\n");

      return results;
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


