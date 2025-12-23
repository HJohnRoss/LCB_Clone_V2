using LCB_Clone.Api.Features.Legislators;
using LCB_Clone.Api.Infrastructure.Extensions;
using LCB_Clone.Api.Infrastructure.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LCB_Clone.Api
{
    public class Program
    {
        public static WebApplication CreateWebApplication(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Services
            builder.Services.AddPersistence(builder.Configuration);
            builder.Services.AddCorsPolicy();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<GetLegislatorsHandler>();
            builder.Services.AddScoped<GetLegislatorByIdHandler>();
            builder.Services.AddScoped<CreateLegislatorHandler>();
            builder.Services.AddScoped<DeleteLegislatorByIdHandler>();

            var app = builder.Build();

            // Middleware
            app.UseCorsPolicy();
            app.UseHttpsRedirection();
            app.UseSwaggerInDevelopment();

            // Map endpoints
            app.MapLegislatorEndpoints();

            return app;
        }

        public static void Main(string[] args)
        {
            var app = CreateWebApplication(args);
            app.Run();
        }
    }
}
