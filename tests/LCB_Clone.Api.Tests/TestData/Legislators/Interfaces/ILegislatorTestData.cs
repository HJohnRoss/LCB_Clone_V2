using LCB_Clone.Shared.Dtos.Legislators;

namespace LCB_Clone.Api.Tests.TestData.Legislators.Interfaces;

public interface ILegislatorTestData
{
	Task<LegislatorResponseDto> CreateLegislatorAsync();
}
