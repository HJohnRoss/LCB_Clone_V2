namespace LCB_Clone.Api.Infrastructure.Persistence.Entities;

public class Social
{
    public int Id { get; set; }

    public string Icon { get; set; } = string.Empty;
    public string WebsiteLink { get; set; } = string.Empty;

    public int LegislatorId { get; set; }
    public Legislator Legislator { get; set; } = null!;
}
