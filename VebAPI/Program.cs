using Aplication.Interfaces;
using Aplication.Mappings;
using Aplication.Services;
using Domain.Interfaces;
using Infrastructure.Repositories;
using Microsoft.OpenApi.Models;
using WebAPI.Installers;



var builder = WebApplication.CreateBuilder(args);

var mvcInstaller = new MvcInstaller();
mvcInstaller.InstallServices(builder.Services, builder.Configuration);

//builder.Services.AddSingleton(AutoMapperConfig.Initialize());
//builder.Services.AddControllers();


builder.Services.AddSwaggerConfiguration(); 
var app = builder.Build();
app.UseSwaggerConfiguration();

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
