using LCB_Clone.Shared.Dtos.LegislatorStrings;

namespace LCB_Clone.Shared.Validation.LegislatorStrings.Interfaces;

public interface ILegislatorStringsCreateValidator
{
	List<string> ValidateCreateLegislatorStrings(LegislatorStringsCreateDto dto);
}
