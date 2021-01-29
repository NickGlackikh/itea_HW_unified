using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson4Project.Services
{
    public interface IRestApiExampleClient
    {
        public byte[] GetFileBytes();
        public byte[] GetFileByName(string fileName);
        public void UploadFile([NotNull]IFormFile file);
    }
}
