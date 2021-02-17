using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITEAProject.Models.ModelRepositories
{
    public class OwnerRepository:IOwnerRepository
    {
        private readonly IteaProjectDbContext _context;

        public OwnerRepository(IteaProjectDbContext context)
        {
            _context = context;
        }
        public List<Owner> AllOwners()
        {
            return _context.Owners.ToList();
        }

        public void AddOwner(Owner owner)
        {
            _context.Owners.Add(owner);
            _context.SaveChanges();
        }

        public void UpdateOwner(Owner owner)
        {
            Owner _owner = _context.Owners.Where(o=>o.Id==owner.Id).First();

            if(_owner!=null)
            {
                _owner.OwnerName = owner.OwnerName;
                _owner.Address = owner.Address;
                _owner.Phone = owner.Phone;

                _context.SaveChanges();
            }
        }

        public void DeleteOwner(int Id)
        {
            Owner owner = _context.Owners.Where(o => o.Id == Id).First();
            _context.Owners.Remove(owner);
            _context.SaveChanges();
        }
    }
}
