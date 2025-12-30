using LCB_Clone.Shared.Dtos.Legislators;

namespace LCB_Clone.Api.Services.Interfaces;

public interface ILegislatorService
{
	Task<List<LegislatorResponseDto>> GetAll();
	Task<LegislatorResponseDto?> GetOne(int id);
	Task<LegislatorResponseDto?> Create(LegislatorCreateDto dto);
	Task<bool> Delete(int id);
}
