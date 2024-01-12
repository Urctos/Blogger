using Application.Interfaces;
using Application.Mappings;
using Application.Services;
using Domain.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using WebAPI.Installers;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

//var builder = WebApplication.CreateBuilder(args);

//var mvcInstaller = new MvcInstaller();
//mvcInstaller.InstallServices(builder.Services, builder.Configuration);

////builder.Services.AddSingleton(AutoMapperConfig.Initialize());
////builder.Services.AddControllers();
////builder.Services.AddDbContext<BloggerContext>(options =>
////    options.UseSqlServer(builder.Configuration.GetConnectionString("BloggerCS")));

////builder.Services.AddSwaggerConfiguration(); 
//var app = builder.Build();
////app.UseSwaggerConfiguration();

//app.UseHttpsRedirection();
//app.MapControllers();

//app.Run();
