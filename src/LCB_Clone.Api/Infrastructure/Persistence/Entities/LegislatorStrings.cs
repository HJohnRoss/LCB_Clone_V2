using System.ComponentModel.DataAnnotations;
using LCB_Clone.Shared.Enums.Legislators;

namespace LCB_Clone.Api.Infrastructure.Persistence.Entities;

public class LegislatorString
{
	public int Id { get; set; }

	[Required]
	public required string Text { get; set; }
	[Required]
	public required LegislatorStringType Type { get; set; }

	[Required]
	public required int LegislatorId { get; set; }
	public Legislator? Legislator { get; set; }

	private LegislatorString() { }

	public LegislatorString(
		string text,
		LegislatorStringType type,
		int legislatorId
	)
	{
		Text = text;
		Type = type;
		LegislatorId = legislatorId;
	}
}
