
using Microsoft.OpenApi.Models;

namespace WebAPI.Installers
{
    public class SwaggerInstaller : IInstaller
    {

        public void InstallServices(IServiceCollection services, IConfiguration Configuration)
        {
            services.AddSwaggerGen(c =>
            {
                c.EnableAnnotations();
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPI", Version = "v1" });
            });
        }


        //public static void AddSwaggerConfiguration(this IServiceCollection services)
        //{
        //    services.AddEndpointsApiExplorer();
        //    services.AddSwaggerGen(c =>
        //    {
        //        c.EnableAnnotations();
        //        c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPI", Version = "v1" });
        //    });
        //}

        //public static void UseSwaggerConfiguration(this IApplicationBuilder app)
        //{
        //    app.UseSwagger();
        //    app.UseSwaggerUI(c =>
        //        c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI v1"));
        //}
    }
}
