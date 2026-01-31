using LCB_Clone.Shared.Dtos.Legislators;
using LCB_Clone.Shared.Enums.Chambers;
using LCB_Clone.Shared.Validation.Legislators.Interfaces;
using static LCB_Clone.Shared.Validation.Helpers.ValidationHelpers;

namespace LCB_Clone.Shared.Validation.Legislators;

public class LegisaltorCreateValidator : ILegislatorCreateValidator
{
	public List<string> ValidateCreateLegislator(LegislatorCreateDto dto)
	{
		List<string> errors = [];

		// RequireNonEmpty - Helper function
		RequireNonEmpty(dto.FirstName, "First Name", errors);
		RequireNonEmpty(dto.LastName, "Last Name", errors);
		RequireNonEmpty(dto.Party, "Party", errors);
		RequireNonEmpty(dto.Email, "Email", errors);

		if (dto.County <= 0)
			errors.Add("County is required");

		if (dto.TermEndYear < 1865 || dto.TermEndYear > 3000)
			errors.Add("Term End Year is invalid");

		// IsValidEmail - Helper function
		if (!IsValidEmail(dto.Email))
			errors.Add("Email is invalid");

		if (!Enum.IsDefined(typeof(Chamber), dto.Chamber))
			errors.Add("Chamber is invalid");

		if (dto.CCPhone != null && dto.CCPhone.Length > 25)
			errors.Add("CC Phone is too long");

		return errors;
	}
}
