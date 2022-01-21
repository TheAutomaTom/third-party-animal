
using _3PA.Core.Models;
using _3PA.Core.Models.Fl;
using _3PA.Data.Sql.Fl;
using MediatR;

namespace _3PA.API.Services.PublicRecords.Consumer.Commands
{
  public class ReadFileToSqlHandler : IRequestHandler<ReadFileToSqlRequest, ReadFileToSqlResponse>
  {
    //IPublicRecordsConsumerRepository repo { get; set; }
    FlRepository repo { get; set; }

    public async Task<ReadFileToSqlResponse> Handle(ReadFileToSqlRequest request, CancellationToken cancellationToken)
    {
      var rawText = File.ReadAllLinesAsync(request.TempPath).Result;
      var updated = 0;

      switch (request.State.ToString())
      {
        case "FL":
          repo = new FlRepository();

          if (request.Kind == Kind.Voter)
          {
            var list = repo.ReadAsVoters(rawText);
            updated = repo.CommitRecords<FlVoter>(list).Result;
          } 
          else
          {
            var list = repo.ReadAsHistories(rawText);
            updated = repo.CommitRecords<FlHistory>(list).Result;
          }
          
          break;
        case "NC":
          //var repo = new NcRepository();
          break;
        default:
          break;
      }

      return new ReadFileToSqlResponse(updated) ;
    }

  }
}
