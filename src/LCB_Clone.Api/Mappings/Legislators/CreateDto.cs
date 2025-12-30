using LCB_Clone.Api.Infrastructure.Persistence.Entities;
using LCB_Clone.Shared.Dtos.Legislators;

namespace LCB_Clone.Api.Mappings.Legislators;

public static class CreateDtoMappings
{
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
}
