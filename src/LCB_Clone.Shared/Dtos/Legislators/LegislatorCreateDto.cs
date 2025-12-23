using System.ComponentModel.DataAnnotations;

namespace LCB_Clone.Shared.Dtos.Legislators;

public class LegislatorCreateDto
{
    [Required]
    public required string FirstName { get; set; }

    public string? MiddleName { get; set; }

    [Required]
    public required string LastName { get; set; }
    [Required]
    public required string Party { get; set; }
    [Required]
    public required string County { get; set; }
    [Required]
    public required string Email { get; set; }

    public int? LVOffice { get; set; }
    public int? CCOffice { get; set; }
    public string? CCPhone { get; set; }

    [Required]
    public required int TermEndYear { get; set; }
}
