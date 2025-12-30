using LCB_Clone.Shared.Dtos.LegislatorStrings;

namespace LCB_Clone.Api.Services.Interfaces;

public interface ILegislatorStringsServices
{
	Task<List<LegislatorStringsResponseDto>> GetAll();
	// Task<LegislatorStringsResponseDto> Create(LegislatorStringsCreateDto dto);
}
