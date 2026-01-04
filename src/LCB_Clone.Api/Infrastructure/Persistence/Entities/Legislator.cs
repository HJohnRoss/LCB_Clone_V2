using System.ComponentModel.DataAnnotations;

namespace LCB_Clone.Api.Infrastructure.Persistence.Entities;

public class Legislator
{
	public int Id { get; set; }

	[Required]
	public string FirstName { get; set; } = null!;
	public string? MiddleName { get; set; }
	[Required]
	public string LastName { get; set; } = null!;
	[Required]
	public string Party { get; set; } = null!;
	[Required]
	public int County { get; set; }
	[Required]
	public string Email { get; set; } = null!;

	public int? LVOffice { get; set; }
	public int? CCOffice { get; set; }
	public string? CCPhone { get; set; }
	public int TermEndYear { get; set; }

	public List<Social> Socials { get; set; } = new();

	public List<LegislatorString> LegislatorStrings { get; set; } = new();

	// Private Constructor for EF
	// WARN: Look up on why i need this
	public Legislator() { }

	public Legislator(int id)
	{
		Id = id;
	}

	public Legislator(
		string firstName,
		string? middleName,
		string lastName,
		string party,
		int county,
		string email,
		int? lvOffice,
		int? ccOffice,
		string? ccPhone,
		int termEndYear
	)
	{
		FirstName = firstName;
		MiddleName = middleName;
		LastName = lastName;
		Party = party;
		County = county;
		Email = email;

		LVOffice = lvOffice;
		CCOffice = ccOffice;
		CCPhone = ccPhone;
		TermEndYear = termEndYear;
	}

	// update after creating models
	// public List<string> CommiteesServing = new List<string>();
	// public List<string> PrimarySponsorBills = new List<string>();
	// public List<string> SecondarySponsorBills = new List<string>();
}
