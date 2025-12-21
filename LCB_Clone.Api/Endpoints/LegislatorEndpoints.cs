using LCB_Clone.Api.Data;
using LCB_Clone.Shared.Models;

using Microsoft.EntityFrameworkCore;

namespace LCB_Clone.Api.Endpoints;

public static class LegislatorEndpoints
{
	public static void MapLegislatorEndpoints(this WebApplication app)
	{
		app.MapGet("/api/legislator", async (AppDbContext db) => await db.Legislator.ToListAsync());
		app.MapPost("/api/legislator", async (Legislator legislator, AppDbContext db) =>
		{
			db.Legislator.Add(legislator);
			await db.SaveChangesAsync();
			return Results.Ok(legislator);
		});
		// app.MapDelete("/api/legislator/{id}");
	}
}
