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
        public FileContentResult GetTerrainImage(string fileName)
        {
            if (System.IO.File.Exists($"wwwroot/{fileName}.jpg"))
            {
                var fileBytes = System.IO.File.ReadAllBytes($"wwwroot/{fileName}.jpg");
                return new FileContentResult(fileBytes, "image/jpeg");
            }
            else
            {
                var fileBytes = System.IO.File.ReadAllBytes("wwwroot/not-found.png");
                return new FileContentResult(fileBytes, "image/jpeg");
            }
        }

        
    }
}
