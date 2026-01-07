using System.ComponentModel.DataAnnotations.Schema;
using LCB_Clone.Shared.Enums.Chambers;

namespace LCB_Clone.Api.Infrastructure.Persistence.Entities;

public class Session
{
	public int Id { get; set; }

	// --- Legislator Information ---
	public List<Legislator> Legislators { get; set; } = [];

	[NotMapped]
	public IEnumerable<Legislator> Senators =>
		Legislators.Where(s => s.Chamber == Chamber.Senate);

	[NotMapped]
	public IEnumerable<Legislator> AssemblyMembers =>
		Legislators.Where(asm => asm.Chamber == Chamber.Assembly);

	// --- Standing Rules ---
	public string SenateStandingRulesWithIndex { get; set; } = string.Empty;
	public string AssemblyStandingRulesWithIndex { get; set; } = string.Empty;
	public string JointStandingRulesWithIndex { get; set; } = string.Empty;

	// --- Budget and Fiscal Information
	public string GovernorsProposedExecutiveBudget { get; set; } = string.Empty;
	public string FiscalReport { get; set; } = string.Empty;

	// --- Journals And History ---
	// public List<Journal> AssemblyJournals { get; set; } = [];
	// public List<Journal> SenateJournals { get; set; } = [];

	// --- Reports ---
	// public List<Reports> Reports { get; set; } = [];
	// public List<Bills> Bills { get; set; } = [];
	// public List<BDR> BDRs { get; set; } = [];

	// --- Floor session ---
	// public List<FloorSession> FloorSessions { get; set; } = [];
	//
	// [NotMapped]
	// public IEnumerable<FloorSession> SenateFloorSessions =>
	// 	FloorSessions.Where(fs => fs.Chamber == Chamber.Senate);
	//
	// [NotMapped]
	// public IEnumerable<FloorSession> AssemblyFloorSessions =>
	// 	FloorSessions.Where(fs => fs.Chamber == Chamber.Assembly);

	// --- Deadlines ---
	// public List<int> SessionDeadlineIds = [];
	// public List<SessionDeadline> Deadlines = [];
}
