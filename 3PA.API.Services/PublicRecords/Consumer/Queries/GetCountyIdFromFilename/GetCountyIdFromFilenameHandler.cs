using _3PA.Core.Models;
using MediatR;
namespace _3PA.API.Services.PublicRecords.Consumer.Queries.GetCountyIdFromFilename
{
	public class GetCountyIdFromFilenameHandler : IRequestHandler<GetCountyIdFromFilenameQuery, GetCountyIdFromFilenameResponse>
	{
		public Task<GetCountyIdFromFilenameResponse> Handle(GetCountyIdFromFilenameQuery request, CancellationToken cancellationToken)
		{
			var countyId = "";
			switch (request.UsState)
			{
				case UsState.Fl:
					countyId = request.FileName.Substring(0, 3);
				break;

				case UsState.Nc:
					var prefixCount = request.Category == Category.Voter ? 7 : 6;
					var suffixCount = request.FileName.Contains('.') ? request.FileName.Length - request.FileName.IndexOf('.') : 0;
					countyId = request.FileName.Substring(prefixCount, (request.FileName.Length - ( suffixCount + prefixCount)));
				break;

				default: throw new NotImplementedException($"UsState {request.UsState} not yet implemented");
			}

			var response = new GetCountyIdFromFilenameResponse(request, countyId);
			return Task.FromResult(response);
		}
	}
}
