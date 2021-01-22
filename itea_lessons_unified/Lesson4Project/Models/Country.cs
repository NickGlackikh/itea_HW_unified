using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson4Project.Models
{
    public class Country
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Population { get; set; }
        [Required]
        public int SickCount { get; set; }
        [Required]
        public int DeadCount { get; set; }
        [Required]
        public int RecoveredCount { get; set; }
        public bool Vaccine { get; set; }
        public virtual /*virtual для lazy loading*/List<Human> Humans { get; set; }

    }
}
