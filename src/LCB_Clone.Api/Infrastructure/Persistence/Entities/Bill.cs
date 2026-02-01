using System.ComponentModel.DataAnnotations;

namespace LCB_Clone.Api.Infrastructure.Persistence.Entities;

public class Bill
{
	public int Id { get; set; }

	[Required]
	public bool? IsSenateBill { get; set; }

	[Required]
	public string? BillNumber { get; set; }
	[Required]
	public string? Summary { get; set; }
	[Required]
	public DateOnly? IntroductionDate { get; set; }

	// Fiscal Notes
	[Required]
	public bool? IsEffectingLocalGovernment { get; set; }
	[Required]
	public bool? IsEffectingState { get; set; }

	// Primary Sponsors
	// TODO: Create SessionCommittee Model
	// public int? PrimaryCommitteeSponsorId { get; set; }
	// public SessionCommittee? PrimaryCommitteeSponsor { get; set; }

	public List<int>? PrimaryLegislatorSponsorIds { get; set; }
	public List<Legislator>? PrimaryLegislatorSponsors { get; set; }

	// Secondary Sponsors
	// public int? SecondaryCommitteeSponsor { get; set; }
	// public SessionCommittee? SecondaryCommitteeSponsor { get; set; }

	public List<int>? SecondaryLegislatorSponsorIds { get; set; }
	public List<Legislator>? SecondaryLegislatorSponsors { get; set; }

	// Title and Digest
	[Required]
	public string? Title { get; set; }
	[Required]
	public string? Digest { get; set; }

	// All Meetings
	// TODO: Create SessionMeeting Model
	// public List<CommitteeMeeting> SessionMeetings { get; set; }

	// TODO: Create FloorSessions Model
	// public List<int>? FloorSessionsId { get; set; }
	// public List<FloorSession> FloorSessions { get; set; }

	public List<int>? BillTextIds { get; set; }
	public List<FileWithLabel>? BillTexts { get; set; }

	public List<int>? AdoptedAdmendsmentsId { get; set; }
	public List<FileWithLabel>? AdoptedAdmendments { get; set; }

	// TODO: Create Vote Model
	// public List<int>? VoteIds { get; set; }
	// public List<Vote>? Votes { get; set; }
}
