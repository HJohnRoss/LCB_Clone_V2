using LCB_Clone.Shared.Dtos.LegislatorStrings;
using LCB_Clone.Shared.Validation.LegislatorStrings.Interfaces;
using static LCB_Clone.Shared.Validation.Helpers.ValidationHelpers;

namespace LCB_Clone.Shared.Validation.LegislatorStrings;

public class LegislatorStringCreateValidator : ILegislatorStringsCreateValidator
{
	public List<string> ValidateCreateLegislatorStrings(LegislatorStringsCreateDto dto)
	{
		List<string> errors = [];

		// Strings
		RequireNonEmpty(dto.Text, "Text", errors);

		// int
		if (dto.LegislatorId == null)
			errors.Add("Legislator Id is required");

		return errors;
	}
}
