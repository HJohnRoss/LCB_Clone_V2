namespace LCB_Clone.Api.Infrastructure.Extensions;

public static class MiddlewareExtensions
{
	// CORS registration
	public static IServiceCollection AddCorsPolicy(this IServiceCollection services)
	{
		// Allows Client connectivity to API
		services.AddCors(options =>
		{
			options.AddDefaultPolicy(policy =>
				// Allows any address/endpoint to access the API
				// WARNING: Change this for production
				policy.AllowAnyOrigin()
					  .AllowAnyHeader()
					  .AllowAnyMethod());
		});

		return services;
	}

	// Apply CORS middleware
	public static IApplicationBuilder UseCorsPolicy(this WebApplication app)
	{
		app.UseCors();
		return app;
	}

	// Swagger only in development
	public static IApplicationBuilder UseSwaggerInDevelopment(this WebApplication app)
	{
		if (app.Environment.IsDevelopment())
		{
			app.UseSwagger();
			app.UseSwaggerUI();
		}

		return app;
	}
}

