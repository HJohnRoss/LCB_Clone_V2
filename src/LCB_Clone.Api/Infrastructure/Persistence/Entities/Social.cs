using System.ComponentModel.DataAnnotations;

namespace LCB_Clone.Api.Infrastructure.Persistence.Entities;

public class Social
{
	public int Id { get; set; }

	[Required]
	public required string Icon { get; set; } = string.Empty;
	[Required]
	public required string WebsiteLink { get; set; } = string.Empty;

	[Required]
	public required int LegislatorId { get; set; }
	public Legislator Legislator { get; set; }

	public Social() { }
}
