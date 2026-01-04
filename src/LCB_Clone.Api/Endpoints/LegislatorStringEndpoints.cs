using LCB_Clone.Api.Services.Interfaces;
using LCB_Clone.Shared.Dtos.LegislatorStrings;

namespace LCB_Clone.Api.Endpoints;

public static class LegislatorStringEndpoints
{
	public static void MapEndpoints(WebApplication app)
	{
		RouteGroupBuilder endpoint = app.MapGroup("/api/LegislatorString").WithTags("LegislatorString");

		endpoint.MapGet("", async (ILegislatorStringsServices legislatorStringsServices) =>
				await legislatorStringsServices.GetAll());

		endpoint.MapGet("{id:int}", async (ILegislatorStringsServices legislatorStingsService, int id) =>
				await legislatorStingsService.GetOne(id));

		endpoint.MapPost("", async (ILegislatorStringsServices legislatorStringsServices, LegislatorStringsCreateDto dto) =>
				await legislatorStringsServices.Create(dto));

		endpoint.MapPut("", async (ILegislatorStringsServices legislatorStringsServices, LegislatorStringsUpdateDto dto) =>
				await legislatorStringsServices.Update(dto));

		endpoint.MapDelete("{id:int}", async (ILegislatorStringsServices legislatorStringsServices, int id) =>
				await legislatorStringsServices.Delete(id));
	}
}
