using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson5Project.Models
{
    public class District
    {
        public int Id { get; set; }
        public string DistrictName { get; set; }
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }
        public virtual /*virtual для lazy loading*/List<Human> Humans { get; set; }
    }
}
