using LCB_Clone.Api.Infrastructure.Persistence;
using LCB_Clone.Api.Services.Interfaces;
using LCB_Clone.Shared.Dtos.LegislatorStrings;

namespace LCB_Clone.Api.Services;

public class LegislatorStringsServices(AppDbContext db) : ILegislatorStringsServices
{
	// Database Access
	private readonly AppDbContext _db = db;

	public List<LegislatorStringsResponseDto> GetAll()
	{
		return null!;
	}
}
