using _3PA.API.Services.PublicRecords.Consumer.Commands;
using _3PA.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace _3PA.API.Controllers.PublicRecords
{  
  [Route("api/PublicRecords/[Controller]")]
  [ApiController] //What does [ApiController] enable?
  public class ConsumerController : Controller
  {
    readonly IMediator _mediator;

    public ConsumerController(IMediator mediator)
    {
      _mediator = mediator;
    }

    ///<summary>Read public record file and write contents to local Sql</summary>
    ///<param name="state">Two letter U.S. state identifier (see SupportedUsStates Enum)</param>
    ///<param name="file">Publicly available voter data file</param>
    /// <response code="200">Returns count of rows added to local db.</response>
    /// <response code="400">If there are errors completing the task</response>
    [HttpPost("sql/from-public-records/{state}/{category}-file")]
    [RequestSizeLimit(bytes: 500_000_000)]
    public async Task<ActionResult> ReadFileToSql(SupportedUsStates state, Category category, IFormFile file)
    {
      try
      {
        if(file.Length > 0)
        {
          //originalName must be used to config objects being read
          var originalName = Path.GetFileName(file.FileName);

          var tempPath = Path.GetTempFileName();
          // Explict call to use temp file caching
          // TODO: test effectiveness on large file
          FileInfo fileInfo = new FileInfo(tempPath);
          fileInfo.Attributes = FileAttributes.Temporary;

          using (var filestream = System.IO.File.Create(tempPath))
          {
            // This copies the file to local storage to be read at-will by Handle().
            // This sounds funny since it's already local, but I wanted to mock up an "upload scenario."
            await file.CopyToAsync(filestream);
            filestream.Close();
          }
          return Ok(_mediator.Send(new ReadFileToSqlRequest(state, category, originalName, tempPath)));
        }
        return BadRequest();

      }
      catch (Exception)
      {

        return BadRequest();
      }
    }

  }
}

        /*
        foreach (var formFile in files)
        {
            if (formFile.Length > 0)
            {
                var filePath = Path.GetTempFileName();

                using (var stream = System.IO.File.Create(filePath))
                {
                    await formFile.CopyToAsync(stream);
                }
            }
        }
         */

