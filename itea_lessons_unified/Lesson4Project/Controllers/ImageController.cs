using Lesson4Project.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson4Project.Controllers
{
    public class ImageController : Controller
    {
        private readonly IRestApiExampleClient _client;
        private readonly IMemoryCache _memoryCache;

        public ImageController(IRestApiExampleClient client, IMemoryCache cache)
        {
            _client = client;
            _memoryCache = cache;
        }
        public IActionResult Get()
        {
            var cachekey = $"image_{DateTime.UtcNow:yyyy_MM_dd}";
            var imageBytes = _memoryCache.Get<byte[]>(cachekey);
            if(imageBytes==null)
            {
                imageBytes = _client.GetFileBytes();
                var options = new MemoryCacheEntryOptions();
                options.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(2);

                _memoryCache.Set<byte[]>(cachekey, imageBytes, options);
            }
            return new FileContentResult(imageBytes, "image/jpeg");
        }
    }
}
