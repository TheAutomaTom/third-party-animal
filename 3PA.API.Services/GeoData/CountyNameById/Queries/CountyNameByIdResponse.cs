using _3PA.Core.Models;

namespace _3PA.API.Services.GeoData.CountyNameById.Queries
{
  public class CountyNameByIdResponse
  {
    public CountyNameByIdResponse(CountyNameByIdQuery query, string properName = "Invalid Code")
    {
      UsState = query.UsState.ToString();
      CountyId = query.CountyId;
      ProperName = properName;
    }
    public string UsState { get; set; }
    public string CountyId { get; set; }
    public string ProperName { get; set; }

  }
}