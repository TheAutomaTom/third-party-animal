using _3PA.Core.Models;
using _3PA.Core.Models.Fl;
using _3PA.Core.Models.Nc;
using _3PA.Data.Sql.Core.Interfaces;
using _3PA.Data.Sql.Fl;
using _3PA.Data.Sql.Nc;
using MediatR;

namespace _3PA.API.Services.PublicRecords.Consumer.Commands
{
  public class ReadFileToSqlHandler : IRequestHandler<ReadFileToSqlRequest, ReadFileToSqlResponse>
  {
    IPublicRecordsRepository repo { get; set; }

    public async Task<ReadFileToSqlResponse> Handle(ReadFileToSqlRequest request, CancellationToken cancellationToken)
    {
      var rawText = File.ReadAllLinesAsync(request.TempPath).Result;
      var updated = 0;

      switch (request.State.ToString())
      {
        case "FL":
          repo = new FlRepository();
          if (request.Category == Category.Voter)
          {
            var list = repo.ReadVoters(rawText);
            updated = repo.CommitRecords<FlVoter>(list).Result;
          } 
          else
          {
            var list = repo.ReadHistories(rawText);
            updated = repo.CommitRecords<FlHistoryActive>(list).Result;
          }          
          break;
        case "NC":
          repo = new NcRepository();
          if (request.Category == Category.Voter)
          {
            var list = repo.ReadVoters(rawText);
            updated = repo.CommitRecords<NcVoter>(list).Result;
          }
          else
          {
            var list = repo.ReadHistories(rawText);
            updated = repo.CommitRecords<NcHistory>(list).Result;
          }
          break;
        default:
          break;
      }

      return new ReadFileToSqlResponse(updated) ;
    }

  }
}
