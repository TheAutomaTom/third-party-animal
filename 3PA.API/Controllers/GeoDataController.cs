<<<<<<< Updated upstream
﻿using _3PA.API.Services.GeoData.CountyNameById.Queries;
using _3PA.API.Services.GeoData.CountyNames.Queries;
using _3PA.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace _3PA.API.Controllers
{
  [Route("api/[Controller]")]
  [ApiController]
  public class GeoDataController : Controller
  {
    readonly IMediator _mediator;
    public GeoDataController(IMediator mediator)
    {
      _mediator = mediator;
    }

    ///<summary>Read public record file and write contents to local Sql</summary>
    ///<param name="usState">Two letter U.S. state identifier (see SupportedUsStates Enum)</param>
    /// <response code="200">A dictionary of county ids and proper names.</response>    
    [HttpGet("/CountyNames/{usState}")]
    public async Task<ActionResult> GetCountyNames(SupportedUsStates usState)
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


    ///<summary>Read public record file and write contents to local Sql</summary>
    ///<param name="usState">Two letter U.S. state identifier (see SupportedUsStates Enum)</param>
    ///<param name="countyId">Public records' county identifier used in file names.  Could be numbers or letters.</param>
    /// <response code="200">A dictionary of county ids and proper names.</response>    
    [HttpGet("/CountyName/{usState}/{countyId}")]
    public async Task<ActionResult> GetCountyNameById(SupportedUsStates usState, string countyId)
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
=======
﻿using _3PA.API.Services.GeoData.CountyNameById.Queries;
using _3PA.API.Services.GeoData.CountyNames.Queries;
using _3PA.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace _3PA.API.Controllers
{
  [Route("api/[Controller]")]
  [ApiController]
  public class GeoDataController : Controller
  {
    readonly IMediator _mediator;
    public GeoDataController(IMediator mediator)
    {
      _mediator = mediator;
    }

    ///<summary>Read public record file and write contents to local Sql</summary>
    ///<param name="usState">Two letter U.S. state identifier (see SupportedUsStates Enum)</param>
    /// <response code="200">A dictionary of county ids and proper names.</response>    
    [HttpGet("/CountyNames/{usState}")]
    public async Task<ActionResult> GetCountyNames(SupportedUsStates usState)
    {
      try
      {
        return Ok(await _mediator.Send(new CountyNamesRequest(usState)));
      }
      catch (Exception ex)
      {
        return BadRequest("Failled to get county data.");
      }
    }


    ///<summary>Read public record file and write contents to local Sql</summary>
    ///<param name="usState">Two letter U.S. state identifier (see SupportedUsStates Enum)</param>
    ///<param name="countyId">Public records' county identifier used in file names.  Could be numbers or letters.</param>
    /// <response code="200">A dictionary of county ids and proper names.</response>    
    [HttpGet("/CountyName/{usState}/{countyId}")]
    public async Task<ActionResult> GetCountyNameById(SupportedUsStates usState, string countyId)
    {
      try
      {
        return Ok(await _mediator.Send(new CountyNameByIdRequest(usState, countyId)));
      }
      catch (Exception)
      {
        return BadRequest("Failled to get county data.");
      }
    }


  }
>>>>>>> Stashed changes
}