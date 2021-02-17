using ITEAProject.Services.Repositories;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ITEAProject.Services
{
    public class LoadImageHostedService:BackgroundService
    {
        private readonly IMemoryCache _cache;
        private readonly IServiceProvider _serviceProvider;

        public LoadImageHostedService(IMemoryCache memoryCache, IServiceProvider serviceProvider)
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
                    var _restClient = scope.ServiceProvider.GetRequiredService<IRestApiClient>();
                    var _fileService = scope.ServiceProvider.GetRequiredService<IFileService>();

                    var image = _fileService.GetFileFromCache();

                    if (image == null)
                    {
                        image = _restClient.GetFile();
                        _fileService.SetToCache(image);
                    }
                }
                await Task.Delay(TimeSpan.FromMinutes(2));
            }
        }
    }
}
