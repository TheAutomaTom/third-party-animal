using _3PA.Data.Sql.Core;

namespace _3PA.API.Services.PublicRecords.Consumer.Commands
{
  public class ReadFileToSqlResponse
  {
    public ReadFileToSqlResponse(Data.Sql.Core.Manifest manifest)
    {
      Results = manifest;

    }

    public Data.Sql.Core.Manifest Results { get; set; }


  }
}
