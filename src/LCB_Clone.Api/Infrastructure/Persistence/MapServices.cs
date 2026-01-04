using LCB_Clone.Api.Infrastructure.Extensions;
using LCB_Clone.Api.Services;
using LCB_Clone.Api.Services.Interfaces;

namespace LCB_Clone.Api.Infrastructure.Persistence;

public static class MapServices
{
	public static void Map(WebApplicationBuilder builder)
	{
		// --- Custom services ---
		builder.Services.AddScoped<ILegislatorService, LegislatorService>();
		builder.Services.AddScoped<ILegislatorStringsServices, LegislatorStringsServices>();
		builder.Services.AddScoped<ISocialServices, SocialServices>();

		// --- Built in ---
		builder.Services.AddPersistence(builder.Configuration);
		builder.Services.AddCorsPolicy();
		builder.Services.AddEndpointsApiExplorer();
		builder.Services.AddSwaggerGen();
	}
}
