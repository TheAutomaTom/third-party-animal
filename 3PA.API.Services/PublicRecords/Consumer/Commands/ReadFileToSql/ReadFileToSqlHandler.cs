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
        case SupportedUsStates.Fl:
          repo = new FlRepository();
          if (request.Category == Category.Voter)
          {
            var list = repo.ReadVoters(rawText);
            var updated = await repo.CommitRecords<FlVoter>(request.FileName, list);
            return new ReadFileToSqlResponse(updated);
          } 
          else
          {
            var list = repo.ReadHistories(rawText);
            var updated = await repo.CommitRecords<FlHistoryActive>(request.FileName, list);
            return new ReadFileToSqlResponse(updated);
          }

        case SupportedUsStates.Nc:
          repo = new NcRepository();
          if (request.Category == Category.Voter)
          {
            var list = repo.ReadVoters(rawText);
            var updated = await repo.CommitRecords<NcVoter>(request.FileName, list);
            return new ReadFileToSqlResponse(updated);
          }
          else
          {
            var list = repo.ReadHistories(rawText);
            var updated = await repo.CommitRecords<NcHistory>(request.FileName, list);
            return new ReadFileToSqlResponse(updated);
          }

        default:
          return new ReadFileToSqlResponse(new Manifest($"Unable to parse {request.FileName}" , 0, 0));
      }

    }

  }
}
