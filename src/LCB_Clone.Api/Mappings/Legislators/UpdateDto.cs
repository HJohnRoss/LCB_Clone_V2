using LCB_Clone.Api.Infrastructure.Persistence.Entities;
using LCB_Clone.Shared.Dtos.Legislators;

namespace LCB_Clone.Api.Mappings.Legislators;

public static class UpdateDtoMappings
{
	public static LegislatorUpdateDto ToUpdate(this Legislator legislator)
	{
		return new LegislatorUpdateDto(
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
				legislator.Chamber
				)
		{
			// Specifying the [Required] class property's
			Id = legislator.Id
		};
	}
}
