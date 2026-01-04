using LCB_Clone.Api.Infrastructure.Persistence;
using LCB_Clone.Api.Infrastructure.Persistence.Entities;
using LCB_Clone.Api.Mappings.Legislators;
using LCB_Clone.Api.Mappings.LegislatorStrings;
using LCB_Clone.Api.Services.Interfaces;
using LCB_Clone.Shared.Dtos.Legislators;
using LCB_Clone.Shared.Dtos.LegislatorStrings;
using LCB_Clone.Shared.Dtos.Socials;
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
			.Select(ls => new LegislatorStringsResponseDto(
				ls.Id,
				ls.Text,
				ls.Type,
				ls.LegislatorId,
				new LegislatorResponseDto(
					ls.Legislator!.Id, ls.Legislator!.FirstName,
					ls.Legislator.MiddleName,
					ls.Legislator.LastName,
					ls.Legislator.Party,
					ls.Legislator.County,
					ls.Legislator.Email,
					ls.Legislator.LVOffice,
					ls.Legislator.CCOffice,
					ls.Legislator.CCPhone,
					ls.Legislator.TermEndYear,
					ls.Legislator.Socials.Select(s => new SocialResponseDto(
								s.Id,
								s.Icon,
								s.WebsiteLink,
								s.LegislatorId,
								null
							)).ToList(),
					null
				)))
			.ToListAsync();

		return legislatorStrings;
	}

	public async Task<LegislatorStringsResponseDto?> GetOne(int id)
	{
		LegislatorStringsResponseDto? legislatorString = await _db.LegislatorStrings
			.AsNoTracking()
			.Where(ls => ls.Id == id)
			.Select(ls => new LegislatorStringsResponseDto(
				ls.Id,
				ls.Text,
				ls.Type,
				ls.LegislatorId,
				new LegislatorResponseDto(
					ls.Legislator!.Id, ls.Legislator!.FirstName,
					ls.Legislator.MiddleName,
					ls.Legislator.LastName,
					ls.Legislator.Party,
					ls.Legislator.County,
					ls.Legislator.Email,
					ls.Legislator.LVOffice,
					ls.Legislator.CCOffice,
					ls.Legislator.CCPhone,
					ls.Legislator.TermEndYear,
					ls.Legislator.Socials.Select(s => new SocialResponseDto(
								s.Id,
								s.Icon,
								s.WebsiteLink,
								s.LegislatorId,
								null
							)).ToList(),
					null
				)))
			.FirstOrDefaultAsync();

		if (legislatorString == null)
			return null;

		return legislatorString;
	}


	public async Task<LegislatorStringsResponseDto> Create(LegislatorStringsCreateDto dto)
	{
		LegislatorString legislatorString = dto.ToCreate();

		await _db.LegislatorStrings.AddAsync(legislatorString);
		await _db.SaveChangesAsync();

		return legislatorString.ToResponse();
	}

	public async Task<LegislatorStringsResponseDto?> Update(LegislatorStringsUpdateDto dto)
	{
		LegislatorString? legislatorString = await _db.LegislatorStrings
			.FirstOrDefaultAsync(ls => ls.Id == dto.Id);

		if (legislatorString == null)
			return null;

		dto.ApplyUpdate(legislatorString);

		await _db.SaveChangesAsync();

		return legislatorString.ToResponse();
	}

	public async Task<bool> Delete(int id)
	{
		return await _db.LegislatorStrings.Where(ls => ls.Id == id).ExecuteDeleteAsync() > 0;
	}
}
