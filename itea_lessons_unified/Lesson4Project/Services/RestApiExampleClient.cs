using Microsoft.AspNetCore.Http;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
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

        public void UploadFile(IFormFile file)
        {
            var client = new RestClient("http://localhost:56090");
            var request = new RestRequest("File", Method.POST);
            using (var stream=new MemoryStream())
            {
                file.CopyTo(stream);
                request.AddJsonBody(Convert.ToBase64String(stream.ToArray()));

                request.AddQueryParameter("filename", file.FileName);
                client.Execute(request);
            }
        }
    }
}
