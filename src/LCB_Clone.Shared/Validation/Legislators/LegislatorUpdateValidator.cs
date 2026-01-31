using LCB_Clone.Shared.Dtos.Legislators;
using LCB_Clone.Shared.Validation.Legislators.Interfaces;

using static LCB_Clone.Shared.Validation.Helpers.ValidationHelpers;

namespace LCB_Clone.Shared.Validation.Legislators;

public class LegislatorUpdateValidator : ILegislatorUpdateValidator
{
	public List<string> ValidateUpdateDto(LegislatorUpdateDto dto)
	{
		List<string> errors = [];

		// Strings
		if (dto.FirstName != null && dto.FirstName.Length == 0)
			errors.Add("First Name is required");
		if (dto.LastName != null && dto.LastName.Length == 0)
			errors.Add("Last Name is required");
		if (dto.Party != null && dto.Party.Length == 0)
			errors.Add("Party is required");
		if (dto.Email != null && dto.Email.Length == 0)
			errors.Add("Email is required");

		// Ints
		if (dto.County != null && dto.County <= 0)
			errors.Add("County is invalid");
		if (dto.TermEndYear != null && dto.TermEndYear > 1865 && dto.TermEndYear < 3000)
			errors.Add("Term End Year is invalid");

		// IsValidEmail() - Helper function
		if (dto.Email != null && IsValidEmail(dto.Email))
			errors.Add("Eamil is invalid");

		return errors;
	}
}
