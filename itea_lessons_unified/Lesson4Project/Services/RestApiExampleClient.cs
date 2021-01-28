using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson4Project.Services
{
    public class RestApiExampleClient : IRestApiExampleClient
    {
        public byte[] GetFileBytes()
        {
            var client = new RestClient("http://localhost:56090");
            var request = new RestRequest("File", Method.GET);
            byte[] content = client.Execute(request).RawBytes;
            return content;
        }

        public byte[] GetFileByName(string fileName)
        {
            var client = new RestClient("http://localhost:56090");
            var request = new RestRequest("File", Method.GET);
            request.AddParameter("fileName", fileName);
            byte[] content = client.Execute(request).RawBytes;
            return content;
        }
    }
}
