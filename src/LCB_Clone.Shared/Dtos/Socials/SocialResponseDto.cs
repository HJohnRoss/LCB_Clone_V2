using LCB_Clone.Shared.Dtos.Legislators;

namespace LCB_Clone.Shared.Dtos.Socials;

public record SocialResponseDto(
	int Id,
	string? Icon,
	string? WebsiteLink,
	int? LegislatorId,
	LegislatorResponseDto? Legislator
);
