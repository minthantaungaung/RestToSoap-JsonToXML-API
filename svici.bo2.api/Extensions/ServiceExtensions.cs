using svici.bo2.application.Services;
using svici.bo2.core.Data;
using svici.bo2.core.Dtos;
using svici.bo2.core.IServices;
using svici.bo2.persistence.Database;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Http;
using Serilog;
using System;
using svici.bo2.core.IServices.Common;
using svici.bo2.application.Services.Common;
using svici.bo2.api.Extensions.ActionFilters;

namespace svici.bo2.api.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureAppSetting(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ThirdPartySettings>(configuration.GetSection("ThirdPartySettings"));

            //Serilog
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            Log.Logger = new LoggerConfiguration()
            .Enrich.FromLogContext()
            .Enrich.WithEnvironmentName()
            .WriteTo.Debug()
            .WriteTo.Console()
            .Enrich.WithProperty("Environment", environment!)
            .ReadFrom.Configuration(configuration)
            .CreateLogger();
        }

        public static void ConfigureServiceResolver(this IServiceCollection services)
        {
            //Logger Services
            services.AddSingleton<ILoggerManager, LoggerManager>();
            services.AddSingleton(Log.Logger);

            //API Services
            //services.AddScoped<ICommonService, CommonService>();

            //Custom Action Filters
            services.AddScoped<GetKbzRefNoNTokenActionFilter>();
            services.AddScoped<RequestValidationActionFilter>();
        }
    }
}
