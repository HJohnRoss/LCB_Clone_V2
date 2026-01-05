using LCB_Clone.Api.Infrastructure.Persistence;
using LCB_Clone.Api.Infrastructure.Persistence.Entities;
using LCB_Clone.Api.Mappings.Legislators;
using LCB_Clone.Api.Mappings.Socials;
using LCB_Clone.Api.Services.Interfaces;
using LCB_Clone.Shared.Dtos.Socials;
using Microsoft.EntityFrameworkCore;

namespace LCB_Clone.Api.Services;

public class SocialServices(AppDbContext db) : ISocialServices
{
	private readonly AppDbContext _db = db;

	public async Task<List<SocialResponseDto>> GetAll()
	{
		return await _db.Socials
			.AsNoTracking()
			.Select(s => new SocialResponseDto(
						s.Id,
						s.Icon,
						s.WebsiteLink,
						s.LegislatorId,
						s.Legislator.ToResponse()
						))
			.ToListAsync();
	}

	public async Task<SocialResponseDto?> GetOne(int id)
	{
		return await _db.Socials
			.AsNoTracking()
			.Where(s => s.Id == id)
			.Select(s => new SocialResponseDto(
						s.Id,
						s.Icon,
						s.WebsiteLink,
						s.LegislatorId,
						s.Legislator.ToResponse()
						))
			.FirstOrDefaultAsync();
	}

	public async Task<SocialResponseDto?> Create(SocialCreateDto dto)
	{
		Social social = new(
				dto.Icon,
				dto.WebsiteLink,
				dto.LegislatorId
				);

		await _db.Socials.AddAsync(social);

		await _db.SaveChangesAsync();

		return social.ToResponse();
	}

	public async Task<bool> Delete(int id)
	{
		return await _db.Socials.Where(ls => ls.Id == id).ExecuteDeleteAsync() > 0;
	}

	public async Task<bool> Update(SocialUpdateDto dto)
	{
		return await _db.Socials
			.Where(s => s.Id == dto.Id)
			.ExecuteUpdateAsync(setters => setters
					.SetProperty(s => s.Icon, s => dto.Icon ?? s.Icon)
					.SetProperty(s => s.WebsiteLink, s => dto.WebsiteLink ?? s.WebsiteLink)
					.SetProperty(s => s.LegislatorId, s => dto.LegislatorId ?? s.LegislatorId)) > 0;
	}
}
