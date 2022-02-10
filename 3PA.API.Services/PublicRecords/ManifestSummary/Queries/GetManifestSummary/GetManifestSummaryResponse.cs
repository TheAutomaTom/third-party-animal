using _3PA.API.Services.PublicRecords.ManifestSummary.Dtos;
using _3PA.Data.Sql.Core;

namespace _3PA.API.Services.PublicRecords.ManifestSummary.Queries.GetManifestSummary
{
	public class GetManifestSummaryResponse
	{
		public GetManifestSummaryResponse(List<ManifestSummaryByUsStateDto> manifestSummary )
		{
			ManifestSummaries = manifestSummary;
		}
		public List<ManifestSummaryByUsStateDto> ManifestSummaries { get; set; }
	}
}
