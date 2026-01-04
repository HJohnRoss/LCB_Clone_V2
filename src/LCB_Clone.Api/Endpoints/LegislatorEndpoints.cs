using LCB_Clone.Api.Services.Interfaces;
using LCB_Clone.Shared.Dtos.Legislators;

namespace LCB_Clone.Api.Endpoints;

public static class LegislatorEndpoints
{

	public static void MapEndpoints(WebApplication app)
	{
		RouteGroupBuilder endpoint = app.MapGroup("/api/Legislator").WithTags("Legislator");

		endpoint.MapGet("", async (ILegislatorService legislatorService) =>
				await legislatorService.GetAll());

		endpoint.MapGet("{id:int}", async (ILegislatorService legislatorService, int id) =>
				await legislatorService.GetOne(id));

		endpoint.MapPost("", async (ILegislatorService legislatorService, LegislatorCreateDto dto) =>
				await legislatorService.Create(dto));

		endpoint.MapPut("", async (ILegislatorService legislatorService, LegislatorUpdateDto dto) =>
				await legislatorService.Update(dto));

		endpoint.MapDelete("{id:int}", async (ILegislatorService legislatorService, int id) =>
				await legislatorService.Delete(id));
	}
}
