using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ITEAProject.Models
{
    public class Pet
    {
        public int Id { get; set; }
        [Required]
        public string PetName { get; set; }
        [Required]
        public Gender Gender { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public int BreedId { get; set; }
        [Required]
        public int BranchId { get; set; }
        public int? OwnerId { get; set; }

        public Breed Breed;
        public Branch Branch;
        public Owner Owner;
    }

    public enum Gender
    {
        Undefined,
        Male,
        Female
    }
}
