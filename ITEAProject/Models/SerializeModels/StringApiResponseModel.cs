using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITEAProject.Models.SerializeModels
{
    public class StringApiResponseModel
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Setup { get; set; }
        public string Punchline { get; set; }
    }
}
