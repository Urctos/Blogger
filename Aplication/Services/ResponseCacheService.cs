using Application.Interfaces;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ResponseCacheService : IResponseCacheService
    {
        private readonly IDistributedCache _distributedCahce;

        public ResponseCacheService(IDistributedCache distributedCahce)
        {
            _distributedCahce = distributedCahce;
        }
        public async Task CacheResponseAsync(string cacheKey, object response, TimeSpan timeLive)
        {
            if (response == null)
            {
                return;
            }

            var serializedResponse = JsonConvert.SerializeObject(response);
            await _distributedCahce.SetStringAsync(cacheKey, serializedResponse, new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = timeLive
            });
        }

        public async Task<string> GetChacheResponseAsync(string cacheKey)
        {
            var cacheResponse = await _distributedCahce.GetStringAsync(cacheKey);
            return string.IsNullOrEmpty(cacheResponse) ? null : cacheResponse;
        }
    }
}
