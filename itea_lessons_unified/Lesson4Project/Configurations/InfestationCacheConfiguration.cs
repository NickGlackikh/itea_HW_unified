using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson4Project.Configurations
{
    public class InfestationCacheConfiguration
    {
        public int cacheExpireTime { get; set; }
        public string cacheKey { get; set; }
    }
}
