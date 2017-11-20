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
    public class ProjectController : Controller
    {
        private readonly ICMSRepository _CMSRepository;

        public ProjectController(ICMSRepository CMSRepository)
        {
            _CMSRepository = CMSRepository;
        }

        // GET api/project
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "hello", "world" };  
        } 

        // GET api/project/5
        [HttpGet("/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var ProjectContent = await _CMSRepository.GetAllProjectContent(id);
                                                                     
            if (ProjectContent == null)
            {
                return NotFound();
            }
            return new ObjectResult(ProjectContent);
        }

        // POST api/project
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Project value)
        {
            if (value == null)
            {
                return BadRequest();
            }
            var project = new Project { Name = "NewProject"};
            await _CMSRepository.AddProject(project);

            return new NoContentResult();
        }

        // PUT api/project/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]Project value)
        {
            if (value == null || value.ID != id)
            {
                return BadRequest();
            }

            var project = _CMSRepository.GetProject(id);
            if (project == null)
            {
                return NotFound();
            }

            project.Name = value.Name;

            await _CMSRepository.EditProject(project);
            return new NoContentResult();
        }

        // DELETE api/project/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var project = _CMSRepository.GetProject(id);
            if (project == null)
            {
                return NotFound();
            }

            await _CMSRepository.RemoveProject(id);
            return new NoContentResult();
        }
    }
}
