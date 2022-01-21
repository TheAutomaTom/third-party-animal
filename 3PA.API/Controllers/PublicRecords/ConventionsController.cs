using _3PA.API.Services.PublicRecords.Conventions.Queries;
using _3PA.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace _3PA.API.Controllers.PublicRecords
{
  [Route("api/PublicRecords/[Controller]")]  
  [ApiController] //What does [ApiController] enable?
  public class ConventionsController : Controller
  {
    readonly IMediator _mediator;

    public ConventionsController(IMediator mediator)
    {
      _mediator = mediator;
    }

    ///<summary>Convert abbreviated county codes used in public record filenames to proper name.</summary>
    ///<param name="state">Two letter U.S. state identifier (see SupportedUsStates Enum)</param>
    ///<param name="countyCode">May be letters or numbers.  Set by U.S. state entities (not an internal 3PA pattern)</param>
    /// <response code="200">Returns county code's equivalent proper name.</response>
    /// <response code="400">If the county code is recoreded in 3PA</response>
    [HttpGet("{state}/county-name/{countyCode}")]
    public async Task<ActionResult> GetCountyNameFromCode(SupportedUsStates state, string countyCode)
    {
      try
      {
        return Ok(await _mediator.Send( new GetCountyNameFromCodeQuery(state, countyCode) ));
      }
      catch (Exception)
      {

        return BadRequest();
      }
    }






  }
}
