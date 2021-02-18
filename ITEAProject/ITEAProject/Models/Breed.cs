using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ITEAProject.Models
{
    // Сущность породы собак
    public class Breed
    {
        public int Id { get; set; }
        [Required]
        public string BreedName { get; set; }
        [Required]
        public string BreedDescription { get; set; }
        public List<Pet> Pets { get; set; }
    }
}
