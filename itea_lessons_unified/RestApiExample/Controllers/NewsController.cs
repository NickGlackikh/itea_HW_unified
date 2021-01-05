using BasicInfo.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicInfo.Controllers
{
    [ApiController]
    [Route("v1")]
    public class NewsController : ControllerBase
    {
        private INewsRepository _newsRepository { get; }
        
        public NewsController(INewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }

        [HttpGet("news")]
        public IActionResult Index(int? id, string authname, bool? fake)
        {
            return Ok(_newsRepository.GetNews().Where(x => (x.Id == id || id == null) && (x.AuthorName == authname || authname == null)
            && (x.IsFake == fake || !fake.HasValue)));
        }

        [HttpPost("news")]
        public IActionResult AddNews([FromBody]News _new)
        {
            int existNew = _newsRepository.GetNews().Where(x => x.Id == _new.Id).Count();

            if(existNew!=0)
            {
                return BadRequest();
            }
            _newsRepository.AddNews(_new);
            return Ok();
        }

        [HttpDelete("news")]
        public IActionResult DeleteNews(int id)
        {
            try
            {
                _newsRepository.DeleteNews(id);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            } 
        }

        [HttpPut("news")]
        public IActionResult PutNews([FromBody] News _new)
        {
            _newsRepository.UpdateNews(_new);
            return Ok();
        }
        [HttpPatch("news/{id:int}")]
        public IActionResult PatchNews([FromRoute]int id, [FromBody] JsonPatchDocument<News> _new)
        {
            if(_new == null)
            {
                return BadRequest();
            }

            var existNew = _newsRepository.GetNews().FirstOrDefault(x=>x.Id==id);
            if(existNew==null)
            {
                return BadRequest();
            }

            _newsRepository.PatchNews(id, _new);
            return Ok();
        }    
    }
}