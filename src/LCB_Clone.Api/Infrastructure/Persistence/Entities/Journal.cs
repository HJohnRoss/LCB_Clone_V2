using System.ComponentModel.DataAnnotations;

namespace LCB_Clone.Api.Infrastructure.Persistence.Entities;

public class Journal
{
	public int Id { get; set; }

	[Required]
	public DateOnly? JournalDate { get; set; }
	[Required]
	public int? LegislativeDay { get; set; }
	[Required]
	public string? FileLocation { get; set; }
}
