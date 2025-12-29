using LCB_Clone.Shared.Enums.Legislators;

using System.ComponentModel.DataAnnotations;

namespace LCB_Clone.Shared.Dtos.LegislatorStrings;

public class LegislatorStringsUpdateDto
{
	[Required]
	public required int Id { get; set; }

	public required string Text { get; set; }

	public required LegislatorStringType Type { get; set; }

	public required int LegislatorId { get; set; }
}


