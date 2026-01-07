using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LCB_Clone.Shared.Enums.Chambers;
using LCB_Clone.Shared.Enums.Legislators;

namespace LCB_Clone.Api.Infrastructure.Persistence.Entities;

public class Legislator
{
	public int Id { get; set; }

	// --- Legislator Information ---
	[Required]
	public string FirstName { get; set; } = string.Empty;
	public string? MiddleName { get; set; } = string.Empty;
	[Required]
	public string LastName { get; set; } = string.Empty;
	[Required]
	public string Party { get; set; } = string.Empty;
	[Required]
	public int County { get; set; }
	[Required]
	public string Email { get; set; } = string.Empty;
	public int? LVOffice { get; set; }
	public int? CCOffice { get; set; }
	public string? CCPhone { get; set; } = string.Empty;
	public int TermEndYear { get; set; }

	// --- 0: Senate, 1: Assembly ---
	public Chamber Chamber { get; set; }

	// --- Personal ---
	public List<Social> Socials { get; set; } = [];

	public List<LegislatorString> LegislatorStrings { get; set; } = [];

	[NotMapped]
	public IEnumerable<LegislatorString> Affiliations =>
		LegislatorStrings.Where(ls => ls.Type == LegislatorStringType.Affiliations);

	[NotMapped]
	public IEnumerable<LegislatorString> Education =>
		LegislatorStrings.Where(ls => ls.Type == LegislatorStringType.Education);

	[NotMapped]
	public IEnumerable<LegislatorString> HonorsRewards =>
		LegislatorStrings.Where(ls => ls.Type == LegislatorStringType.HonorsRewards);

	[NotMapped]
	public IEnumerable<LegislatorString> LegService =>
		LegislatorStrings.Where(ls => ls.Type == LegislatorStringType.LegService);

	[NotMapped]
	public IEnumerable<LegislatorString> MilitaryService =>
		LegislatorStrings.Where(ls => ls.Type == LegislatorStringType.MilitaryService);

	[NotMapped]
	public IEnumerable<LegislatorString> OtherAchivements =>
		LegislatorStrings.Where(ls => ls.Type == LegislatorStringType.OtherAchivements);

	[NotMapped]
	public IEnumerable<LegislatorString> OtherPublicService =>
		LegislatorStrings.Where(ls => ls.Type == LegislatorStringType.OtherPublicService);

	[NotMapped]
	public IEnumerable<LegislatorString> Personal =>
		LegislatorStrings.Where(ls => ls.Type == LegislatorStringType.Personal);

	[NotMapped]
	public IEnumerable<LegislatorString> Proffesional =>
		LegislatorStrings.Where(ls => ls.Type == LegislatorStringType.Proffesional);

	// --- Commitees ---
	// public List<string> CommiteesServing = new List<string>();

	// --- Bills ---
	// public List<string> PrimarySponsorBills = new List<string>();
	// public List<string> SecondarySponsorBills = new List<string>();

	// --- Contructors ---
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
}
