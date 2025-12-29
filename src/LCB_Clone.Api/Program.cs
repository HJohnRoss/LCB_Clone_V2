using DotNetEnv;

using LCB_Clone.Api.Infrastructure.Extensions;
using LCB_Clone.Api.Services;
using LCB_Clone.Api.Services.Interfaces;

// --- env variables ---
Env.Load();

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add controllers
builder.Services.AddControllers();

// Add Services
builder.Services.AddScoped<ILegislatorService, LegislatorService>();

// --- Services ---
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddCorsPolicy();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// --- API Routes ---

// --- Build App ---
WebApplication app = builder.Build();

// --- Middleware ---
app.UseCorsPolicy();
if (!app.Environment.IsEnvironment("Test"))
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

// --- Controllers ---
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// --- Run App ---
app.Run();

public partial class Program { }
