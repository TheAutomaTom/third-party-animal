using _3PA.Core.Models;
using MediatR;

namespace _3PA.API.Services.Geographic.CountyNames.Queries
{
	public class CountyNamesQuery: IRequest<CountyNamesResponse>
	{
		public CountyNamesQuery(UsState usState)
		{
			UsState = usState;		
		}
		public UsState UsState { get; set; }

	}
}
