using DotNetEnv;

using LCB_Clone.Api.Infrastructure.Extensions;
using LCB_Clone.Api.Infrastructure.Persistence;

// --- env variables ---
Env.Load();

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// -- Services --
MapServices.Map(builder);

// --- Build App ---
WebApplication app = builder.Build();

// --- Maps Endpoints ---
MapAllEndpoints.Map(app);

// --- Middleware ---
app.UseCorsPolicy();
if (!app.Environment.IsEnvironment("Test"))
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// --- Run App ---
app.Run();

public partial class Program { }
