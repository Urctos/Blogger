using Aplication;
using Aplication.Interfaces;
using Aplication.Mappings;
using Aplication.Services;
using Domain.Interfaces;
using Infrastructure;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Installers;

public  class MvcInstaller : IInstaller
{
    public void InstallServices(IServiceCollection services, IConfiguration configuration)
    {
        //services.AddScoped<IPostRepository, PostRepository>();
        //services.AddScoped<IPostService, PostService>();
        services.AddApplication();
        services.AddInfrasttructure();
        services.AddControllers();

        services.AddApiVersioning(x =>
        {
            x.DefaultApiVersion = new ApiVersion(1, 0);
            x.AssumeDefaultVersionWhenUnspecified = true;
            x.ReportApiVersions = true;
        });

    }
}

