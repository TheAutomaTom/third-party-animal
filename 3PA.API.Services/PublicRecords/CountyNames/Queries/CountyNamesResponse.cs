using _3PA.Core.Models;

namespace _3PA.API.Services.PublicRecords.CountyNames.Queries
{
	public class CountyNamesResponse
	{
		public CountyNamesResponse(UsState usState, IDictionary<string, string> countiesDictionary)
		{
			UsState = usState.ToString();
			CountiesDictionary = countiesDictionary;
		}
		public string UsState { get; set; }
		public IDictionary<string, string> CountiesDictionary { get; set; }

	}
}