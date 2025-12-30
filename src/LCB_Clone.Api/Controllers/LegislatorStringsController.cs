using LCB_Clone.Api.Services.Interfaces;
using LCB_Clone.Shared.Dtos.LegislatorStrings;
using Microsoft.AspNetCore.Mvc;

namespace LCB_Clone.Api.Controllers;

[ApiController]
[Route("api/[Controller]")]
public class LegislatorStringsController(ILegislatorStringsServices legislatorStringsServices) : ControllerBase
{
	private readonly ILegislatorStringsServices _legislatorStringsServices = legislatorStringsServices;
	[HttpGet]
	public async Task<ActionResult<List<LegislatorStringsResponseDto>>> GetAll()
	{
		List<LegislatorStringsResponseDto> legislatorStrings = await _legislatorStringsServices.GetAll();

		if (legislatorStrings == null)
		{
			return NotFound(legislatorStrings);
		}

		return Ok(legislatorStrings);
	}

}
