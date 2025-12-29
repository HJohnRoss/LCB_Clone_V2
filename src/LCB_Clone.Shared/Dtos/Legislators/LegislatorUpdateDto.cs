using System.ComponentModel.DataAnnotations;

namespace LCB_Clone.Shared.Dtos.Legislators;

public class LegislatorUpdateDto(
		int id,
		string? firstName,
		string? middleName,
		string? LastName,
		string? party,
		int? county,
		string? email,
		int? lvOffice,
		int? ccOffice,
		string? ccPhone,
		int? termEndYear
		)
{
	[Required]
	public required int Id { get; set; } = id;

	public string? FirstName { get; set; } = firstName;
	public string? MiddleName { get; set; } = middleName;
	public string? LastName { get; set; } = LastName;
	public string? Party { get; set; } = party;
	public int? County { get; set; } = county;
	public string? Email { get; set; } = email;
	public int? LVOffice { get; set; } = lvOffice;
	public int? CCOffice { get; set; } = ccOffice;
	public string? CCPhone { get; set; } = ccPhone;
	public int? TermEndYear { get; set; } = termEndYear;
}
