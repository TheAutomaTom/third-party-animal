using _3PA.Core.Models;
using _3PA.Core.Models.Fl;
using _3PA.Core.Models.Nc;
using _3PA.Data.Sql.Core;
using _3PA.Data.Sql.Core.Interfaces;
using _3PA.Data.Sql.Fl;
using _3PA.Data.Sql.Nc;
using FluentValidation;
using MediatR;

namespace _3PA.API.Services.PublicRecords.Consumer.Commands
{
  public class ReadFileToSqlHandler : IRequestHandler<ReadFileToSqlCommand, ReadFileToSqlResponse>
  {
    IPublicRecordsRepository repo { get; set; }

    public async Task<ReadFileToSqlResponse> Handle(ReadFileToSqlCommand request, CancellationToken cancellationToken)
    {
      var v = new ReadFileToSqlValidator();
      var validationResult = v.Validate(request);
      if (!validationResult.IsValid)
      {
        throw new ValidationException(validationResult.Errors);
      }

      var rawText = File.ReadAllLinesAsync(request.TempPath).Result;

      switch (request.State)
      {
        case UsState.Fl:
          repo = new FlRepository();
          if (request.Category == Category.Voter)
          {
            var list = repo.ReadVoterRecords(rawText);
            var updated = await repo.CommitVoterRecords(request.FileName, list);
            return new ReadFileToSqlResponse(updated);
          } 
          else
          {
            var list = repo.ReadHistoryRecords(rawText);
            var updated = await repo.CommitHistoryRecords(request.FileName, list);
            return new ReadFileToSqlResponse(updated);
          }

        case UsState.Nc:
          repo = new NcRepository();
          if (request.Category == Category.Voter)
          {
            var list = repo.ReadVoterRecords(rawText);
            var updated = await repo.CommitVoterRecords(request.FileName, list);
            return new ReadFileToSqlResponse(updated);
          }
          else
          {
            var list = repo.ReadHistoryRecords(rawText);
            var updated = await repo.CommitHistoryRecords(request.FileName, list);
            return new ReadFileToSqlResponse(updated);
          }

        default:
          throw new ValidationException($"Could not determine process for {request.State}: {request.Category}.");
      }

    }

  }
}
