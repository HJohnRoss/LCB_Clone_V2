using LCB_Clone.Api.Infrastructure.Persistence.Entities;
using LCB_Clone.Shared.Dtos.LegislatorStrings;

namespace LCB_Clone.Api.Mappings.LegislatorStrings;

public static class CreateLegislatorString
{
	public static LegislatorString ToCreate(this LegislatorStringsCreateDto dto)
	{
		return new LegislatorString(
				dto.Text,
				dto.Type,
				dto.LegislatorId
				)
		{
			Text = dto.Text,
			Type = dto.Type,
			LegislatorId = dto.LegislatorId
		};
	}
}

