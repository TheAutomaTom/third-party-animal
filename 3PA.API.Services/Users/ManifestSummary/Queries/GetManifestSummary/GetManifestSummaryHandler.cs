using System.Threading;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3PA.API.Services.Users.ManifestSummary.Queries.GetManifestSummary
{
	public class GetManifestSummaryHandler : IRequestHandler<GetManifestSummaryQuery, GetManifestSummaryResponse>
	{
		public GetManifestSummaryHandler()
		{
		}

		public async Task<GetManifestSummaryResponse> Handle(GetManifestSummaryQuery request, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
}
