using LCB_Clone.Shared.Dtos.Legislators;
using LCB_Clone.Shared.Enums.Legislators;

namespace LCB_Clone.Shared.Dtos.LegislatorStrings;

public record LegislatorStringsResponseDto(
	int Id,
	string Text,
	LegislatorStringType Type,
	int LegislatorId,
	LegislatorResponseDto? Legislator
);
