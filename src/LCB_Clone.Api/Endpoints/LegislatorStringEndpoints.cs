using LCB_Clone.Api.Services.Interfaces;
using LCB_Clone.Shared.Dtos.LegislatorStrings;

namespace LCB_Clone.Api.Endpoints;

public static class LegislatorStringEndpoints
{
	public static void MapEndpoints(WebApplication app)
	{
		app.MapGet("/api/LegislatorString", (ILegislatorStringsServices legislatorStringsServices) =>
				legislatorStringsServices.GetAll())
			.WithTags("LegislatorString");

		app.MapGet("/api/LegislatorString/{id:int}", (ILegislatorStringsServices legislatorStingsService, int id) =>
				legislatorStingsService.GetOne(id))
			.WithTags("LegislatorString");

		app.MapPost("/api/LegislatorString", (ILegislatorStringsServices legislatorStringsServices, LegislatorStringsCreateDto dto) =>
				legislatorStringsServices.Create(dto))
			.WithTags("LegislatorString");

		app.MapPut("/api/LegislatorString", (ILegislatorStringsServices legislatorStringsServices, LegislatorStringsUpdateDto dto) =>
				legislatorStringsServices.Update(dto))
			.WithTags("LegislatorString");

		app.MapDelete("/api/LegislatorString/{id:int}", (ILegislatorStringsServices legislatorStringsServices, int id) =>
				legislatorStringsServices.Delete(id))
			.WithTags("LegislatorString");
	}
}
