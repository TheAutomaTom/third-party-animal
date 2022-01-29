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
    IGeoData _geoData { get; set; }
    public NcRepository()
    {
      _context = new NcDbContext();
      _context.Database.EnsureCreated();
      _geoData = new NcGeoData();
    }

    public IEnumerable<PublicRecordBase> ReadVoters(string[] raw)
    {
      var list = sanitizeInput(raw, 1 /*71*/ );
      var toReturn = list.Select(v => new NcVoter(v)).ToList();
      return toReturn;

    }
      
    public IEnumerable<PublicRecordBase> ReadHistories(string[] list) =>
      sanitizeInput(list, 15).Select(v => new NcHistory(v)).ToList();
    string[] sanitizeInput(string[] listWithHeaders, int headerCount)
    {
      var withoutHeaders = listWithHeaders.Skip(headerCount).ToArray();
      var withoutQuotes = withoutHeaders.Select(s => s.Replace("\"","")).ToArray();
      return withoutQuotes;
    }      

    public async Task<Manifest> CommitRecords<T>(string fileName, IEnumerable<PublicRecordBase> publicRecords) where T : class
    {
      var updates = 0;
      var saves = 0;
      var t = new Tally(publicRecords.Count());
      base.printTitle(t.Goal);

      foreach (var x in publicRecords)
      {
        if (typeof(T).Name == nameof(NcVoter))
        {
          var existingId = _context.Voters.FirstOrDefault(exists => exists.VoterRegNum == (x as NcVoter).VoterRegNum);
          if (existingId == null)
          {
            await _context.Voters.AddAsync(x as NcVoter);
            t.Validated++;
          }
          else
          {
            t.Skipped++;
          }        

        }
        else //History...
        {
          //Check if this history is new...
          var existingHistory = _context.Histories.FirstOrDefault(exists => exists.Id == (x as NcHistory).Id) != null;
          if (!existingHistory)
          {
            //Check if this history is an orphan...
            var existingVoter = _context.Voters.FirstOrDefault(exists => exists.VoterRegNum == (x as NcHistory).VoterRegistrationNumber);
            if(existingVoter != null)
            {
              var h = new NcHistoryActive(existingVoter, (x as NcHistory));
              await _context.Histories.AddAsync(h);
              t.Validated++;
            }
            else
            {
              //Check if the orphan is already recorded...
              var existingOrphan = _context.OrphanHistories.FirstOrDefault(exists => exists.Id == (x as NcHistory).Id);
              if (existingOrphan == null)
              {
                var h = new NcHistoryOrphan(x as NcHistory);
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
      var results = new Manifest(fileName, updates, t.Goal - updates);
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