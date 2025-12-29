using System.ComponentModel.DataAnnotations;

namespace LCB_Clone.Shared.Dtos.Socials;

public class SocialCreateDto
{
	[Required]
	public required string Name { get; set; }
	public string? Link { get; set; }
}

