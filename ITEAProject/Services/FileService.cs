using ITEAProject.Configurations;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITEAProject.Services
{
    public class FileService:IFileService
    {
        
        private readonly CacheConfiguration _cacheConfiguration;
        private readonly IMemoryCache _cache;
        private static string _cacheKey;
        private static string _imageName;

        public FileService(IMemoryCache cache, IOptions<CacheConfiguration> options)
        {
            _cache = cache;
            _cacheConfiguration = options.Value;
            _cacheKey = _cacheConfiguration.cacheKey;
            _imageName = _cacheConfiguration.imageName;
        }
            
        public byte[] GetFileFromCache()
        {
            var result = _cache.Get<byte[]>(_imageName + _cacheKey);
            return result;
        }

        public void SetToCache(byte[] clientFile)
        {
            var options = new MemoryCacheEntryOptions();
            options.SlidingExpiration = TimeSpan.FromMinutes(_cacheConfiguration.cacheExpireTime);
            _cache.Set<byte[]>(_imageName + _cacheKey, clientFile, options);
        }
    }
}
