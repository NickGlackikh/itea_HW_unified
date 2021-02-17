using ITEAProject.Services;
using ITEAProject.Services.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITEAProject.Controllers
{
    public class ImageController:Controller
    {
        private readonly IRestApiClient _client;
        private readonly IFileService _fileService;

        public ImageController(IRestApiClient client, IFileService fileService)
        {
            _client = client;
            _fileService = fileService;
        }

        public IActionResult Get(string fileName)
        {
            byte[] imageBytes;

            imageBytes = _fileService.GetFileFromCache();
            if (imageBytes == null)
            {
                imageBytes = _client.GetFile();
                _fileService.SetToCache(imageBytes);
            }


            return new FileContentResult(imageBytes, "image/jpeg");
        }

    }
}
