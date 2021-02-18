using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ITEAProject.Models
{
    //Сущность филиала сети приютов
    public class Branch
    {
        public int Id { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        [MinLength(3)]
        public string Address { get; set; }
        public List<Pet> Pets { get; set; }
    }
}
