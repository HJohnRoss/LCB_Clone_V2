using LCB_Clone.Api.Data;
using LCB_Clone.Shared.Models;
using LCB_Clone.Shared.Dtos;

using Microsoft.EntityFrameworkCore;

namespace LCB_Clone.Api.Endpoints;

public static class LegislatorEndpoints
{
    public static void MapLegislatorEndpoints(this WebApplication app)
    {
        app.MapGet("/api/legislator", async (AppDbContext db) =>
                await db.Legislators.ToListAsync());

        app.MapGet("/api/legislator/{id}", async (int id, AppDbContext db) =>
            await db.Legislators.FindAsync(id) is Legislator legislator
                ? Results.Ok(legislator)
                : Results.NotFound());

        app.MapPost("/api/legislator", async (LegislatorCreateDto dto, AppDbContext db) =>
        {
            List<Social> socials = new List<Social>();
            if (dto.SocialIds != null && dto.SocialIds.Any())
            {
                socials = await db.Socials
                    .Where(s => dto.SocialIds.Contains(s.Id))
                    .ToListAsync();
            }

            Legislator legislator = new Legislator
            {
                FirstName = dto.FirstName,
                MiddleName = dto.MiddleName,
                LastName = dto.LastName,
                Party = dto.Party,
                County = dto.County,
                Email = dto.Email,
                LVOffice = dto.LVOffice,
                CCOffice = dto.CCOffice,
                CCPhone = dto.CCPhone,
                TermEnd = dto.TermEnd,
                Socials = socials
            };

            db.Legislators.Add(legislator);
            await db.SaveChangesAsync();
        });

        app.MapDelete("/api/legislator/{id}", async (int id, AppDbContext db) =>
        {
            Legislator? legislator = await db.Legislators.FindAsync(id);
            if (legislator == null)
            {
                return Results.NotFound();
            }

            db.Legislators.Remove(legislator);
            await db.SaveChangesAsync();
            return Results.Ok();
        });
    }
}
