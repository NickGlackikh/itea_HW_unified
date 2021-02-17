using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITEAProject.Models.ModelRepositories
{
    public interface IBranchRepository
    {
        List<Branch> AllBranches();
        void NewBranch(Branch branch);
        void EditBranch(Branch branch);
        void DeleteBranch(int branchId);

    }
}
