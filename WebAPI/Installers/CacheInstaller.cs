
using Application.Interfaces;
using Application.Services;
using WebAPI.Cache;

namespace WebAPI.Installers
{
    public class CacheInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration Configuration)
        {
            var redisCacheSettings = new RedisCacheSettings();
            Configuration.GetSection(nameof(RedisCacheSettings)).Bind(redisCacheSettings);
            services.AddSingleton(redisCacheSettings);

            if(!redisCacheSettings.Enabled)
            {
                return;
            }

            services.AddStackExchangeRedisCache(options => options.Configuration = redisCacheSettings.ConectionString);
            services.AddSingleton<IResponseCacheService, ResponseCacheService>();
        }
    }
}
