using LCB_Clone.Api.Endpoints;

namespace LCB_Clone.Api.Infrastructure.Persistence;

public static class MapAllEndpoints
{
	public static void Map(WebApplication app)
	{
		LegislatorEndpoints.MapEndpoints(app);
		LegislatorStringEndpoints.MapEndpoints(app);
		SocialEndpoints.MapEndpoints(app);
	}
}
