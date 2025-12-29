using System.ComponentModel.DataAnnotations;

namespace LCB_Clone.Shared.Dtos.Legislators;

public class LegislatorUpdateDto
{
	[Required]
	public required int Id { get; set; }

	public string? FirstName { get; set; }

	public string? MiddleName { get; set; }

	public string? LastName { get; set; }
	public string? Party { get; set; }
	public string? County { get; set; }
	public string? Email { get; set; }

	public int? LVOffice { get; set; }
	public int? CCOffice { get; set; }
	public string? CCPhone { get; set; }

	public int? TermEndYear { get; set; }
}
