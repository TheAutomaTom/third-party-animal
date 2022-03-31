using _3PA.Core.Models;

namespace _3PA.Data.Sql.Core.Interfaces
{
  public interface IPublicRecordsRepository : IDisposable
  {
    public IEnumerable<PublicRecordBase> ReadVoterRecords(string[] list);
    public IEnumerable<PublicRecordBase> ReadHistoryRecords(string[] list);
    
    public Task<Manifest> CommitVoterRecords(string fileName, IEnumerable<PublicRecordBase> publicRecords);
    public Task<Manifest> CommitHistoryRecords(string fileName, IEnumerable<PublicRecordBase> publicRecords);

    public IList<Manifest> GetManifestSummary();
    public IEnumerable<PublicRecordBase> GetVoters(string countyId, string surname);

  }
}
