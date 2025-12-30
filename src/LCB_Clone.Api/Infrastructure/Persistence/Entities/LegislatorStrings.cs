using System.ComponentModel.DataAnnotations;
using LCB_Clone.Shared.Enums.Legislators;

namespace LCB_Clone.Api.Infrastructure.Persistence.Entities;

public class LegislatorString
{
	[Required]
	public required int Id { get; set; }

	[Required]
	public required string Text { get; set; }
	[Required]
	public required LegislatorStringType Type { get; set; }

	[Required]
	public required int LegislatorId { get; set; }
	public required Legislator Legislator { get; set; }
}
