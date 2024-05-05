using Application;
using Application.Services;
using Application.Validators;
using FluentValidation.AspNetCore;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.OData;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using WebAPI.Middelwares;

namespace WebAPI.Installers;

public class MvcInstaller : IInstaller
{
    public void InstallServices(IServiceCollection services, IConfiguration Configuration)
    {
        services.AddApplication();
        services.AddInfrastructure();

        services.AddMemoryCache();

        services.AddControllers()
            .AddFluentValidation(options =>
            {
                options.RegisterValidatorsFromAssemblyContaining<CreatePostDtoValidator>();
            })
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.WriteIndented = true;
            })
            .AddXmlSerializerFormatters();

        //services.AddAuthentication();
        services.AddAuthorization();

        services.TryAddTransient<UserResolverService>();
        services.AddScoped<ErrorHandlingMiddelware>();

        services.AddApiVersioning(x =>
        {
            x.DefaultApiVersion = new ApiVersion(1, 0);
            x.AssumeDefaultVersionWhenUnspecified = true;
            x.ReportApiVersions = true;
            //x.ApiVersionReader = new HeaderApiVersionReader("x-api-version");
        });

    }

}

