using LCB_Clone.Api.Infrastructure.Persistence.Entities;
using LCB_Clone.Shared.Dtos;
using Microsoft.EntityFrameworkCore;
using LCB_Clone.Api.Infrastructure.Persistence;
using LCB_Clone.Shared.Dtos.Legislators;

namespace LCB_Clone.Api.Features.Legislators;

public sealed class GetLegislatorByIdHandler
{
    private readonly AppDbContext _db;

    public GetLegislatorByIdHandler(AppDbContext db) => _db = db;

    public async Task<LegislatorResponseDto?> Handle(int id)
    {
        var legislator = await _db.Legislators.FindAsync(id);
        return legislator?.ToResponse();
    }
}

