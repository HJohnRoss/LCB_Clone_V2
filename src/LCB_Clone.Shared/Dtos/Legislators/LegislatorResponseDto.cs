using LCB_Clone.Shared.Dtos.LegislatorStrings;
using LCB_Clone.Shared.Dtos.Socials;

namespace LCB_Clone.Shared.Dtos.Legislators;

public record LegislatorResponseDto(
	string FirstName,
	string? MiddleName,
	string LastName,
	string Party,
	int County,
	string Email,
	int? LVOffice,
	int? CCOffice,
	string? CCPhone,
	int TermEndYear,
	List<SocialResponseDto>? Socials,
	List<LegislatorStringsResponseDto>? LegislatorStrings
);
