using LCB_Clone.Shared.Dtos.Socials;

namespace LCB_Clone.Api.Services.Interfaces;

public interface ISocialServices
{
	Task<List<SocialResponseDto>> GetAll();
}
