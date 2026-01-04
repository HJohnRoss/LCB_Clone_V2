using LCB_Clone.Api.Infrastructure.Persistence.Entities;
using LCB_Clone.Shared.Dtos.Socials;

namespace LCB_Clone.Api.Mappings.Socials;

public static class CreateDto
{
	public static SocialCreateDto ToCreate(this Social social)
	{
		return new SocialCreateDto(
				social.Icon,
				social.WebsiteLink,
				social.LegislatorId
				);
	}
}
