using ITEAProject.Models.ModelRepositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITEAProject.Controllers
{
    [ApiController]
    [Route("v1")]
    public class RestController : ControllerBase
    {
        private IBranchRepository _branchRepository;
        private IPetRepository _petRepository;

        public RestController(IBranchRepository branchRepository, IPetRepository petRepository)
        {
            _branchRepository = branchRepository;
            _petRepository = petRepository;
        }

        [AllowAnonymous]
        public ActionResult Branches([FromQuery] int? id)
        {
            return Ok(_branchRepository.AllBranches().Where(b=>b.Id==id||id==null));
        }

        [AllowAnonymous]
        [HttpGet("petsinbranch/{id}")]
        public ActionResult Pets([FromRoute] int id)
        {
            return Ok(_petRepository.Pets().Where(p=>p.BranchId==id));
        }

        [AllowAnonymous]
        [HttpGet("pets")]
        public ActionResult Pets()
        {
            return Ok(_petRepository.Pets());
        }
    }
}
