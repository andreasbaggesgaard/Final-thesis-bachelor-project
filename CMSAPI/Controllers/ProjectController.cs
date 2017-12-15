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
using Newtonsoft.Json.Linq;

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
        public async Task<IEnumerable<Project>> GetAll()
        {
            return await _CMSRepository.GetAllProjects();
        }

        // GET api/project/all/5
        [Authorize] 
        [HttpGet("all/{id}")]
        public async Task<IActionResult> GetAll(string id)
        {
            var ProjectContent = await _CMSRepository.GetAllProjectContent(id);
                                                                     
            if (ProjectContent == null)
            {
                return NotFound();
            }
            return new ObjectResult(ProjectContent);
        }

        // GET api/project/5
        //[Authorize] 
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var ProjectContent = await _CMSRepository.GetProject(id);

            if (ProjectContent == null)
            {
                return NotFound();
            }
            return new ObjectResult(ProjectContent);
        }

        // POST api/project/newproject
        [HttpPost("newproject")]
        public async Task<IActionResult> Post([FromBody]JObject value)
        {
            if (value == null)
            {
                return BadRequest();
            }
            Project project = value.ToObject<Project>();

            await _CMSRepository.AddProject(project);

            return new NoContentResult();
        }

        // PUT api/project/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody]Project value)
        {
            if (value == null || value.ID != id)
            {
                return BadRequest();
            }

            var project = await _CMSRepository.GetProject(id);
            if (project == null)
            {
                return NotFound();
            }

            project.Name = value.Name;
            project.Background = value.Background;
            project.NavbarColor = value.NavbarColor;
            project.Theme = value.Theme;
            project.Configured = value.Configured;

            await _CMSRepository.EditProject(project);
            return new NoContentResult();
        }

        // DELETE api/project/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
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
