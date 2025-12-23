using LCB_Clone.Shared.Enums.Legislators;

namespace LCB_Clone.Api.Infrastructure.Persistence.Entities;

public class LegislatorStrings
{
    public int Id { get; set; }

    public string Text { get; set; } = null!;
    public required LegislatorStringType Type { get; set; }

    public int LegislatorId { get; set; }
    public Legislator Legislator { get; set; } = null!;
}
