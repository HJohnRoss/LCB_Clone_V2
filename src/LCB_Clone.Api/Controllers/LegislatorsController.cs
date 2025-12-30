using LCB_Clone.Api.Services.Interfaces;
using LCB_Clone.Shared.Dtos.Legislators;
using Microsoft.AspNetCore.Mvc;

namespace LCB_Clone.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LegislatorsController(ILegislatorService legislatorService) : ControllerBase
{
	private readonly ILegislatorService _legislatorService = legislatorService;

	[HttpGet]
	public async Task<ActionResult<List<LegislatorResponseDto>>> GetAll()
	{
		// Creates DTO Response
		List<LegislatorResponseDto> legislators = await _legislatorService.GetAll();
		// Checks if there wasnt a response
		if (legislators == null)
		{
			// TODO: Error Handling
			return NotFound(legislators);
		}

		// Sends an 200 response with the object
		return Ok(legislators);
	}

	[HttpGet("/{id:int}")]
	public async Task<ActionResult<LegislatorResponseDto>> GetOne(int id)
	{
		// Creates DTO Reponse
		LegislatorResponseDto? legislator = await _legislatorService.GetOne(id);

		// Checks if theres a response
		if (legislator == null)
		{
			// TODO: Error Handling
			return BadRequest(legislator);
		}

		// Sends an 200 response with the object
		return Ok(legislator);
	}

	[HttpPost]
	public async Task<ActionResult<LegislatorResponseDto>> Create(LegislatorCreateDto dto)
	{
		// Creates DTO Response
		LegislatorResponseDto? legislator = await _legislatorService.Create(dto);
		if (legislator == null)
		{
			// TODO: Error Handling
			return BadRequest(legislator);
		}
		// Sends an 200 response with the object
		return Ok(legislator);
	}

	[HttpDelete("{id:int}")]
	public async Task<ActionResult> Delete(int id)
	{
		bool validRequest = await _legislatorService.Delete(id);
		if (!validRequest)
		{
			return NotFound("Legislator not found");
		}

		return Ok("Legislator Deleted");
	}

	[HttpPut]
	public async Task<ActionResult<LegislatorResponseDto?>> Update(LegislatorUpdateDto dto)
	{
		LegislatorResponseDto? legislator = await _legislatorService.Update(dto);
		if (legislator == null)
		{
			return NotFound(legislator);
		}

		return Ok(legislator);
	}
}
