namespace LCB_Clone.Shared.Models;

public class Legislator
{
	public int Id { get; set; }
	
	public string FirstName { get; set; } = string.Empty;
	public string? MiddleName { get; set; } = string.Empty;
	public string LastName { get; set; } = string.Empty;
	public string Party { get; set; } = string.Empty;
	public string County { get; set; } = string.Empty;
	public string Email { get; set; } = string.Empty;

	public int? LVOffice { get; set; }
	public int? CCOffice { get; set; }
	public int? CCPhone { get; set; }
	public int TermEnd { get; set; }

	public List<Social>? Socials { get; set; }
	public List<string> LegService { get; set; } = new List<string>();
	public List<string> HonorsRewards { get; set; } = new List<string>();
	public List<string> MilitaryService { get; set; } = new List<string>();
	public List<string> OtherPublicService { get; set; } = new List<string>();
	public List<string> OtherAchivements { get; set; } = new List<string>();
	public List<string> Affiliations { get; set; } = new List<string>();
	public List<string> Education { get; set; } = new List<string>();
	public List<string> Proffesional { get; set; } = new List<string>();
	public List<string> Personal { get; set; } = new List<string>();

	// update after creating models
	public List<string> CommiteesServing = new List<string>();
	public List<string> PrimarySponsorBills = new List<string>();
	public List<string> SecondarySponsorBills = new List<string>();
}
