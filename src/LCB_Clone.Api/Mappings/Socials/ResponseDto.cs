using LCB_Clone.Api.Infrastructure.Persistence.Entities;
using LCB_Clone.Shared.Dtos.Socials;

namespace LCB_Clone.Api.Mappings.Socials;

// Extention Utility Class for Socials
public static class ResponseDtoMappings
{
	public static SocialResponseDto ToResponse(this Social social)
	{
		if (social == null)
		{
			return null!;
		}

		return new SocialResponseDto(
				social.Icon,
				social.WebsiteLink
				);
	}
}

