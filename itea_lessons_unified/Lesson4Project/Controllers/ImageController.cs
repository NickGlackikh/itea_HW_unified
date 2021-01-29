using Lesson4Project.Configurations;
using Lesson4Project.Services;
using Lesson4Project.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson4Project.Controllers
{
    public class ImageController : Controller
    {
        private readonly IRestApiExampleClient _client;
        private readonly IFileService _fileService;
        private readonly FileProcessingChannel _channel;

        public ImageController(IRestApiExampleClient client,
                               FileProcessingChannel channel, IFileService fileService)
        {
            _client = client;
            _channel = channel;
            _fileService = fileService;
        }

        public IActionResult Get(string fileName)
        {
            byte[] imageBytes;
            if (fileName!=null)
            {
                imageBytes = _fileService.GetFileFromCache(fileName);
                if (imageBytes == null)
                {
                    imageBytes = _client.GetFileByName(fileName);
                    _fileService.SetToCache(imageBytes, fileName);
                }
            }
            else
            {
                 imageBytes = _fileService.GetFileFromCache(fileName);
                if (imageBytes == null)
                {
                    imageBytes = _client.GetFileBytes();
                    _fileService.SetToCache(imageBytes, null);
                }
            }
  
            return new FileContentResult(imageBytes, "image/jpeg");
        }


        [HttpGet]
        public IActionResult Upload()
        {
            var viewModel = new ImageUploadViewModel();
            viewModel.UploadStage = UploadStage.Upload;
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Upload(ImageUploadViewModel viewModel)
        {
            var entryOptions = new MemoryCacheEntryOptions();
            entryOptions.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(2);

            if (viewModel.File?.Length > 0)
            {
                //_client.UploadFile(viewModel.File);
                await _channel.SetAsync(viewModel.File);
                viewModel.File = null;
                viewModel.UploadStage = UploadStage.Comleted;
            }

            return View(viewModel);
        }


        //public IActionResult Get1()
        //{
        //    var cachekey = $"image_{DateTime.UtcNow:yyyy_MM_dd}";
        //    var imageBytes = _memoryCache.Get<byte[]>(cachekey);
        //    if(imageBytes==null)
        //    {
        //        imageBytes = _client.GetFileBytes();
        //        var options = new MemoryCacheEntryOptions();
        //        options.SlidingExpiration = TimeSpan.FromMinutes(2);
        //        _memoryCache.Set<byte[]>(cachekey, imageBytes, options);
        //    }
        //    return new FileContentResult(imageBytes, "image/jpeg");
        //}
    }
}
