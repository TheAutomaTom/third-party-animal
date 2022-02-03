using _3PA.Core.Models;
using MediatR;

namespace _3PA.API.Services.PublicRecords.Consumer.Commands
{
  public class ReadFileToSqlCommand: IRequest<ReadFileToSqlResponse>
  {
    public ReadFileToSqlCommand(UsState state, Category category, string fileName, string tempPath)
    {
      State = state;
      Category = category;
      FileName = fileName;
      TempPath = tempPath;

    }
    public UsState State { get; set; }
    public Category Category { get; set; }
    public string FileName { get; set; }
    public string TempPath { get; set; }





  }
}
