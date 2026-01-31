using LCB_Clone.Shared.Dtos.LegislatorStrings;

namespace LCB_Clone.Shared.Validation.LegislatorStrings.Interfaces;

public interface ILegislatorStringsUpdateValidator
{
	List<string> ValidateUpdateLegislatorStrings(LegislatorStringsUpdateDto dto);
}
