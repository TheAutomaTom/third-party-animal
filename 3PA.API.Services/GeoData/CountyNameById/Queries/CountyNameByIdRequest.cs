using _3PA.Core.Models;
using MediatR;

namespace _3PA.API.Services.GeoData.CountyNameById.Queries
{
  public class CountyNameByIdRequest : IRequest<CountyNameByIdResponse>
  {
    public CountyNameByIdRequest(SupportedUsStates usState, string countyId)
    {
      UsState = usState;
      CountyId = countyId;
    }
    public SupportedUsStates UsState { get; set; }
    public string CountyId { get; set; }

  }
}
