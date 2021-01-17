using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson4Project.Models
{
    public class CustomUser:IdentityUser
    {
        [Required]
        [RegularExpression("^[a-zA-Z]*$")]
        public string FirstName { get; set; }


        [Required]
        [RegularExpression("^[a-zA-Z]*$")]
        public string LastName { get; set; }
    }
}
