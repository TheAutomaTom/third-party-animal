using _3PA.Core.Models;
using MediatR;

namespace _3PA.API.Services.GeoData.CountyNameById.Queries
{
  public class CountyNameByIdQuery : IRequest<CountyNameByIdResponse>
  {
    public CountyNameByIdQuery(UsState usState, string countyId)
    {
      UsState = usState;
      CountyId = countyId;
    }
    public UsState UsState { get; set; }
    public string CountyId { get; set; }

  }
}
