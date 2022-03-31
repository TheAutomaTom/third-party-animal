using _3PA.Core.Models;

namespace _3PA.API.Services.PublicRecords.Voters.Queries.ByName
{
	public class GetVotersByNameResponse
	{
		public GetVotersByNameResponse(IEnumerable<PublicRecordBase> voters)
		{
			Voters = voters;
		}
		public IEnumerable<PublicRecordBase> Voters { get; set; }
	}
}
