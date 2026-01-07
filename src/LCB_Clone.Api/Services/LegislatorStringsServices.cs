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
				new LegislatorResponseDto
				{
					Id = ls.Legislator!.Id,
					FirstName = ls.Legislator!.FirstName,
					MiddleName = ls.Legislator.MiddleName,
					LastName = ls.Legislator.LastName,
					Party = ls.Legislator.Party,
					County = ls.Legislator.County,
					Email = ls.Legislator.Email,
					LVOffice = ls.Legislator.LVOffice,
					CCOffice = ls.Legislator.CCOffice,
					CCPhone = ls.Legislator.CCPhone,
					TermEndYear = ls.Legislator.TermEndYear,
					Socials = ls.Legislator.Socials.Select(s => new SocialResponseDto(
								s.Id,
								s.Icon,
								s.WebsiteLink,
								s.LegislatorId,
								null
							)).ToList(),
				}))
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
				new LegislatorResponseDto
				{
					Id = ls.Legislator!.Id,
					FirstName = ls.Legislator!.FirstName,
					MiddleName = ls.Legislator.MiddleName,
					LastName = ls.Legislator.LastName,
					Party = ls.Legislator.Party,
					County = ls.Legislator.County,
					Email = ls.Legislator.Email,
					LVOffice = ls.Legislator.LVOffice,
					CCOffice = ls.Legislator.CCOffice,
					CCPhone = ls.Legislator.CCPhone,
					TermEndYear = ls.Legislator.TermEndYear,
					Socials = ls.Legislator.Socials.Select(s => new SocialResponseDto(
								s.Id,
								s.Icon,
								s.WebsiteLink,
								s.LegislatorId,
								null
							)).ToList(),
				}))
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

	public async Task<bool> Update(LegislatorStringsUpdateDto dto)
	{
		return await _db.LegislatorStrings
			.Where(ls => ls.Id == dto.Id)
			.ExecuteUpdateAsync(setters => setters
					.SetProperty(ls => ls.Text, ls => dto.Text ?? ls.Text)
					.SetProperty(ls => ls.Type, ls => dto.Type ?? ls.Type)
					.SetProperty(ls => ls.LegislatorId, ls => dto.LegislatorId ?? ls.LegislatorId)) > 0;
	}

	public async Task<bool> Delete(int id)
	{
		return await _db.LegislatorStrings.Where(ls => ls.Id == id).ExecuteDeleteAsync() > 0;
	}
}
