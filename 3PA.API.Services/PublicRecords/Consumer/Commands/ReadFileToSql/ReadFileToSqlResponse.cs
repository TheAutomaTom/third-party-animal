namespace _3PA.API.Services.PublicRecords.Consumer.Commands
{
  public class ReadFileToSqlResponse
  {
    public ReadFileToSqlResponse(int count)
    {
      CountUpserted = count;

    }

    public int CountUpserted { get; set; }


  }
}
