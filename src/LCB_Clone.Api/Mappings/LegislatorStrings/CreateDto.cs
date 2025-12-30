using LCB_Clone.Api.Infrastructure.Persistence.Entities;
using LCB_Clone.Shared.Dtos.LegislatorStrings;

namespace LCB_Clone.Api.Mappings.LegislatorStrings;

public static class CreateDto
{
	public static LegislatorStringsCreateDto ToCreate(this LegislatorString legislatorString)
	{
		return new LegislatorStringsCreateDto(
				legislatorString.Text,
				legislatorString.Type,
				legislatorString.LegislatorId
				)
		{
			Text = legislatorString.Text,
			Type = legislatorString.Type,
			LegislatorId = legislatorString.LegislatorId
		};
	}
}
