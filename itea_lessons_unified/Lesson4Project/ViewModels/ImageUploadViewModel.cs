using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson4Project.ViewModels
{
    public class ImageUploadViewModel
    {
        public string FileName { get; set; }
        public IFormFile File { get; set; }
        public UploadStage UploadStage { get; set; }
    }

    public enum UploadStage
    {
        Upload,
        Comleted
    }
}
