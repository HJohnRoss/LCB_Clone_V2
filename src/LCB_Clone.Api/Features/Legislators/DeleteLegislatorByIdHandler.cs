using LCB_Clone.Api.Infrastructure.Persistence;

namespace LCB_Clone.Api.Features.Legislators;

public sealed class DeleteLegislatorByIdHandler
{
    private readonly AppDbContext _db;

    public DeleteLegislatorByIdHandler(AppDbContext db) => _db = db;

    public async Task<bool> Handle(int id)
    {
        var legislator = await _db.Legislators.FindAsync(id);
        if (legislator == null) return false;

        _db.Legislators.Remove(legislator);
        await _db.SaveChangesAsync();
        return true;
    }
}

