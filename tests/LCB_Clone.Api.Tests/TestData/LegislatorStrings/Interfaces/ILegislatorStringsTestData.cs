using LCB_Clone.Shared.Dtos.LegislatorStrings;

namespace LCB_Clone.Api.Tests.TestData.LegislatorStrings.Interfaces;

public interface ILegislatorStringsTestData
{
	Task<LegislatorStringsResponseDto> CreateLegislatorStringAsync();
}
