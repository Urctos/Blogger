using Aplication;
using Aplication.Interfaces;
using Aplication.Mappings;
using Aplication.Services;
using Domain.Interfaces;
using Infrastructure;
using Infrastructure.Repositories;

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

    }
}

