using LCB_Clone.Shared.Dtos.Socials;

namespace LCB_Clone.Api.Services.Interfaces;

public interface ISocialServices
{
	Task<List<SocialResponseDto>> GetAll();
	Task<SocialResponseDto?> GetOne(int id);
	Task<SocialResponseDto?> Create(SocialCreateDto dto);
	Task<bool> Delete(int id);
}
