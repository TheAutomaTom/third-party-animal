using _3PA.API.Services.PublicRecords.ManifestSummary.Dtos;
using _3PA.API.Services.PublicRecords.ManifestSummary.Queries.GetManifestSummary;
using _3PA.Core.Models;
using _3PA.Data.Sql.Core.Interfaces;
using _3PA.Data.Sql.Fl;
using _3PA.Data.Sql.Nc;
using MediatR;

namespace _3PA.API.Services.Users.ManifestSummary.Queries.GetManifestSummary
{
	public class GetManifestSummaryHandler : IRequestHandler<GetManifestSummaryQuery, GetManifestSummaryResponse>
  {
    IPublicRecordsRepository repo { get; set; }

    public Task<GetManifestSummaryResponse> Handle(GetManifestSummaryQuery request, CancellationToken cancellationToken)
    {
      var summary = new List<ManifestSummaryByUsStateDto>();
      //Enumerate states enum
      foreach (UsState usState in (UsState[])Enum.GetValues(typeof(UsState)))
      {
        switch (usState)
        {          
          case UsState.Fl:            
            using (repo = new FlRepository())
            {
              summary.Add( new ManifestSummaryByUsStateDto(UsState.Fl, repo.GetManifestSummary() ));
            }
          break;

          case UsState.Nc:
            using (repo = new NcRepository())
            {
              summary.Add(new ManifestSummaryByUsStateDto(UsState.Nc, repo.GetManifestSummary()));
            }
            break;

          default:
            throw new NotImplementedException($"UsState {usState} has no Manifest table implemented.");
        }
      }
      var response = new GetManifestSummaryResponse(summary);
      return Task.FromResult(response);

    }
  }
}
