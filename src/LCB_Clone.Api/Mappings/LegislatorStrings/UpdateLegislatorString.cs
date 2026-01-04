using LCB_Clone.Shared.Dtos.LegislatorStrings;
using LCB_Clone.Api.Infrastructure.Persistence.Entities;

namespace LCB_Clone.Api.Mappings.LegislatorStrings;

public static class UpdateLegislatorString
{
	public static void ApplyUpdate(this LegislatorStringsUpdateDto dto, LegislatorString legislatorString)
	{
		if (dto.Text != null) legislatorString.Text = dto.Text;
		if (dto.Type != null) legislatorString.Type = dto.Type;
		if (dto.LegislatorId.HasValue) legislatorString.LegislatorId = dto.LegislatorId;
	}
}
