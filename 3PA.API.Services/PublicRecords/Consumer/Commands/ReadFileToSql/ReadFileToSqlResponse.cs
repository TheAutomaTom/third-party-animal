using _3PA.Data.Sql.Core;

namespace _3PA.API.Services.PublicRecords.Consumer.Commands
{
  public class ReadFileToSqlResponse
  {
    public ReadFileToSqlResponse(Manifest manifest)
    {
      Results = manifest;

    }

    public Manifest Results { get; set; }


  }
}
