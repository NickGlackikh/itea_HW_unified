using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITEAProject.Configurations
{
    public class CacheConfiguration
    {
        public int cacheExpireTime { get; set; }
        public string cacheKey { get; set; }
        public string imageName { get; set; }
    }
}
