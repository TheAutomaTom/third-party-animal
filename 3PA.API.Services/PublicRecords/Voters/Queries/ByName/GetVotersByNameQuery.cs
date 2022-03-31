using _3PA.Core.Models;
using MediatR;

namespace _3PA.API.Services.PublicRecords.Voters.Queries.ByName
{
	public class GetVotersByNameQuery : IRequest<GetVotersByNameResponse>
	{
		public GetVotersByNameQuery(UsState usState, string countyId, string surname)
		{
			UsState = usState;
			CountyId = countyId;
			Surname = surname;
		}

		public UsState UsState { get; }
		public string CountyId { get; }
		public string Surname { get; }
	}
}
