namespace _3PA.Data.Sql.Core.Interfaces
{
  public interface IPublicRecordsRepository
  {
    public IEnumerable<object> ReadVoters(string[] list);
    public IEnumerable<object> ReadHistories(string[] list);
    public Task<int> CommitRecords<T>(IEnumerable<object> publicRecords) where T : class;

  }
}
