using LCB_Clone.Api.Infrastructure.Persistence.Entities;
using LCB_Clone.Shared.Dtos;
using LCB_Clone.Shared.Dtos.Legislators;
using LCB_Clone.Shared.Dtos.Socials;
using LCB_Clone.Api.Features.Socials;

namespace LCB_Clone.Api.Features.Legislators;

public static class LegislatorMappings
{
    public static LegislatorResponse ToResponse(this Legislator legislator)
    {
        return new LegislatorResponse(
            legislator.Id,
            legislator.FirstName,
            legislator.MiddleName,
            legislator.LastName,
            legislator.Party,
            legislator.County,
            legislator.Email,
            legislator.LVOffice,
            legislator.CCOffice,
            legislator.CCPhone,
            legislator.TermEndYear,
            legislator.Socials?.Select(s => s.ToResponse()).ToList()
        );
    }
}

