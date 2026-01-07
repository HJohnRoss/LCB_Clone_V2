using LCB_Clone.Shared.Enums.Legislators;

using System.ComponentModel.DataAnnotations;

namespace LCB_Clone.Shared.Dtos.LegislatorStrings;

public class LegislatorStringsCreateDto(
		string text,
		LegislatorStringType type,
		int? legislatorId
		)
{

	[Required]
	public string Text { get; set; } = text;

	[Required]
	public LegislatorStringType Type { get; set; } = type;

	[Required]
	public int? LegislatorId { get; set; } = legislatorId;
}

