using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CMSAPI.Data;
using CMSAPI.Models;
using CMSAPI.Services;
using Microsoft.EntityFrameworkCore;

namespace CMSAPI.Controllers
{
    [Route("api/[controller]")]
    public class CMSController : Controller
    {
        private readonly CMSRepository _CMSRepository;

        public CMSController(CMSRepository CMSRepository)
        {
            _CMSRepository = CMSRepository;
        }

        // GET api/cms
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "hello", "world" };  
        } 

        // GET api/project/5
        [HttpGet("project/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var ProjectContent = await _CMSRepository.GetAllProjectContent(id);
                                                                     
            if (ProjectContent == null)
            {
                return NotFound();
            }
            return new ObjectResult(ProjectContent);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
           
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
