using LCB_Clone.Shared.Dtos.Socials;
using LCB_Clone.Shared.Validation.Socials.Interfaces;

namespace LCB_Clone.Shared.Validation.Socials;

public class SocialUpdateValidator : ISocialUpdateValidator
{
	public List<string> ValidateSocialUpdate(SocialUpdateDto dto)
	{
		List<string> errors = [];

		if (dto.Icon != null && dto.Icon.Length == 0)
			errors.Add("Icon is required");

		if (dto.WebsiteLink != null && dto.WebsiteLink.Length == 0)
			errors.Add("Website Link is required");

		if (dto.LegislatorId != null & dto.LegislatorId < 0)
			errors.Add("Legislator Id is invalid");

		return errors;
	}
}
