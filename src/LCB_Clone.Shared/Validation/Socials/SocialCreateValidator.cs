using LCB_Clone.Shared.Dtos.Socials;
using LCB_Clone.Shared.Validation.Socials.Interfaces;

using static LCB_Clone.Shared.Validation.Helpers.ValidationHelpers;

namespace LCB_Clone.Shared.Validation.Socials;

public class SocialCreateValidator : ISocialCreateValidator
{
	public List<string> ValidateSocialCreate(SocialCreateDto dto)
	{
		List<string> errors = [];

		// RequireNonEmpty() - Helper function
		RequireNonEmpty(dto.Icon, "Icon", errors);
		RequireNonEmpty(dto.WebsiteLink, "Website Link", errors);

		if (dto.LegislatorId == null || dto.LegislatorId < 0)
			errors.Add("Legislator Id is required");

		return errors;
	}
}
