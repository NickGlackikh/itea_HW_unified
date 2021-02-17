using ITEAProject.Models.SerializeModels;
using ITEAProject.Services.Repositories;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITEAProject.Services
{
    public class RestApiClient:IRestApiClient
    {
        public byte[] GetFile()
        {
            var client = new RestClient("https://dog.ceo/api/breeds/image/random");
            //var client = new RestClient("https://random.dog/woof.json");
            var requestImageUrl = new RestRequest(Method.GET);
            string apiResponse = client.Execute(requestImageUrl).Content;
            ImageApiResponseModel model = JsonConvert.DeserializeObject<ImageApiResponseModel>(apiResponse);

            client = new RestClient(model.message);
            var requestImageBytes = new RestRequest(Method.GET);
            byte[] content = client.Execute(requestImageBytes).RawBytes;
           
            return content;
        }

        public string GetString()
        {
            var client = new RestClient("https://official-joke-api.appspot.com/random_joke");
            var requestStringUrl = new RestRequest(Method.GET);
            string apiResponse = client.Execute(requestStringUrl).Content;
            StringApiResponseModel model = JsonConvert.DeserializeObject<StringApiResponseModel>(apiResponse);

            string result = model.Setup + " - " + model.Punchline;
            return result;
        }
    }
}
