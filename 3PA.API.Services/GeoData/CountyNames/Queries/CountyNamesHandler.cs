<<<<<<< Updated upstream
﻿using _3PA.Core.Models;
using _3PA.Core.Models.Fl;
using _3PA.Core.Models.Nc;
using MediatR;
namespace _3PA.API.Services.GeoData.CountyNames.Queries
{
	public class CountyNamesHandler : IRequestHandler<CountyNamesQuery, CountyNamesResponse>
  {
    IGeoData geoData { get; set; }
    public Task<CountyNamesResponse> Handle(CountyNamesQuery request, CancellationToken cancellationToken)
		{
      switch (request.UsState)
      {
        case SupportedUsStates.Fl:
          geoData = new FlGeoData();
          break;

        case SupportedUsStates.Nc:
          geoData = new NcGeoData();
          break;

        default: throw new NotImplementedException("UsState not yet implemented");
      }
      var response = new CountyNamesResponse(request.UsState, geoData.CountyIds!);
      return Task.FromResult(response); 

    }


	}
}
=======
﻿using _3PA.Core.Models;
using _3PA.Core.Models.Fl;
using _3PA.Core.Models.Nc;
using MediatR;
namespace _3PA.API.Services.GeoData.CountyNames.Queries
{
	public class CountyNamesHandler : IRequestHandler<CountyNamesRequest, CountyNamesResponse>
  {
    IGeoData geoData { get; set; }
    public Task<CountyNamesResponse> Handle(CountyNamesRequest request, CancellationToken cancellationToken)
		{
      switch (request.UsState)
      {
        case SupportedUsStates.Fl:
          geoData = new FlGeoData();
          break;

        case SupportedUsStates.Nc:
          geoData = new NcGeoData();
          break;

        default: throw new NotImplementedException("UsState not yet implemented");
      }
      var response = new CountyNamesResponse(request.UsState, geoData.CountyIds!);
      return Task.FromResult(response); 

    }


	}
}
>>>>>>> Stashed changes
