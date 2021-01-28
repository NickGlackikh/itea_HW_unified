using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson4Project.Services
{
    public interface IFileService
    {
        public byte[] GetFileFromCache(string fileName);
        public void SetToCache(byte[] clientFile, string fileName);
    }
}
