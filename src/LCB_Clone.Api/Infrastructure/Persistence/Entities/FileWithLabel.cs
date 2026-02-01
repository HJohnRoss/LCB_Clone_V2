using System.ComponentModel.DataAnnotations;

namespace LCB_Clone.Api.Infrastructure.Persistence.Entities;

public class FileWithLabel
{
	public int Id { get; set; }

	[Required]
	public string? Location { get; set; }
	[Required]
	public string? Label { get; set; }
}
