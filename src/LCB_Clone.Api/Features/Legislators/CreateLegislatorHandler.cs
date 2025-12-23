using LCB_Clone.Api.Infrastructure.Persistence.Entities;
using LCB_Clone.Api.Infrastructure.Persistence;
using LCB_Clone.Shared.Dtos.Legislators;

namespace LCB_Clone.Api.Features.Legislators;

public sealed class CreateLegislatorHandler
{
    private readonly AppDbContext _db;

    public CreateLegislatorHandler(AppDbContext db) => _db = db;

    public async Task<LegislatorResponseDto> Handle(LegislatorCreateDto dto)
    {
        var legislator = new Legislator
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
            TermEndYear = dto.TermEndYear,
        };

        _db.Legislators.Add(legislator);
        await _db.SaveChangesAsync();

        return legislator.ToResponse();
    }
}

