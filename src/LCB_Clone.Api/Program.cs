using LCB_Clone.Api.Features.Legislators;
using LCB_Clone.Api.Infrastructure.Extensions;
using LCB_Clone.Api.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

// --- Services ---
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddCorsPolicy();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<GetLegislatorsHandler>();
builder.Services.AddScoped<GetLegislatorByIdHandler>();
builder.Services.AddScoped<CreateLegislatorHandler>();
builder.Services.AddScoped<DeleteLegislatorByIdHandler>();

// --- Build App ---
var app = builder.Build();

// --- Middleware ---
app.UseCorsPolicy();
if (!app.Environment.IsEnvironment("Test"))
{
    app.UseHttpsRedirection();
}
app.UseSwaggerInDevelopment();

// --- Map Feature Endpoints ---
app.MapLegislatorEndpoints();

// --- Run App ---
app.Run();

public partial class Program { }
