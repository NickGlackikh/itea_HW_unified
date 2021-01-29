using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Lesson4Project.Services
{
    public class UploadFileHostedService:BackgroundService
    {

        private readonly FileProcessingChannel _channel;
        private readonly IServiceProvider _serviceProvider;

        public UploadFileHostedService(IServiceProvider serviceProvider, FileProcessingChannel channel)
        {
            _serviceProvider = serviceProvider;
            _channel = channel;
        }

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            
            while(!cancellationToken.IsCancellationRequested)
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var _client = scope.ServiceProvider.GetRequiredService<IRestApiExampleClient>();
                    //IFormFile file = _channel.Get();
                    //IFormFile file = await _channel.GetFileAsync();
                    await foreach (IFormFile file in _channel.GetAllAsync())
                    {
                        if (file != null)
                        {
                            _client.UploadFile(file);
                        }
                    }
                    await Task.Delay(TimeSpan.FromSeconds(10));
                }
            }
        }
    }
}
