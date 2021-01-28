using Lesson4Project.Configurations;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson4Project.Services
{
    public class FileService:IFileService
    {
        private static string cacheKey = $"image_{DateTime.UtcNow:yyyy_mm_dd}";
        private readonly InfestationCacheConfiguration _cacheConfiguration;
        private readonly IMemoryCache _cache;

        public FileService(IMemoryCache cache, IOptions<InfestationCacheConfiguration> options)
        {
            _cache = cache;
            _cacheConfiguration = options.Value;
        }
            
        public byte[] GetFileFromCache(string fileName)
        {
            var result = _cache.Get<byte[]>(fileName+cacheKey);
            return result;
        }

        public void SetToCache(byte[] clientFile, string fileName)
        {
            var options = new MemoryCacheEntryOptions();
            options.SlidingExpiration = TimeSpan.FromMinutes(_cacheConfiguration.cacheExpireTime);
            _cache.Set<byte[]>(fileName+cacheKey, clientFile, options);
        }
    }
}
