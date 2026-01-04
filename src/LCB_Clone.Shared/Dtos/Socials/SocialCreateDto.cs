using System.ComponentModel.DataAnnotations;

namespace LCB_Clone.Shared.Dtos.Socials;

public class SocialCreateDto(string? icon, string? websiteLink, int legislatorId)
{
	[Required]
	public string? Icon { get; set; } = icon;
	[Required]
	public string? WebsiteLink { get; set; } = websiteLink;

	[Required]
	public int LegislatorId { get; set; } = legislatorId;
}

