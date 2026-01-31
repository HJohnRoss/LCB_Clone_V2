using LCB_Clone.Shared.Dtos.LegislatorStrings;
using LCB_Clone.Shared.Validation.LegislatorStrings.Interfaces;

namespace LCB_Clone.Shared.Validation.LegislatorStrings;

public class LegislatorStringUpdateValidator : ILegislatorStringsUpdateValidator
{
	public List<string> ValidateUpdateLegislatorStrings(LegislatorStringsUpdateDto dto)
	{
		List<string> errors = [];

		if (dto.Text != null && dto.Text.Length == 0)
			errors.Add("Text is required");

		if (dto.LegislatorId != null && dto.LegislatorId < 0)
			errors.Add("Legislator Id is invalid");

		return errors;
	}
}
