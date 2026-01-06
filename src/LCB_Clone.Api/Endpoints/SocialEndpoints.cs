using LCB_Clone.Api.Services.Interfaces;
using LCB_Clone.Shared.Dtos.Socials;

namespace LCB_Clone.Api.Endpoints;

public static class SocialEndpoints
{
	public static void MapEndpoints(WebApplication app)
	{
		RouteGroupBuilder endpoint = app.MapGroup("/api/Social").WithTags("Socials");

		endpoint.MapGet("", async (ISocialServices socialServices) =>
		{
			List<SocialResponseDto> response = await socialServices.GetAll();
			return Results.Ok(response);
		});

		endpoint.MapGet("{id:int}", async (ISocialServices socialServices, int id) =>
				{
					SocialResponseDto? response = await socialServices.GetOne(id);
					return response != null
						? Results.Ok(response)
						: Results.NotFound();
				});

		endpoint.MapPost("", async (ISocialServices socialServices, SocialCreateDto dto) =>
				{
					SocialResponseDto? response = await socialServices.Create(dto);
					return response != null
						? Results.Created($"/api/social/{response.Id}", response)
						: Results.BadRequest();
				});

		endpoint.MapDelete("{id:int}", async (ISocialServices socialServices, int id) =>
				{
					bool response = await socialServices.Delete(id);
					return response
						? Results.NoContent()
						: Results.NotFound();
				});

		endpoint.MapPut("", async (ISocialServices socialServices, SocialUpdateDto dto) =>
				{
					bool response = await socialServices.Update(dto);
					return response
						? Results.Ok()
						: Results.BadRequest();
				});
	}
}
