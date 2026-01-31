using LCB_Clone.Shared.Dtos.Legislators;

namespace LCB_Clone.Shared.Validation.Legislators.Interfaces;

public interface ILegislatorUpdateValidator
{
	List<string> ValidateUpdateDto(LegislatorUpdateDto dto);
}
