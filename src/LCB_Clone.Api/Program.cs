using DotNetEnv;

using LCB_Clone.Api.Infrastructure.Extensions;
using LCB_Clone.Api.Infrastructure.Persistence;

// Only load API .env when NOT running tests
if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") != "Test")
{
	Env.Load();
}

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// -- Services --
MapServices.Map(builder);

// --- Build App ---
WebApplication app = builder.Build();

// --- Maps Endpoints ---
MapAllEndpoints.Map(app);

// --- Middleware ---
app.UseCorsPolicy();
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

app.Run();

public partial class Program { }

