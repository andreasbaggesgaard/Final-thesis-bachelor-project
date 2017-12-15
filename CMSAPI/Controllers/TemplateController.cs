using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMSAPI.Models;
using CMSAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace CMSAPI.Controllers
{
    [Route("api/[controller]")]
    public class TemplateController : Controller
    {
        
        private readonly ICMSRepository _CMSRepository;

        public TemplateController(ICMSRepository CMSRepository)
        {
            _CMSRepository = CMSRepository;
        }

        // GET api/template/5
        [HttpGet("{id}")]
        public async Task<IEnumerable<Template>> Get(string id)
        {
            return await _CMSRepository.GetAllTemplates(id);
        }

        // POST api/template/new
        [HttpPost("new")]
        public async Task<IActionResult> Post([FromBody]JObject value)
        {
            if (value == null)
            {
                return BadRequest();
            }
            Template template = value.ToObject<Template>();

            await _CMSRepository.AddTemplate(template);

            return new NoContentResult();
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
