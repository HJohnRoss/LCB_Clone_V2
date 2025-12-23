namespace LCB_Clone.Api.Infrastructure.Persistence.Entities;

public class Legislator
{
    public int Id { get; set; }

    public string FirstName { get; set; } = string.Empty;
    public string? MiddleName { get; set; }
    public string LastName { get; set; } = string.Empty;
    public string Party { get; set; } = string.Empty;
    public string County { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

    public int? LVOffice { get; set; }
    public int? CCOffice { get; set; }
    public string? CCPhone { get; set; }
    public int TermEndYear { get; set; }

    public List<Social>? Socials { get; set; }

    public List<LegislatorStrings> CareerPersonal { get; set; } = new List<LegislatorStrings>();

    // update after creating models
    // public List<string> CommiteesServing = new List<string>();
    // public List<string> PrimarySponsorBills = new List<string>();
    // public List<string> SecondarySponsorBills = new List<string>();
}
