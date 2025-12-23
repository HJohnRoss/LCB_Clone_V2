using LCB_Clone.Shared.Dtos.Socials;

namespace LCB_Clone.Shared.Dtos.Legislators;

public record LegislatorResponseDto(
    int Id,
    string FirstName,
    string? MiddleName,
    string LastName,
    string Party,
    string County,
    string Email,
    int? LVOffice,
    int? CCOffice,
    string? CCPhone,
    int TermEndYear,
    List<SocialResponseDto>? Socials
);
