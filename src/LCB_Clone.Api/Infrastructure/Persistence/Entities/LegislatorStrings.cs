using System.ComponentModel.DataAnnotations;
using LCB_Clone.Shared.Enums.Legislators;

namespace LCB_Clone.Api.Infrastructure.Persistence.Entities;

public class LegislatorStrings
{
	[Required]
	public required int Id { get; set; }

	[Required]
	public required string Text { get; set; } = null!;
	[Required]
	public required LegislatorStringType Type { get; set; }

	public int LegislatorId { get; set; }
	public Legislator Legislator { get; set; } = null!;
}
