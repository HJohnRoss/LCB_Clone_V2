using LCB_Clone.Shared.Enums.Legislators;

using System.ComponentModel.DataAnnotations;

namespace LCB_Clone.Shared.Dtos.LegislatorStrings;

public class LegislatorStringsCreateDto(
		string text,
		LegislatorStringType type,
		int legislatorId
		)
{

	[Required]
	public required string Text { get; set; } = text;

	[Required]
	public required LegislatorStringType Type { get; set; } = type;

	[Required]
	public required int LegislatorId { get; set; } = legislatorId;
}

