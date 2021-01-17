using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson4Project.ViewModels
{
    public class AccountRegisterViewModel//:IdentityUser
    {
        [Required]
        [RegularExpression("^[a-zA-Z0-9]*$")]
        public string UserName { get; set; }

        [Required]
        [RegularExpression("^[a-zA-Z]*$")]
        public string FirstName { get; set; }

        [Required]
        [RegularExpression("^[a-zA-Z]*$")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage ="Не совпадает")]
        public string ConfirmPassword { get; set; }

    }
}
