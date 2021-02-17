using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ITEAProject.Models
{
    public class Owner
    {
        public int Id { get; set; }
        [Required]
        public string OwnerName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Phone { get; set; }
        public List<Pet> Pets { get; set; }
    }
}
