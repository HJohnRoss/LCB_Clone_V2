using System.ComponentModel.DataAnnotations;

namespace LCB_Clone.Api.Infrastructure.Persistence.Entities;

public class Social
{
	public int Id { get; set; }

	[Required]
	public string? Icon { get; set; }
	[Required]
	public string? WebsiteLink { get; set; }

	[Required]
	public int LegislatorId { get; set; }
	public Legislator Legislator { get; set; } = null!;

	public Social() { }

	public Social(string? icon, string? websiteLink, int legislatorId)
	{
		Icon = icon;
		WebsiteLink = websiteLink;
		LegislatorId = legislatorId;
	}
}
