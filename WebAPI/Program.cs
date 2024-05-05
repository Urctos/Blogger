using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using NLog.Web;
using WebAPI.Installers;
using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;
using Application.Dto;
using HealthChecks.UI.Client;
using Microsoft.OData.Edm;
using NLog;
using WebAPI.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Konfiguracja NLog
var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
builder.Logging.ClearProviders();
builder.Logging.AddConfiguration(builder.Configuration.GetSection("Logging"));
builder.Logging.AddConsole();
builder.Logging.AddDebug();
builder.Host.UseNLog();

// Instalacja us³ug zdefiniowanych w zewnêtrznych instalatorach
builder.Services.InstallServicesInAssembly(builder.Configuration);

// Dodanie kontrolerów i konfiguracja OData
builder.Services.AddControllers().AddOData(opt => opt.Count().Filter().OrderBy().Expand().SetMaxTop(100)
    .AddRouteComponents("odata", GetEdmModel()));

var app = builder.Build();

// Konfiguracja middleware
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI v1"));
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

// U¿ycie middleware do obs³ugi b³êdów
app.UseMiddleware<ErrorHandlingMiddleware>();

// Konfiguracja Health Checks
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapHealthChecks("/health", new HealthCheckOptions
    {
        Predicate = _ => true,
        ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
    });
    endpoints.MapHealthChecksUI();
});

try
{
    app.Run();
}
catch (Exception ex)
{
    logger.Fatal(ex, "API stopped");
    throw;
}
finally
{
    NLog.LogManager.Shutdown();
}

static IEdmModel GetEdmModel()
{
    var builder = new ODataConventionModelBuilder();
    builder.EntitySet<PostDto>("Posts");
    return builder.GetEdmModel();
}
