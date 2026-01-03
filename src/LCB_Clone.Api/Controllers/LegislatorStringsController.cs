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
			return NotFound(legislatorStrings);

		return Ok(legislatorStrings);
	}

	[HttpGet("{id:ulong}")]
	public async Task<ActionResult<LegislatorStringsResponseDto>> GetOne(ulong id)
	{
		LegislatorStringsResponseDto? legislatorString = await _legislatorStringsServices.GetOne(id);

		if (legislatorString == null)
			return NotFound(legislatorString);

		return Ok(legislatorString);
	}

	[HttpPost]
	public async Task<ActionResult<LegislatorStringsResponseDto>> Create(LegislatorStringsCreateDto dto)
	{
		LegislatorStringsResponseDto legislatorString = await _legislatorStringsServices.Create(dto);

		if (legislatorString == null)
			return BadRequest(legislatorString);

		return Ok(legislatorString);
	}

	[HttpDelete("{id:ulong}")]
	public async Task<ActionResult<bool>> Delete(ulong id)
	{
		bool isDeleted = await _legislatorStringsServices.Delete(id);

		if (!isDeleted)
			return NotFound(isDeleted);

		return Ok(isDeleted);
	}
}
