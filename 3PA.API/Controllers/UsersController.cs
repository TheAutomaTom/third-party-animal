using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace _3PA.API.Controllers
{
	[Route("api/[Controller]")]
	[ApiController]
	public class UsersController : Controller
	{
		readonly IMediator _mediator;
		public UsersController(IMediator mediator)
		{
			_mediator = mediator;
		}
		[HttpGet("Manifest")]
		public async Task<ActionResult> GetManifestSummary()
		{
			try
			{
				return Ok(await _mediator.Send(new ManifestSummaryRequest()));
			}
			catch (Exception ex)
			{
				return BadRequest("Failled to get county data.");
			}
		}




	}
}
