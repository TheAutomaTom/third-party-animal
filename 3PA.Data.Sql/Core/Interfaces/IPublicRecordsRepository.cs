using _3PA.Core.Models;

namespace _3PA.Data.Sql.Core.Interfaces
{
  public interface IPublicRecordsRepository : IDisposable
  {
    public List<Manifest> GetManifestSummary();
    public IEnumerable<PublicRecordBase> ReadVoters(string[] list);
    public IEnumerable<PublicRecordBase> ReadHistories(string[] list);
    public Task<Manifest> CommitRecords<T>(string FileName, IEnumerable<PublicRecordBase> publicRecords) where T : class;
  }
}
