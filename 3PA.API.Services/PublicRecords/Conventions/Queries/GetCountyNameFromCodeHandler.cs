using _3PA.Core.Models;
using _3PA.Core.Models.Fl;
using MediatR;

namespace _3PA.API.Services.PublicRecords.Conventions.Queries
{
  public class GetCountyNameFromCodeHandler : IRequestHandler<GetCountyNameFromCodeQuery, GetCountyNameFromCodeResponse>
  {
    IGeoData _geoData { get; set; }
    public async Task<GetCountyNameFromCodeResponse> Handle(GetCountyNameFromCodeQuery request, CancellationToken cancellationToken)
    {
      switch (request.State)
      {
/*
        case SupportedUsStates.NC:
          _geoData = new MetaNcGeoData();
          break;
*/
        default: //FL
          _geoData = new FlGeoData();
          request.CountyCode = request.CountyCode.ToUpper();
          break;
      }

      var canParse = _geoData.CountyIds.TryGetValue(request.CountyCode, out var properName);

      if (canParse)
      {
        return new GetCountyNameFromCodeResponse(request, properName);
      }
      return new GetCountyNameFromCodeResponse(request);
    }
  }
}
