using LCB_Clone.Shared.Dtos.Legislators;

namespace LCB_Clone.Api.Features.Legislators;

public static class LegislatorEndpoints
{
    public static void MapLegislatorEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/api/legislators")
                       .WithTags("Legislators");

        group.MapGet("/", async (GetLegislatorsHandler handler) =>
        {
            var legislators = await handler.Handle();
            return Results.Ok(legislators);
        });

        group.MapGet("/{id:int}", async (int id, GetLegislatorByIdHandler handler) =>
        {
            var legislator = await handler.Handle(id);
            return legislator is not null ? Results.Ok(legislator) : Results.NotFound();
        });

        group.MapPost("/", async (LegislatorCreateDto dto, CreateLegislatorHandler handler) =>
        {
            var result = await handler.Handle(dto);
            return Results.Created($"/api/legislators/{result.Id}", result);
        });

        group.MapDelete("/{id:int}", async (int id, DeleteLegislatorByIdHandler handler) =>
        {
            var success = await handler.Handle(id);
            return success ? Results.Ok() : Results.NotFound();
        });
    }
}

