using LCB_Clone.Api.Infrastructure.Persistence.Entities;
using LCB_Clone.Shared.Dtos.Legislators;

namespace LCB_Clone.Api.Mappings.Legislators;

public static class CreateDtoMappings
{
	public static LegislatorCreateDto ToCreate(this Legislator legislator)
	{
		return new LegislatorCreateDto(
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
				legislator.Chamber
				)
		{
			FirstName = legislator.FirstName,
			LastName = legislator.LastName,
			Party = legislator.Party,
			County = legislator.County,
			Email = legislator.Email,
			TermEndYear = legislator.TermEndYear,
			Chamber = legislator.Chamber
		};
	}
}
