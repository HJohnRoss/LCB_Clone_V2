using System.ComponentModel.DataAnnotations;

namespace LCB_Clone.Shared.Dtos.Socials;

public class SocialUpdateDto
{
	[Required]
	public required int Id { get; set; }

	public string? Name { get; set; }
	public string? Link { get; set; }
}

