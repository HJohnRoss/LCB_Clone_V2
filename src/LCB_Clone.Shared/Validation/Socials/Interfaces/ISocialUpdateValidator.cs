using LCB_Clone.Shared.Dtos.Socials;

namespace LCB_Clone.Shared.Validation.Socials.Interfaces;

public interface ISocialUpdateValidator
{
	List<string> ValidateSocialUpdate(SocialUpdateDto dto);
}
