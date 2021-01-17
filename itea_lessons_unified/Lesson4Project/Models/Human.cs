using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson4Project.Models
{
    public class Human
    {
        public int Id { get; set; }

        [Required]
        [RegularExpression("^[a-zA-Z]*$")]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [RegularExpression("^[0-9]*$")]
        public int Age { get; set; }
        [Required]
        public bool IsSick { get; set; }
        [Required]
        public Gender Gender { get; set; }
        [Required]
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }
    }

    public enum Gender
    {
        Undefined,
        Male,
        Female
    }
}
