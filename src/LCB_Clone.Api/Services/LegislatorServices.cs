using LCB_Clone.Api.Infrastructure.Persistence;
using LCB_Clone.Api.Services.Interfaces;
using LCB_Clone.Shared.Dtos.Legislators;
using LCB_Clone.Shared.Dtos.LegislatorStrings;
using LCB_Clone.Shared.Dtos.Socials;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LCB_Clone.Api.Services;

public class LegislatorService(AppDbContext db) : ILegislatorService
{
	private readonly AppDbContext _db = db;


	public async Task<List<LegislatorResponseDto>> GetAll()
	{
		List<LegislatorResponseDto> legislators = await _db.Legislators.Select(l => new LegislatorResponseDto(
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
			l.Socials.Select(s => new SocialResponseDto(s.Icon, s.WebsiteLink)).ToList(),
			l.LegislatorStrings.Select(ls => new LegislatorStringsResponseDto(ls.Text, ls.Type)).ToList()
		))
		.ToListAsync();

		return legislators;
	}
}
