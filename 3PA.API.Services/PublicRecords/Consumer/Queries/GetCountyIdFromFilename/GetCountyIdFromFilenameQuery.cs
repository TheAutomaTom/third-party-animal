using _3PA.Core.Models;
using MediatR;
namespace _3PA.API.Services.PublicRecords.Consumer.Queries.GetCountyIdFromFilename
{
	public class GetCountyIdFromFilenameQuery : IRequest<GetCountyIdFromFilenameResponse>
  {
		public GetCountyIdFromFilenameQuery(UsState usState, Category category,string fileName)
		{
			UsState = usState;
			Category = category;
			FileName = fileName;
		}
		public UsState UsState { get; set; }
		public Category Category { get; set; }
		public string FileName { get; set; }
	}
}
