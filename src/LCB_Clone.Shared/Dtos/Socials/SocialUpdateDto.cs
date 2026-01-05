using System.ComponentModel.DataAnnotations;

namespace LCB_Clone.Shared.Dtos.Socials;

public class SocialUpdateDto
{
	[Required]
	public int Id { get; set; }

	public string? Icon { get; set; }
	public string? WebsiteLink { get; set; }

	public int? LegislatorId { get; set; }
}

