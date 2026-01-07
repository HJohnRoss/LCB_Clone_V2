using System.ComponentModel.DataAnnotations;
using LCB_Clone.Shared.Enums.Chambers;

namespace LCB_Clone.Shared.Dtos.Legislators;

public class LegislatorCreateDto(
		string firstName,
		string? middleName,
		string lastName,
		string party,
		int county,
		string email,
		int? lvOffice,
		int? ccOffice,
		string? ccPhone,
		int termEndYear,
		Chamber chamber
		)
{
	[Required]
	public required string FirstName { get; set; } = firstName;

	public string? MiddleName { get; set; } = middleName;

	[Required]
	public required string LastName { get; set; } = lastName;
	[Required]
	public required string Party { get; set; } = party;
	[Required]
	public required int County { get; set; } = county;
	[Required]
	public required string Email { get; set; } = email;

	public int? LVOffice { get; set; } = lvOffice;
	public int? CCOffice { get; set; } = ccOffice;
	public string? CCPhone { get; set; } = ccPhone;

	[Required]
	public required int TermEndYear { get; set; } = termEndYear;

	[Required]
	public required Chamber Chamber { get; set; } = chamber;
}
