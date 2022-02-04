using _3PA.API.Services.Geographic.CountyNameById.Queries;
using _3PA.API.Services.Geographic.CountyNames.Queries;
using _3PA.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace _3PA.API.Controllers
{
  //[Route("api/[Controller]")] ...I don't know why this isn't working.  Maybe it needs to be ingheritted to be shared.
  [ApiController]
  public class GeographicController : Controller
  {
    readonly IMediator _mediator;
    public GeographicController(IMediator mediator)
    {
      _mediator = mediator;
    }

    ///<summary>Get a dictionary with a UsState's counties' elections agencies's id codes and proper names</summary>
    ///<param name="usState">Two letter U.S. state identifier (see SupportedUsStates Enum)</param>
    /// <response code="200">A dictionary of county ids and proper names.</response>    
    [HttpGet("api/[Controller]/CountyNames/{usState}")]
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
    [HttpGet("api/[Controller]/CountyName/{usState}/{countyId}")]
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