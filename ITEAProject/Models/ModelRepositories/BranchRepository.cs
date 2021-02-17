using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ITEAProject.Models.ModelRepositories
{
    public class BranchRepository:IBranchRepository
    {
        private IteaProjectDbContext _context;
        public BranchRepository(IteaProjectDbContext context)
        {
            _context = context;
        }

        public List<Branch> AllBranches()
        {
            return _context.Branches.ToList();
        }
        public void NewBranch(Branch branch)
        {
            _context.Branches.Add(branch);
            _context.SaveChanges();
        }

        public void EditBranch(Branch branch)
        {
            Branch editBranch = _context.Branches.Where(br => br.Id == branch.Id).First();

            if(editBranch!=null)
            {
                editBranch.Address = branch.Address;
                editBranch.Phone = branch.Phone;
                _context.SaveChanges();
            }
        }

        public void DeleteBranch(int branchId)
        {
            Branch deleteBranch = _context.Branches.Where(br => br.Id == branchId).First();

            if(deleteBranch!=null)
            {
                _context.Branches.Remove(deleteBranch);
                _context.SaveChanges();
            }
        }
    }
}
