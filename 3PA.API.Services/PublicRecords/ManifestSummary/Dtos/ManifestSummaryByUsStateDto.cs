using _3PA.Core.Models;
using _3PA.Data.Sql.Core;

namespace _3PA.API.Services.PublicRecords.ManifestSummary.Dtos
{
	public class ManifestSummaryByUsStateDto
	{
		public ManifestSummaryByUsStateDto(UsState usState, List<Data.Sql.Core.Manifest> manifests)
		{
			UsState = usState.ToString();
			Manifests = manifests;
		}
		public string UsState { get; set; }
		public List<Data.Sql.Core.Manifest> Manifests { get; set; }

	}
}
