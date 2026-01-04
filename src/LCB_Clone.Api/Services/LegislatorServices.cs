using LCB_Clone.Api.Infrastructure.Persistence;
using LCB_Clone.Api.Infrastructure.Persistence.Entities;
using LCB_Clone.Api.Mappings.Legislators;
using LCB_Clone.Api.Mappings.LegislatorStrings;
using LCB_Clone.Api.Mappings.Socials;
using LCB_Clone.Api.Services.Interfaces;
using LCB_Clone.Shared.Dtos.Legislators;
using LCB_Clone.Shared.Dtos.LegislatorStrings;
using LCB_Clone.Shared.Dtos.Socials;
using Microsoft.EntityFrameworkCore;

namespace LCB_Clone.Api.Services;

public class LegislatorService(AppDbContext db) : ILegislatorService
{
	// Database access
	private readonly AppDbContext _db = db;


	public async Task<List<LegislatorResponseDto>> GetAll()
	{
		List<LegislatorResponseDto> legislators = await _db.Legislators
			.AsNoTracking()
			.Select(l => new LegislatorResponseDto(
				l.Id,
				l.FirstName,
				l.MiddleName,
				l.LastName,
				l.Party,
				l.County,
				l.Email,
				l.LVOffice,
				l.CCOffice,
				l.CCPhone,
				l.TermEndYear,
				l.Socials.Select(s => new SocialResponseDto(
					s.Id,
					s.Icon,
					s.WebsiteLink,
					s.LegislatorId,
					null
				)).ToList(),
				l.LegislatorStrings.Select(ls => new LegislatorStringsResponseDto(
					ls.Id,
					ls.Text,
					ls.Type,
					ls.LegislatorId,
					null
				)).ToList()
			))
			.ToListAsync();

		return legislators;
	}

	// Legislator Get One
	// @params (int id)
	public async Task<LegislatorResponseDto?> GetOne(int id)
	{
		LegislatorResponseDto? legislator = await _db.Legislators
			.AsNoTracking()
			.Where(l => l.Id == id)
			.Select(l => new LegislatorResponseDto(
				l.Id,
				l.FirstName,
				l.MiddleName,
				l.LastName,
				l.Party,
				l.County,
				l.Email,
				l.LVOffice,
				l.CCOffice,
				l.CCPhone,
				l.TermEndYear,
				l.Socials.Select(s => new SocialResponseDto(
					s.Id,
					s.Icon,
					s.WebsiteLink,
					s.LegislatorId,
					null
				)).ToList(),
				l.LegislatorStrings.Select(ls => new LegislatorStringsResponseDto(
					ls.Id,
					ls.Text,
					ls.Type,
					ls.LegislatorId,
					null
				)).ToList()
			))
			.FirstOrDefaultAsync();

		return legislator;
	}

	public async Task<LegislatorResponseDto?> Create(LegislatorCreateDto dto)
	{
		// Takes a DTO object input to create a Legislator with its constructor
		Legislator legislator = new(
			dto.FirstName,
			dto.MiddleName,
			dto.LastName,
			dto.Party,
			dto.County,
			dto.Email,
			dto.LVOffice,
			dto.CCOffice,
			dto.CCPhone,
			dto.TermEndYear
		)
		{
			FirstName = dto.FirstName,
			LastName = dto.LastName,
			Party = dto.Party,
			County = dto.County,
			Email = dto.Email,
			TermEndYear = dto.TermEndYear
		};

		// Adding the new Legislator object to the database
		await _db.Legislators.AddAsync(legislator);
		// Saving the changes to the database
		await _db.SaveChangesAsync();

		// Converts the legislator object into a LegislatorResponseDto and returns it.
		return legislator.ToResponse();
	}

	public async Task<bool> Delete(int id)
	{
		return await _db.Legislators.Where(l => l.Id == id).ExecuteDeleteAsync() > 0;
	}

	public async Task<LegislatorResponseDto?> Update(LegislatorUpdateDto dto)
	{
		Legislator? legislator = await _db.Legislators
			.FirstOrDefaultAsync(l => l.Id == dto.Id);

		if (legislator == null)
			return null;

		dto.ApplyUpdate(legislator);

		await _db.SaveChangesAsync();

		return legislator.ToResponse();
	}
}
