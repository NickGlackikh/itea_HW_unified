using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson4Project.Services
{
    public interface IRestApiExampleClient
    {
        public byte[] GetFileBytes();
        public byte[] GetFileByName(string fileName);
    }
}
