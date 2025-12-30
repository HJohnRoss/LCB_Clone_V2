using LCB_Clone.Api.Infrastructure.Persistence.Entities;
using LCB_Clone.Shared.Dtos.Legislators;

namespace LCB_Clone.Api.Mappings.Legislators;

public static class ResponseDtoMappings
{
	public static LegislatorResponseDto ToResponse(this Legislator legislator)
	{
		if (legislator == null)
		{
			return null!;
		}

		return new LegislatorResponseDto(
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
				legislator.Socials?.Select(s => s.ToResponse()).ToList(),
				legislator.LegislatorStrings?.Select(ls => ls.ToResponse()).ToList()
				);
	}
}
