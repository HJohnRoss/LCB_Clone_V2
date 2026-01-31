using LCB_Clone.Shared.Dtos.Legislators;

namespace LCB_Clone.Shared.Validation.Legislators.Interfaces;

public interface ILegislatorCreateValidator
{
	List<string> ValidateCreateLegislator(LegislatorCreateDto dto);
}
