using LCB_Clone.Api.Infrastructure.Persistence.Entities;
using LCB_Clone.Shared.Dtos;
using Microsoft.EntityFrameworkCore;
using LCB_Clone.Api.Infrastructure.Persistence;
using LCB_Clone.Shared.Dtos.Legislators;
using LCB_Clone.Shared.Dtos.Socials;

namespace LCB_Clone.Api.Features.Legislators;

public sealed class CreateLegislatorHandler
{
    private readonly AppDbContext _db;

    public CreateLegislatorHandler(AppDbContext db) => _db = db;

    public async Task<LegislatorResponse> Handle(LegislatorCreateDto dto)
    {
        var socials = dto.SocialIds != null && dto.SocialIds.Any()
            ? await _db.Socials.Where(s => dto.SocialIds.Contains(s.Id)).ToListAsync()
            : new List<Social>();

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
            Socials = socials
        };

        _db.Legislators.Add(legislator);
        await _db.SaveChangesAsync();

        return legislator.ToResponse();
    }
}

