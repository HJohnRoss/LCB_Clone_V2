using LCB_Clone.Api.Infrastructure.Persistence;
using LCB_Clone.Api.Infrastructure.Persistence.Entities;
using LCB_Clone.Api.Mappings;
using LCB_Clone.Api.Services.Interfaces;
using LCB_Clone.Shared.Dtos.Legislators;
using Microsoft.EntityFrameworkCore;

namespace LCB_Clone.Api.Services;

public class LegislatorService(AppDbContext db) : ILegislatorService
{
	// Database access
	private readonly AppDbContext _db = db;


	public async Task<List<LegislatorResponseDto>> GetAll()
	{
		List<LegislatorResponseDto> legislators = await _db.Legislators
			// NOTE: .AsNoTracking() increase query speed for get request
			.AsNoTracking()
			// Sql: SELECT * FROM Legislators;
			// l.ToResponse() = converts a Legislator object to LegislatorResponseDto
			.Select(l => l.ToResponse())
			// Makes the List<LegislatorResponseDto>
			.ToListAsync();

		return legislators;
	}

	// Legislator Get One
	// @params (int id)
	public async Task<LegislatorResponseDto?> GetOne(int id)
	{
		LegislatorResponseDto? legislator = await _db.Legislators
			// NOTE: .AsNoTracking() increase query speed for get request
			.AsNoTracking()
			// Sql: Where Legislator.Id = Id;
			.Where(l => l.Id == id)
			// Sql: Select * from Legislators
			// l.ToResponse() = converts a Legislator object to LegislatorResponseDto
			.Select(l => l.ToResponse())
			// Takes the query output and gives a LegislatorResponseDto?
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
}
