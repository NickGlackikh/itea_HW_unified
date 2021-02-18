using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITEAProject.ViewModels
{
    public class PetIndexViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int BreedId { get; set; }
        public int BranchId { get; set; }
        public string BreedName { get; set; }
        public int ? OwnerId { get; set; }
        public string OwnerName { get; set; }
    }
}
