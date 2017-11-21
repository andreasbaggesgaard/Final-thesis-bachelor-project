using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CMSAPI.Data;
using CMSAPI.Models;
using CMSAPI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

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
        [Authorize] 
        [HttpGet]
        public async Task<IEnumerable<Project>> GetAll()
        {
            return await _CMSRepository.GetAllProjects();
        }

        // GET api/project/5
        [HttpGet("{id}")]
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
        //[Authorize] 
        public async Task<IActionResult> Post(Project value)
        {
            if (value == null)
            {
                return BadRequest();
            }
            var project = new Project { Name = "new name", Created = new DateTime(2008, 3, 1, 7, 0, 0) };
            await _CMSRepository.AddProject(project);

            return new NoContentResult();
        }

        // PUT api/project/5
        // [FromBody]Project value
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Project value)
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

            //project.Name = value.Name;
            project.Name = "new name";

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
