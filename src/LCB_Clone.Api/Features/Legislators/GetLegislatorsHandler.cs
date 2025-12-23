using Microsoft.EntityFrameworkCore;
using LCB_Clone.Api.Infrastructure.Persistence;
using LCB_Clone.Shared.Dtos.Legislators;

namespace LCB_Clone.Api.Features.Legislators;

public sealed class GetLegislatorsHandler
{
    private readonly AppDbContext _db;

    public GetLegislatorsHandler(AppDbContext db) => _db = db;

    public async Task<IEnumerable<LegislatorResponseDto>> Handle()
    {
        return await _db.Legislators
            .Select(l => l.ToResponse())
            .ToListAsync();
    }
}

