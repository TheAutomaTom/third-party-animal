using _3PA.Core.Models;
using MediatR;

namespace _3PA.API.Services.GeoData.CountyNames.Queries
{
	public class CountyNamesRequest: IRequest<CountyNamesResponse>
	{
		public CountyNamesRequest(SupportedUsStates usState)
		{
			UsState = usState;		
		}
		public SupportedUsStates UsState { get; set; }

	}
}
