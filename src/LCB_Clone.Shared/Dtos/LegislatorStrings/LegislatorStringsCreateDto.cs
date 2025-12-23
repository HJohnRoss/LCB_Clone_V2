using LCB_Clone.Shared.Enums.Legislators;

using System.ComponentModel.DataAnnotations;

namespace LCB_Clone.Shared.Dtos.LegislatorString;

public class LegislatorStringsCreateDto
{
    [Required]
    public required string Text { get; set; }

    [Required]
    public required LegislatorStringType Type { get; set; }

    [Required]
    public required int LegislatorId { get; set; }
}

