using LCB_Clone.Api.Services.Interfaces;
using LCB_Clone.Shared.Dtos.Legislators;
using LCB_Clone.Shared.Validation.Legislators.Interfaces;

namespace LCB_Clone.Api.Endpoints;

public static class LegislatorEndpoints
{

	public static void MapEndpoints(WebApplication app)
	{
		RouteGroupBuilder endpoint = app.MapGroup("/api/Legislator").WithTags("Legislator");

		endpoint.MapGet("", async (ILegislatorService legislatorService) =>
		{
			return Results.Ok(await legislatorService.GetAll());
		});

		endpoint.MapGet("{id:int}", async (ILegislatorService legislatorService, int id) =>
		{
			LegislatorResponseDto? legislator = await legislatorService.GetOne(id);
			return legislator != null
				? Results.Ok(legislator)
				: Results.NotFound();
		});

		endpoint.MapPost("", async (
					ILegislatorService legislatorService,
					ILegislatorCreateValidator validator,
					LegislatorCreateDto dto) =>
		{
			// Validation
			List<string> errors = validator.ValidateCreateLegislator(dto);
			if (errors.Count > 0)
				return Results.BadRequest(new { errors });

			// Database logic
			LegislatorResponseDto? legislator = await legislatorService.Create(dto);

			return legislator != null
				? Results.Created($"/api/Legislator/{legislator.Id}", legislator)
				: Results.BadRequest();
		});

		endpoint.MapPut("", async (
					ILegislatorService legislatorService,
					ILegislatorUpdateValidator validator,
					LegislatorUpdateDto dto) =>
		{
			// Validation
			List<string> errors = validator.ValidateUpdateDto(dto);
			if (errors.Count > 0)
				return Results.BadRequest(new { errors });

			// Database logic
			bool updated = await legislatorService.Update(dto);

			return updated
				? Results.Ok()
				: Results.NotFound();
		});

		endpoint.MapDelete("{id:int}", async (ILegislatorService legislatorService, int id) =>
		{
			bool deleted = await legislatorService.Delete(id);
			return deleted
				? Results.NoContent()
				: Results.NotFound();
		});
	}
}
