using LCB_Clone.Shared.Dtos.Legislators;
using LCB_Clone.Shared.Enums.Legislators;

namespace LCB_Clone.Shared.Dtos.LegislatorStrings;

public record LegislatorStringsResponseDto(
	ulong Id,
	string Text,
	LegislatorStringType Type,
	ulong LegislatorId,
	LegislatorResponseDto? Legislator
);
