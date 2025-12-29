using LCB_Clone.Shared.Dtos.LegislatorStrings;

namespace LCB_Clone.Api.Services.Interfaces;

public interface ILegislatorStringsServices
{
	List<LegislatorStringsResponseDto> GetAll();
}
