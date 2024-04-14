using WebAPI.Installers;
using Microsoft.AspNetCore.OData;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using WebAPI.Middelwares;
using Application.Dto;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.OData.ModelBuilder.Core.V1;
using Microsoft.OData.Edm.Vocabularies;
using Newtonsoft.Json;
using WebAPI.HealthChecks;
using HealthChecks.UI.Client;

namespace WebAPI;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        services.InstallServicesInAssembly(Configuration);
        services.AddControllers().AddOData(opt => opt.Count().Filter().OrderBy().Expand().SetMaxTop(100)
                                 .AddRouteComponents("odata", GetEdmModel()));
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI v1"));
        }

        app.UseMiddleware<ErrorHandlingMiddelware>();

        //app.UseHealthChecks("/health", new HealthCheckOptions
        //{
        //    ResponseWriter = async (contex, report) =>
        //    {
        //        contex.Response.ContentType = "application/json";

        //        var response = new HealthCheckResponse
        //        {
        //            Status = report.Status.ToString(),
        //            Checks = report.Entries.Select(x => new HealthCheck
        //            {
        //                Component = x.Key,
        //                Status = x.Value.Status.ToString(),
        //                Description = x.Value.Description
        //            }),
        //            Duration = report.TotalDuration
        //        };
        //        await contex.Response.WriteAsync(JsonConvert.SerializeObject(response));
        //    }
        //});



        app.UseHttpsRedirection();

        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
            endpoints.MapHealthChecks("/health", new HealthCheckOptions()
            {
                Predicate = _ => true,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });
            endpoints.MapHealthChecksUI();

        });
    }
    public static IEdmModel GetEdmModel()
    {
        var builder = new ODataConventionModelBuilder();
        builder.EntitySet<PostDto>("Posts");
        return builder.GetEdmModel();
    }
}



