using _3PA.Core.Models;
using _3PA.Core.Models.Nc;
using _3PA.Data.Sql.Core;
using _3PA.Data.Sql.Core.Bases;
using _3PA.Data.Sql.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace _3PA.Data.Sql.Nc
{
  public class NcRepository : PublicRecordsRepositoryBase, IPublicRecordsRepository
  {
    NcDbContext _context { get; set; }
    string _includedHeaders { get; set; }
    public NcRepository()
    {
      _context = new NcDbContext();
			_context.Database.EnsureCreated();
      _includedHeaders = "";
    }

		public IList<Manifest> GetManifestSummary() => getManifestSummary(_context);


    public IEnumerable<PublicRecordBase> ReadVoterRecords(string[] raw)
    {
      _includedHeaders = raw.First();
      var list = raw.Skip(1).ToArray();
      var voters = new List<PublicRecordBase>();
      foreach (var v in list)
			{
        var parsed = parseLine("NcVoter", v, _includedHeaders);
        voters.Add(parsed);
      }
      return voters;
    }

    public IEnumerable<PublicRecordBase> ReadHistoryRecords(string[] raw)
    {
      _includedHeaders = raw.First();
      var list = raw.Skip(1).ToArray();
      var histories = new List<PublicRecordBase>();
      foreach (var h in list)
			{
        var parsed = parseLine("NcHistoryBase", h, _includedHeaders);
        histories.Add(parsed);
      }
      return histories;
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
        var existingId = _context.Voters.FirstOrDefault(exists => exists.Id == (voter as NcVoter)!.Id);
        if (existingId == null)
        {
          //_context.Voters.Add((voter as NcVoter)!);

          _context.Voters.Add((voter as NcVoter)!);
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
        var existingVoter = _context.Voters.FirstOrDefault(exists => exists.Id == (history as NcHistoryBase)!.VoterRegistrationNumber);
        if(existingVoter != null)
				{
          //...then check if this is already recorded...
          var existingHistory = _context.Histories.FirstOrDefault(exists => exists.Id == (history as NcHistoryBase)!.Id) != null;
          if(!existingHistory)
					{
            var h = new NcHistoryActive(existingVoter, (history as NcHistoryBase)!);
            await _context.Histories.AddAsync(h);
            t.Validated++;            
          }        
        } else {
          // ...this is an orphan history, so check if it already has been recorded...
          var existingOrphan = _context.Orphans.FirstOrDefault(exists => exists.Id == (history as NcHistoryBase)!.Id);
          if (existingOrphan == null)
          {
            var h = new NcHistoryOrphan((history as NcHistoryBase)!);
            try
            {
              await _context.Orphans.AddAsync(h);
              t.Orphaned++;
            }
            catch(Exception ex)
						{
              Console.WriteLine($"Orphan already tracked( {h.Id} ).");
              Console.WriteLine(ex.Message);
						}
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

    public IEnumerable<PublicRecordBase> GetVoters(string countyId, string surname)
    {
      var voters = _context.Voters
        .Where(voter => voter.LastName == surname)
        .Include(v => v.Histories)
        .ToList();
      return voters;
    }

    PublicRecordBase parseLine(string kind, string valuesRaw, string headersRaw)
    {
      string[] values = parseText(valuesRaw);
      string[] headers = parseText(headersRaw);
      XElement voterXml = new XElement(kind);
      for (int i = 0; i < headers.Length; i++)
      {
        if (values[i] != String.Empty)
        {
          voterXml.Add(new XElement(headers[i], values[i]));
        }
      }

      using (var stream = streamFromXElement(voterXml))
      {
        if (kind == "NcVoter")
        {
          var xs = new XmlSerializer(typeof(NcVoter));
          var v = (NcVoter)xs.Deserialize(stream);
          v!.Id = v.VoterRegNum!;
          return v;
        }
        else
        {
          var xs = new XmlSerializer(typeof(NcHistoryBase));
          var h = (NcHistoryBase)xs.Deserialize(stream);
          h!.Id = $"{h.VoterRegistrationNumber}{h.PctLabel}{h.ElectionLable}{h.VotingMethod}";
          return h;
        }
      }

    }

		#region Support Methods...
		string[] parseText(string row)
    {
      string[] values = row.Split('\t');
      for (int i = 0; i < values.Length; i++)
      {
        values[i] = values[i].Replace("\"", "");
        values[i] = values[i].Replace("\\", "");
      }
      return values;
    }

    Stream streamFromXElement(XElement xml)
    {
      var m = new MemoryStream();
      var w = new StreamWriter(m);
      w.Write(xml);
      w.Flush();
      m.Position = 0;
      return m;
    }

    void clearManifest(string fileName)
    {
      var manifestExists = _context.Manifests.FirstOrDefault(exists => exists.FileName == fileName);
      if (manifestExists != null)
      {
        _context.Entry(manifestExists).State = EntityState.Deleted;
      }
    }
    #endregion ...support methods

  }
}


