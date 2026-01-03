using LCB_Clone.Shared.Dtos.LegislatorStrings;

namespace LCB_Clone.Api.Services.Interfaces;

public interface ILegislatorStringsServices
{
	Task<List<LegislatorStringsResponseDto>> GetAll();
	Task<LegislatorStringsResponseDto?> GetOne(ulong id);
	Task<LegislatorStringsResponseDto> Create(LegislatorStringsCreateDto dto);
	Task<LegislatorStringsResponseDto?> Update(LegislatorStringsUpdateDto dto);
	Task<bool> Delete(ulong id);
}
