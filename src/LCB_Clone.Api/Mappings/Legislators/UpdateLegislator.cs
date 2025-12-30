using LCB_Clone.Api.Infrastructure.Persistence.Entities;
using LCB_Clone.Shared.Dtos.Legislators;

namespace LCB_Clone.Api.Mappings.Legislators;

public static class UpdateLegislator
{
	public static void ApplyUpdate(this LegislatorUpdateDto dto, Legislator legislator)
	{
		if (dto.FirstName != null) legislator.FirstName = dto.FirstName;
		if (dto.MiddleName != null) legislator.MiddleName = dto.MiddleName;
		if (dto.LastName != null) legislator.LastName = dto.LastName;
		if (dto.Party != null) legislator.Party = dto.Party;
		if (dto.County != null) legislator.County = dto.County.Value;
		if (dto.Email != null) legislator.Email = dto.Email;

		if (dto.LVOffice.HasValue) legislator.LVOffice = dto.LVOffice;
		if (dto.CCOffice.HasValue) legislator.CCOffice = dto.CCOffice;
		if (dto.CCPhone != null) legislator.CCPhone = dto.CCPhone;

		if (dto.TermEndYear.HasValue) legislator.TermEndYear = dto.TermEndYear.Value;
	}
}

