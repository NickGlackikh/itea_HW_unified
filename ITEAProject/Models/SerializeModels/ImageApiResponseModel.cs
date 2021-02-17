using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITEAProject.Services
{
    public class ImageApiResponseModel
    {
        public string message { get; set; }
        public ImageApiResponseModel(){}

        public ImageApiResponseModel(string _message)
        {
            message = _message;
        }
    }
}
