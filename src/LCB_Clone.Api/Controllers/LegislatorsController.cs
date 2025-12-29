using LCB_Clone.Api.Services.Interfaces;
using LCB_Clone.Shared.Dtos.Legislators;
using Microsoft.AspNetCore.Mvc;

namespace LCB_Clone.Api.Controllers;

[ApiController]
[Route("api[controller]")]
public class LegislatorsController(ILegislatorService legislatorService) : ControllerBase
{
	private readonly ILegislatorService _legislatorService = legislatorService;

	[HttpGet]
	public async Task<ActionResult<LegislatorResponseDto>> GetAll()
	{
		List<LegislatorResponseDto> legislators = await _legislatorService.GetAll();
		if (legislators == null)
		{
			return NotFound(legislators);
		}

		return Ok(legislators);
	}
}
