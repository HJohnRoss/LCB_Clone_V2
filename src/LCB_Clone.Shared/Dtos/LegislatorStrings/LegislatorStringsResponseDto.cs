using LCB_Clone.Shared.Dtos.Legislators;
using LCB_Clone.Shared.Enums.Legislators;

namespace LCB_Clone.Shared.Dtos.LegislatorString;

public record LegislatorStringsResponseDto(
    int Id,
    string Text,
    LegislatorStringType Type,
    LegislatorResponseDto Legislator
);
