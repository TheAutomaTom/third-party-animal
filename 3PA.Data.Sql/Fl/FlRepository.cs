using _3PA.Core.Models;
using _3PA.Core.Models.Fl;
using _3PA.Data.Sql.Core;
using _3PA.Data.Sql.Core.Bases;
using _3PA.Data.Sql.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace _3PA.Data.Sql.Fl
{
  public class FlRepository : PublicRecordsRepositoryBase, IPublicRecordsRepository
  {
    FlDbContext _context { get; set; }
    IGeoData _geoData { get; set; }
    public FlRepository()
    {
      _context = new FlDbContext();
      _context.Database.EnsureCreated();
      _geoData = new FlGeoData();
    }


    public IEnumerable<PublicRecordBase> ReadVoters(string[] list) => list.Select(v => new FlVoter(v)).ToList();
    public IEnumerable<PublicRecordBase> ReadHistories(string[] list) => list.Select(v => new FlHistory(v)).ToList();
    public List<Manifest> GetManifestSummary()
		{
      // I'd need to move Manifest Table to the DbContextBase to make this one liner work...
      //return base.GetManifestSummary(_context);          
      var summary = new List<Manifest>();          
      if (_context.Database.CanConnect() && _context.Manifest.Any())      	
      {
        foreach (var entry in _context.Manifest)      	
        {
          summary.Add(entry);      		
        }
      }      
      return summary; 
    }
    public async Task<Manifest> CommitRecords<T>(string fileName, IEnumerable<PublicRecordBase> publicRecords) where T : class
    {
      var updates = 0;
      var saves = 0;
      var t = new Tally(publicRecords.Count());
      base.printTitle(t.Goal);

      foreach (var x in publicRecords)
      {
        if (typeof(T).Name == nameof(FlVoter))
        {
          var existingId = _context.Voters.FirstOrDefault(exists => exists.VoterId == (x as FlVoter).VoterId);
          if (existingId == null)
          {
            await _context.Voters.AddAsync(x as FlVoter);
            t.Validated++;
          }
          else
          {
            t.Skipped++;
          }

        }
        else //(typeof(T).Name == nameof(FlHistory))...
        {
          //Check if this history is new...
          var existingHistory = _context.Histories.FirstOrDefault(exists => exists.Id == (x as FlHistory).Id) != null;
          if (!existingHistory)
          {
            //Check if this history is an orphan...
            var existingVoter = _context.Voters.FirstOrDefault(exists => exists.VoterId == (x as FlHistory).VoterId);
            if(existingVoter != null)
            {
              var h = new FlHistoryActive(existingVoter, (x as FlHistory));
              await _context.Histories.AddAsync(h);
              t.Validated++;
            }
            else
            {
              //Check if the orphan is already recorded...
              var existingOrphan = _context.OrphanHistories.FirstOrDefault(exists => exists.Id == (x as FlHistory).Id);
              if (existingOrphan == null)
              {
                var h = new FlHistoryOrphan(x as FlHistory);
                await _context.OrphanHistories.AddAsync(h);
                t.Orphaned++;
              }
              else
              {
                t.Skipped++;
              }
            }            
          }
        }
        t.Progress++;

        updates = t.Validated + t.Orphaned;
        if ((updates > 0) && (updates % 10000 == 0))
        {
          saves = _context.SaveChanges();
          base.printUpdate(
                saves,
                t.Progress,
                t.Goal,
                t.UpdateTime.Elapsed.TotalSeconds,
                t.TotalTime.Elapsed.TotalSeconds
              );
          t.UpdateTime.Restart();
        }

      }

      updateManifest(fileName);
      saves = _context.SaveChanges();
      
      base.printUpdate(
            saves,
            t.Progress,
            t.Goal,
            t.UpdateTime.Elapsed.TotalSeconds,
            t.TotalTime.Elapsed.TotalSeconds
          );

      Console.WriteLine("FINALIZING UPDATES...");
      updates = t.Validated + t.Orphaned;
      var results = new Manifest(fileName, updates, t.Goal - updates, UsState.Fl);
      await _context.Manifest.AddAsync(results);

        saves = _context.SaveChanges();
      
      return results;

    }

    void updateManifest(string fileName)
    {
      var manifestExists = _context.Manifest.FirstOrDefault(exists => exists.FileName == fileName);
      if (manifestExists != null) 
      {
        _context.Entry(manifestExists).State = EntityState.Deleted;
      }
    }

	}
}


