using LCB_Clone.Shared.Dtos.Socials;

namespace LCB_Clone.Shared.Validation.Socials.Interfaces;

public interface ISocialCreateValidator
{
	List<string> ValidateSocialCreate(SocialCreateDto dto);
}
