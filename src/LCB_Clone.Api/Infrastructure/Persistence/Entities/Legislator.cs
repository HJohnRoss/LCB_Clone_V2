using System.ComponentModel.DataAnnotations;

namespace LCB_Clone.Api.Infrastructure.Persistence.Entities;

public class Legislator
{
	[Required]
	public required int Id { get; set; }

	[Required]
	public required string FirstName { get; set; }
	public string? MiddleName { get; set; }
	[Required]
	public required string LastName { get; set; }
	[Required]
	public required string Party { get; set; }
	[Required]
	public required int County { get; set; }
	[Required]
	public required string Email { get; set; }

	public int? LVOffice { get; set; }
	public int? CCOffice { get; set; }
	public string? CCPhone { get; set; }
	public int TermEndYear { get; set; }

	public List<Social> Socials { get; set; } = new();

	public List<LegislatorStrings> LegislatorStrings { get; set; } = new();

	// update after creating models
	// public List<string> CommiteesServing = new List<string>();
	// public List<string> PrimarySponsorBills = new List<string>();
	// public List<string> SecondarySponsorBills = new List<string>();
}
