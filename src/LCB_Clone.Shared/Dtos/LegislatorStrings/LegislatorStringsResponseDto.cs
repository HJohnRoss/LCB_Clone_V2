using LCB_Clone.Shared.Enums.Legislators;

namespace LCB_Clone.Shared.Dtos.LegislatorStrings;

public record LegislatorStringsResponseDto(
	string Text,
	LegislatorStringType Type
);
