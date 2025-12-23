using LCB_Clone.Api.Infrastructure.Persistence.Entities;
using LCB_Clone.Shared.Dtos.Socials;

namespace LCB_Clone.Api.Features.Socials
{
    public static class SocialMappings
    {
        public static SocialResponseDto ToResponse(this Social social)
        {
            if (social == null) return null!; // handle null gracefully if needed

            return new SocialResponseDto(
                social.Id,
                social.Icon,
                social.WebsiteLink
            );
        }
    }
}

