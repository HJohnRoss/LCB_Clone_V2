namespace LCB_Clone.Shared.Dtos;

public class LegislatorResponseDto
{
    public string FirstName { get; set; } = string.Empty;
    public string? MiddleName { get; set; }
    public string LastName { get; set; } = string.Empty;
    public string Party { get; set; } = string.Empty;
    public string County { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

    public int? LVOffice { get; set; }
    public int? CCOffice { get; set; }
    public int? CCPhone { get; set; }
    public int TermEnd { get; set; }

    // Use IDs instead of nested Social objects
    public List<int>? SocialIds { get; set; }
}

