using _3PA.Core.Models;
using _3PA.Data.Sql.Core;

namespace _3PA.API.Services.PublicRecords.ManifestSummary.Dtos
{
	public class ManifestSummaryDto
	{
		public ManifestSummaryDto(UsState usState, List<Manifest> manifests)
		{
			UsState = usState.ToString();
			Manifests = manifests;
		}
		public string UsState { get; set; }
		public List<Manifest> Manifests { get; set; }

	}
}
