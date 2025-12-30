using LCB_Clone.Api.Infrastructure.Persistence;
using LCB_Clone.Api.Infrastructure.Persistence.Entities;
using LCB_Clone.Api.Mappings.LegislatorStrings;
using LCB_Clone.Api.Services.Interfaces;
using LCB_Clone.Shared.Dtos.LegislatorStrings;
using Microsoft.EntityFrameworkCore;

namespace LCB_Clone.Api.Services;

public class LegislatorStringsServices(AppDbContext db) : ILegislatorStringsServices
{
	// Database Access
	private readonly AppDbContext _db = db;

	public async Task<List<LegislatorStringsResponseDto>> GetAll()
	{
		List<LegislatorStringsResponseDto> legislatorStrings = await _db.LegislatorStrings
			.AsNoTracking()
			.Select(ls => ls.ToResponse())
			.ToListAsync();

		return legislatorStrings;
	}

	// public async Task<LegislatorStringsResponseDto> Create(LegislatorStringsCreateDto dto)
	// {
	// 	LegislatorStrings legislatorString = new(
	// 			dto.Text,
	// 			dto.Type,
	// 			dto.LegislatorId
	// 			);
	// }

}
