using LCB_Clone.Api.Infrastructure.Persistence;
using LCB_Clone.Api.Services.Interfaces;
using LCB_Clone.Shared.Dtos.Socials;

namespace LCB_Clone.Api.Services;

public class SocialServices(AppDbContext db) : ISocialServices
{
	private readonly AppDbContext _db = db;

	public Task<List<SocialResponseDto?>> GetAll()
	{
		return null!;
	}

}
