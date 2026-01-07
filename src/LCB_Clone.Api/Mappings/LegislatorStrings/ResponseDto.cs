using LCB_Clone.Api.Infrastructure.Persistence.Entities;
using LCB_Clone.Api.Mappings.Legislators;
using LCB_Clone.Shared.Dtos.LegislatorStrings;

namespace LCB_Clone.Api.Mappings.LegislatorStrings;

public static class ResponseDtoMappings
{
	public static LegislatorStringsResponseDto ToResponse(this LegislatorString legislatorStrings)
	{
		if (legislatorStrings == null)
		{
			return null!;
		}

		return new LegislatorStringsResponseDto(
				legislatorStrings.Id,
				legislatorStrings.Text,
				legislatorStrings.Type,
				LegislatorId: legislatorStrings.LegislatorId,
				Legislator: legislatorStrings.Legislator?.ToResponse()
				);
	}

	public static LegislatorStringsResponseDto MapLs(this LegislatorString ls) =>
		new(ls.Id, ls.Text, ls.Type, ls.LegislatorId, null);
}
