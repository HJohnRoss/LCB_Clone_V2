using LCB_Clone.Api.Services.Interfaces;
using LCB_Clone.Shared.Dtos.Legislators;

namespace LCB_Clone.Api.Endpoints;

public static class LegislatorEndpoints
{

	public static void MapEndpoints(WebApplication app)
	{
		app.MapGet("/api/Legislator", (ILegislatorService legislatorService) =>
				legislatorService.GetAll())
			.WithTags("Legislator");

		app.MapGet("/api/Legislator/{id:int}", (ILegislatorService legislatorService, int id) =>
				legislatorService.GetOne(id))
			.WithTags("Legislator");

		app.MapPost("/api/Legislator", (ILegislatorService legislatorService, LegislatorCreateDto dto) =>
				legislatorService.Create(dto))
			.WithTags("Legislator");

		app.MapPut("/api/Legislator", (ILegislatorService legislatorService, LegislatorUpdateDto dto) =>
				legislatorService.Update(dto))
			.WithTags("Legislator");

		app.MapDelete("/api/Legislator/{id:int}", (ILegislatorService legislatorService, int id) =>
				legislatorService.Delete(id))
			.WithTags("Legislator");
	}
}
