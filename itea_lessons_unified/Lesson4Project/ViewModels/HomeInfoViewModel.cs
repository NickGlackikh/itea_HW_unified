using Lesson4Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson4Project.ViewModels
{
    public class HomeInfoViewModel
    {
        public IEnumerable<Human> Humans { get; set; }
        public IEnumerable<Country> Countries { get; set; }
    }
}
