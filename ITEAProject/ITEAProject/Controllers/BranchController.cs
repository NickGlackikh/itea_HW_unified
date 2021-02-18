using ITEAProject.Models;
using ITEAProject.Models.ModelRepositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITEAProject.Controllers
{
    public class BranchController : Controller
    {
        private IBranchRepository _branchRepository;

        public BranchController(IBranchRepository branchRepository)
        {
            _branchRepository = branchRepository;
        }
        public IActionResult Index()
        {
            return View(_branchRepository.AllBranches());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Branch branch)
        {
            if (ModelState.IsValid)
            {
                _branchRepository.NewBranch(branch);
                return Redirect("~/Branch/Index");
            }
           // return View();
            return View("Create");
        }

        [HttpGet]
        public IActionResult Update(int Id)
        {
            Branch branch = _branchRepository.AllBranches().Where(br=> br.Id==Id).First();
            return View(branch);
        }

        [HttpPost]
        public IActionResult Update(Branch branch)
        {
            if (ModelState.IsValid)
            {
                _branchRepository.EditBranch(branch);
                return Redirect("~/Branch/Index");
            }
            return View(branch);
        }

        public IActionResult Delete(int id)
        {
            _branchRepository.DeleteBranch(id);
            return Redirect("~/Branch/Index");
        }
    }
}
