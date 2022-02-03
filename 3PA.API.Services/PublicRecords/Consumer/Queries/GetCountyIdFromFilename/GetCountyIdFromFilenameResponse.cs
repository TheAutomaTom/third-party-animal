using _3PA.Core.Models;
namespace _3PA.API.Services.PublicRecords.Consumer.Queries.GetCountyIdFromFilename
{
	public class GetCountyIdFromFilenameResponse
	{
		public GetCountyIdFromFilenameResponse(GetCountyIdFromFilenameQuery query, string countyId)
		{
			UsState = query.UsState.ToString();
			FileName = query.FileName;
			CountyId = countyId;
		}
		public string UsState { get; set; }
		public string FileName { get; set; }
		public string CountyId { get; set; }


	}
}
