using LCB_Clone.Shared.Dtos.LegislatorStrings;

namespace LCB_Clone.Api.Services.Interfaces;

public interface ILegislatorStringsServices
{
	Task<List<LegislatorStringsResponseDto>> GetAll();
	Task<LegislatorStringsResponseDto?> GetOne(int id);
	Task<LegislatorStringsResponseDto> Create(LegislatorStringsCreateDto dto);
	Task<bool> Update(LegislatorStringsUpdateDto dto);
	Task<bool> Delete(int id);
}
