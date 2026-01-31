using LCB_Clone.Api.Infrastructure.Extensions;
using LCB_Clone.Api.Services;
using LCB_Clone.Api.Services.Interfaces;
using LCB_Clone.Shared.Validation.Legislators;
using LCB_Clone.Shared.Validation.Legislators.Interfaces;

namespace LCB_Clone.Api.Infrastructure.Persistence;

public static class MapServices
{
	public static void Map(WebApplicationBuilder builder)
	{
		// --- Custom services ---
		builder.Services.AddScoped<ILegislatorService, LegislatorService>();
		builder.Services.AddScoped<ILegislatorStringsServices, LegislatorStringsServices>();
		builder.Services.AddScoped<ISocialServices, SocialServices>();

		// --- Validations ---
		builder.Services.AddScoped<ILegislatorCreateValidator, LegisaltorCreateValidator>();
		builder.Services.AddScoped<ILegislatorUpdateValidator, LegislatorUpdateValidator>();

		// --- Built in ---
		builder.Services.AddPersistence(builder.Configuration);
		builder.Services.AddCorsPolicy();
		builder.Services.AddEndpointsApiExplorer();
		builder.Services.AddSwaggerGen();
	}
}
