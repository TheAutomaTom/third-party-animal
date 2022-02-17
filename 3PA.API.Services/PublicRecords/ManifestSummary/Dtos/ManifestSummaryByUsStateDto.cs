using _3PA.Core.Models;
using _3PA.Data.Sql.Core;

namespace _3PA.API.Services.PublicRecords.ManifestSummary.Dtos
{
	public class ManifestSummaryByUsStateDto
	{
		public ManifestSummaryByUsStateDto(UsState usState, IList<Manifest> manifests)
		{
			UsState = usState.ToString();
			Manifests = manifests;
		}
		public string UsState { get; set; }
		public IList<Manifest> Manifests { get; set; }

	}
}
