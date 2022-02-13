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
    public IList<Manifest> GetManifestSummary()
		{
      // I'd need to move Manifest Table to the DbContextBase to make this one liner work...
      //return base.GetManifestSummary(_context);          
      var summary = new List<Manifest>();
      if (_context.Database.CanConnect() && _context.Manifests.Any())
      {
        foreach (var entry in _context.Manifests)
        {
          summary.Add(entry);      		
        }
      }      
      return summary; 
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
        var existingId = _context.Voters.FirstOrDefault(exists => exists.Id == (voter as FlVoter).Id);
        if (existingId == null)
        {
          var x = _context.Voters.EntityType;

          _context.Voters.Add(voter as FlVoter);
          t.Validated++;

          var updates = t.Validated + t.Orphaned;
          if ((updates > 0) && (updates % 10000 == 0))
          {
            currentSaves = _context.SaveChanges();
            printUpdate( currentSaves, t );
            t.UpdateTime.Restart();
          }
        }
        else
        {
          t.Skipped++;
        }
      }

      updateManifest(fileName);
      currentSaves = _context.SaveChanges();
      printUpdate( currentSaves, t );
      Console.WriteLine("FINALIZING UPDATES...");
      var actualUpdates = t.Validated + t.Orphaned;
      var results = new Manifest(fileName, actualUpdates, t.Goal - actualUpdates);
      await _context.Manifests.AddAsync(results);

      currentSaves = _context.SaveChanges();
      Console.WriteLine($"{fileName} has been processed!\n");

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
        //Check if this historyBase is new...
        try
        {
          var existingHistory =
            _context.Histories.FirstOrDefault(exists => exists.Id == (history as FlHistoryBase).Id) != null;


          if (!existingHistory)
          {
            //Check if this historyBase is not an orphan...
            var existingVoter = _context.Voters
              .FirstOrDefault(exists => exists.Id == (history as FlHistoryBase).Id);
            if (existingVoter != null)
            {
              var h = new FlHistoryActive(existingVoter, history as FlHistoryBase);
              await _context.Histories.AddAsync(h);
              t.Validated++;
            }
            else
            {
              //Check if the orphan is already recorded...
              var existingOrphan =
                _context.Orphans.FirstOrDefault(exists => exists.Id == (history as FlHistoryBase).Id);

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
        }
        catch (Exception ex)
        {
          throw ex;
        }

        var updates = t.Validated + t.Orphaned;
        if ((updates > 0) && (updates % 10000 == 0))
        {
          currentSaves = _context.SaveChanges();
          printUpdate( currentSaves, t );
          t.UpdateTime.Restart();
        }

      }

      updateManifest(fileName);
      currentSaves = _context.SaveChanges();
      printUpdate( currentSaves, t );

      Console.WriteLine("FINALIZING UPDATES...");
      var actualUpdates = t.Validated + t.Orphaned;
      var results = new Manifest(fileName, actualUpdates, t.Goal - actualUpdates);
      await _context.Manifests.AddAsync(results);

      currentSaves = _context.SaveChanges();
      Console.WriteLine($"{fileName} has been processed!\n");

      return results;
    }
    
    void updateManifest(string fileName)
    {
      var manifestExists = _context.Manifests.FirstOrDefault(exists => exists.FileName == fileName);
      if (manifestExists != null)
      {
        _context.Entry(manifestExists).State = EntityState.Deleted;
      }
    }


  }
}


