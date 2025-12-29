using DotNetEnv;

using LCB_Clone.Api.Infrastructure.Extensions;

// --- env variables ---
Env.Load();

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add controllers
builder.Services.AddControllers();

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
