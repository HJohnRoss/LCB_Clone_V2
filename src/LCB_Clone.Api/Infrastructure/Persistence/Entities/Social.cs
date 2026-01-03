using System.ComponentModel.DataAnnotations;

namespace LCB_Clone.Api.Infrastructure.Persistence.Entities;

public class Social
{
	public int Id { get; set; }

	[Required]
	public string Icon { get; set; } = null!;
	[Required]
	public string WebsiteLink { get; set; } = null!;

	[Required]
	public int LegislatorId { get; set; }
	[Required]
	public Legislator Legislator { get; set; } = null!;

	public Social() { }
}
