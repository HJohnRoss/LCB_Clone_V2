using LCB_Clone.Shared.Dtos.Socials;

namespace LCB_Clone.Api.Tests.TestData.Socials.Interfaces;

public interface ISocialTestData
{
	Task<SocialResponseDto> CreateSocialAsync();
}
