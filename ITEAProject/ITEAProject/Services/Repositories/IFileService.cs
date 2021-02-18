using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITEAProject.Services
{
    public interface IFileService
    {
        public byte[] GetFileFromCache();
        public void SetToCache(byte[] clientFile);
    }
}
