using LCB_Clone.Api.Infrastructure.Persistence.Entities;
using LCB_Clone.Shared.Dtos.Legislators;

namespace LCB_Clone.Api.Mappings;

// 	public static LegislatorResponseDto ToResponse(this Legislator legislator)
// 	"this" keyword is making the function an extension method of the Legislator class.

// Extention Utility Class for Legislators
public static class LegislatorMappings
{
	// Converts a Legislator into a LegislatorResponseDto
	public static LegislatorResponseDto ToResponse(this Legislator legislator)
	{
		if (legislator == null)
		{
			return null!;
		}

		return new LegislatorResponseDto(
				legislator.FirstName,
				legislator.MiddleName,
				legislator.LastName,
				legislator.Party,
				legislator.County,
				legislator.Email,
				legislator.LVOffice,
				legislator.CCOffice,
				legislator.CCPhone,
				legislator.TermEndYear,
				legislator.Socials?.Select(s => s.ToResponse()).ToList(),
				legislator.LegislatorStrings?.Select(ls => ls.ToResponse()).ToList()
				);
	}

	public static LegislatorCreateDto ToCreate(this Legislator legislator)
	{
		// NOTE: For required feilds you have to either specify to the constructor what feild is the what
		// or you can put [SetsRequiredMembers] on the function to tell the compiler this is ok.
		// However I dont know how safe it is to use the [SetsRequiredMembers].
		return new LegislatorCreateDto(
				legislator.FirstName,
				legislator.MiddleName,
				legislator.LastName,
				legislator.Party,
				legislator.County,
				legislator.Email,
				legislator.LVOffice,
				legislator.CCOffice,
				legislator.CCPhone,
				legislator.TermEndYear
				)
		{
			// Specifying the [Required] class property's
			FirstName = legislator.FirstName,
			LastName = legislator.LastName,
			Party = legislator.Party,
			County = legislator.County,
			Email = legislator.Email,
			TermEndYear = legislator.TermEndYear
		};
	}

	public static LegislatorUpdateDto ToUpdate(this Legislator legislator)
	{
		return new LegislatorUpdateDto(
				legislator.Id,
				legislator.FirstName,
				legislator.MiddleName,
				legislator.LastName,
				legislator.Party,
				legislator.County,
				legislator.Email,
				legislator.LVOffice,
				legislator.CCOffice,
				legislator.CCPhone,
				legislator.TermEndYear
				)
		{
			// Specifying the [Required] class property's
			Id = legislator.Id
		};
	}
}
