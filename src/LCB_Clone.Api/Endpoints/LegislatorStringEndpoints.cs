using LCB_Clone.Api.Services.Interfaces;
using LCB_Clone.Shared.Dtos.LegislatorStrings;

namespace LCB_Clone.Api.Endpoints;

public static class LegislatorStringEndpoints
{
	public static void MapEndpoints(WebApplication app)
	{
		RouteGroupBuilder endpoint = app.MapGroup("/api/LegislatorString").WithTags("LegislatorString");

		endpoint.MapGet("", async (ILegislatorStringsServices legislatorStringsServices) =>
		{
			return Results.Ok(await legislatorStringsServices.GetAll());
		});

		endpoint.MapGet("{id:int}", async (ILegislatorStringsServices legislatorStingsService, int id) =>
		{
			LegislatorStringsResponseDto? response = await legislatorStingsService.GetOne(id);
			return response != null
				? Results.Ok(response)
				: Results.NotFound();
		});

		endpoint.MapPost("", async (ILegislatorStringsServices legislatorStringsServices, LegislatorStringsCreateDto dto) =>
		{
			LegislatorStringsResponseDto response = await legislatorStringsServices.Create(dto);
			return response != null
				? Results.Created($"/api/LegislatorString/{response.Id}", response)
				: Results.BadRequest();
		});

		endpoint.MapPut("", async (ILegislatorStringsServices legislatorStringsServices, LegislatorStringsUpdateDto dto) =>
		{
			bool response = await legislatorStringsServices.Update(dto);
			return response
				? Results.Ok()
				: Results.BadRequest();
		});

		endpoint.MapDelete("{id:int}", async (ILegislatorStringsServices legislatorStringsServices, int id) =>
		{
			bool response = await legislatorStringsServices.Delete(id);
			return response
				? Results.NoContent()
				: Results.NotFound();
		});
	}
}
