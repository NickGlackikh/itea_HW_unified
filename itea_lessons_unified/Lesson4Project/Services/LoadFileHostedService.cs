using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Lesson4Project.Services
{
    public class LoadFileHostedService : BackgroundService
    {
        private readonly IMemoryCache _cache;
        private readonly IServiceProvider _serviceProvider;

        public LoadFileHostedService(IMemoryCache memoryCache, IServiceProvider serviceProvider)
        {
            _cache = memoryCache;
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var _restClient = scope.ServiceProvider.GetRequiredService<IRestApiExampleClient>();
                    var _fileService = scope.ServiceProvider.GetRequiredService<IFileService>();

                    var image = _fileService.GetFileFromCache("");

                    if (image == null)
                    {
                        image = _restClient.GetFileBytes();
                        _fileService.SetToCache(image,"");
                    }
                }
                await Task.Delay(TimeSpan.FromMinutes(1));
            }
        }

        //protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        //{
        //    while (!cancellationToken.IsCancellationRequested)
        //    {
        //        using (var scope = _serviceProvider.CreateScope())
        //        {
        //            var _restClient = scope.ServiceProvider.GetRequiredService<IRestApiExampleClient>();
        //            var cacheKey = $"image_{DateTime.UtcNow:yyyy_mm_dd}";
        //            var image = _cache.Get<byte[]>(cacheKey);

        //            if (image == null)
        //            {
        //                image = _restClient.GetFileBytes();
        //                var memoryCacheEntry = new MemoryCacheEntryOptions();
        //                memoryCacheEntry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(2);
        //                _cache.Set<byte[]>(cacheKey, image, memoryCacheEntry);
        //            }
        //        }
        //        await Task.Delay(TimeSpan.FromMinutes(1));
        //    }
        //}
    }
}