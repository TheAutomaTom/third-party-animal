using _3PA.API.Services.PublicRecords.ManifestSummary.Dtos;
using _3PA.Data.Sql.Core;

namespace _3PA.API.Services.PublicRecords.ManifestSummary.Queries.GetManifestSummary
{
	public class GetManifestSummaryResponse
	{
		public GetManifestSummaryResponse(List<ManifestSummaryDto> manifestSummary )
		{
			ManifestSummary = manifestSummary;
		}
		public List<ManifestSummaryDto> ManifestSummary { get; set; }
	}
}
