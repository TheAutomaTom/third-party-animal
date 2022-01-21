namespace _3PA.API.Services.PublicRecords.Conventions.Queries
{
  public class GetCountyNameFromCodeResponse
  {
    public GetCountyNameFromCodeResponse(GetCountyNameFromCodeQuery query, string name = "Invalid Code")
    {
      Query = query;
      ProperName = name;
    }

    public GetCountyNameFromCodeQuery Query { get; set; }
    public string ProperName { get; set; }

  }
}
