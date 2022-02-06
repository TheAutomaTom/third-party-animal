using _3PA.API.Services.PublicRecords.CountyNameById.Queries;
using _3PA.API.Services.PublicRecords.CountyNames.Queries;
using _3PA.API.Services.PublicRecords.Consumer.Commands;
using _3PA.API.Services.PublicRecords.Consumer.Queries.GetCountyIdFromFilename;
using _3PA.API.Services.PublicRecords.ManifestSummary.Queries.GetManifestSummary;
using _3PA.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace _3PA.API.Controllers
{
	[Route("api/[Controller]")]
  [ApiController] //What does [ApiController] enable?
  public class PublicRecordController : Controller
  {
    readonly IMediator _mediator;
    public PublicRecordController(IMediator mediator)
    {
      _mediator = mediator;
    }

    ///<summary>Read public record file and write contents to local Sql</summary>
    ///<param name="usState">Two letter U.S. state identifier.</param>
    ///<param name="category">Type of file: Voter Identities or Histories.</param>
    ///<param name="file">Publicly available elections againcy voter data file.</param>
    /// <response code="200">Returns count of rows added to local db.</response>
    /// <response code="400">If there are errors completing the task</response>
    [HttpPost("ToSql/{usState}/{category}")]
    [RequestSizeLimit(bytes: 500_000_000)]
    public async Task<ActionResult> ReadFileToSql(UsState usState, Category category, IFormFile file)
    {
      try
      {
        var fileExtention = Path.GetExtension(file.FileName);
        if (file.Length > 0 && fileExtention == ".txt")
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
          return Ok(_mediator.Send(new ReadFileToSqlCommand(usState, category, originalName, tempPath)));
        }
        return BadRequest();

      }
      catch (Exception)
      {
        return BadRequest();
      }
    }

    ///<summary>Decode the county identifier from an elections agency's filename.</summary>
    ///<remarks>This id is useful to cross reference for a proper name.</remarks>
    ///<param name="usState">Two letter U.S. state identifier</param>
    ///<param name="category">Type of file: Voter Identities or Histories.</param>
    ///<param name="fileName">Name of publicly available elections againcy voter data file.</param>
    [HttpGet("Describe/{usState}/{category}/{fileName}")]
    public async Task<ActionResult> GetIdFromFileName(UsState usState, Category category, string fileName)
    {
      try
      {
        return Ok(_mediator.Send(new GetCountyIdFromFilenameQuery(usState, category, fileName)));
      }
      catch (Exception)
      {
        return BadRequest("Failed to get county Id from filename.");
      }
    }

    ///<summary>Get a summary of all public records files processed.</summary>
    [HttpGet("Manifest")]
    public async Task<ActionResult> GetManifestSummary()
    {
      try
      {
        return Ok(await _mediator.Send(new GetManifestSummaryQuery()));
      }
      catch (Exception ex)
      {
        return BadRequest("Failled to get county data.");
      }
    }

    ///<summary>Get a dictionary with a UsState's counties' elections agencies's id codes and proper names</summary>
    ///<param name="usState">Two letter U.S. state identifier (see SupportedUsStates Enum)</param>
    /// <response code="200">A dictionary of county ids and proper names.</response>    
    [HttpGet("Counties/Dictionary/{usState}")]
    public async Task<ActionResult> GetCountyNames(UsState usState)
    {
      try
      {
        return Ok(await _mediator.Send(new CountyNamesQuery(usState)));
      }
      catch (Exception ex)
      {
        return BadRequest("Failled to get county data.");
      }
    }

    ///<summary>Get a UsState county's proper name based on elections agency's id code.</summary>
    ///<param name="usState">Two letter U.S. state identifier (see SupportedUsStates Enum)</param>
    ///<param name="countyId">Public records' county identifier used in file names.  Could be numbers or letters.</param>
    [HttpGet("Counties/NameFromId/{usState}/{countyId}")]
    public async Task<ActionResult> GetCountyNameById(UsState usState, string countyId)
    {
      try
      {
        return Ok(await _mediator.Send(new CountyNameByIdQuery(usState, countyId)));
      }
      catch (Exception)
      {
        return BadRequest("Failled to get county data.");
      }
    }


  }
}


