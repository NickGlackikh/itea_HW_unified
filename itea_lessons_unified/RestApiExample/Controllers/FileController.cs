using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiExample.Controllers
{
    public class FileController : Controller
    {
        [HttpGet("File")]
        public FileContentResult GetTerrainImage()
        {
            var fileBytes = System.IO.File.ReadAllBytes("wwwroot/TerrainImage55.jpg");
            return new FileContentResult(fileBytes, "image/jpeg");
        }

        
    }
}
