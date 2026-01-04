using LCB_Clone.Api.Services.Interfaces;
using LCB_Clone.Shared.Dtos.Socials;

namespace LCB_Clone.Api.Endpoints;

public static class SocialEndpoints
{
	public static void MapEndpoints(WebApplication app)
	{
		RouteGroupBuilder endpoint = app.MapGroup("/api/social").WithTags("Socials");

		endpoint.MapGet("", async (ISocialServices socialServices) =>
				await socialServices.GetAll());

		endpoint.MapGet("{id:int}", async (ISocialServices socialServices, int id) =>
				await socialServices.GetOne(id));

		endpoint.MapPost("", async (ISocialServices socialServices, SocialCreateDto dto) =>
				await socialServices.Create(dto));

		endpoint.MapDelete("{id:int}", async (ISocialServices socialServices, int id) =>
				await socialServices.Delete(id));
	}
}
