using LCB_Clone.Api.Infrastructure.Persistence.Entities;
using LCB_Clone.Shared.Dtos.LegislatorStrings;

namespace LCB_Clone.Api.Mappings;

// Extention Utility class for LegislatorStringsMappings
public static class LegislatorStringsMappings
{
	public static LegislatorStringsResponseDto ToResponse(this LegislatorStrings legislatorStrings)
	{
		if (legislatorStrings == null)
		{
			return null!;
		}

		return new LegislatorStringsResponseDto(
				legislatorStrings.Text,
				legislatorStrings.Type
				);
	}
}
