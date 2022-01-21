using _3PA.Core.Models;
using MediatR;

namespace _3PA.API.Services.PublicRecords.Conventions.Queries
{
  public class GetCountyNameFromCodeQuery : IRequest<GetCountyNameFromCodeResponse>
  {
    public GetCountyNameFromCodeQuery(SupportedUsStates state, string countyCode)
    {
      State = state;
      CountyCode = countyCode;
    }
    public SupportedUsStates State { get; set; }
    public string CountyCode { get; set; }

  }
}
