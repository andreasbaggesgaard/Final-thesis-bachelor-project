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
    public class PagesController : Controller
    {
        private readonly ICMSRepository _CMSRepository;

        public PagesController(ICMSRepository CMSRepository)
        {
            _CMSRepository = CMSRepository;
        }

        // GET api/pages/5
        [HttpGet("{id}")]
        public async Task<IEnumerable<Page>> Get(string id)
        {
            return await _CMSRepository.GetAllPages(id);
        }

        // POST api/pages/new
        [HttpPost("new")]
        public async Task<IActionResult> Post([FromBody]JObject value)
        {
            if (value == null)
            {
                return BadRequest();
            }
            Page page = value.ToObject<Page>();

            await _CMSRepository.AddPage(page);

            return new NoContentResult();
        }

        // PUT api/pages/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]Page p)
        {
            if (p == null || p.ID != id)
            {
                return BadRequest();
            }

            var page = await _CMSRepository.GetPage(id);
            if (page == null)
            {
                return NotFound();
            }

            page.Name = p.Name;
            page.Title = p.Title;
            page.Text = p.Text;
            page.Image = p.Image;
            page.TemplateID = p.TemplateID;

            await _CMSRepository.EditPage(page);
            return new NoContentResult();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var page = await _CMSRepository.GetPage(id);
            if (page == null)
            {
                return NotFound();
            }

            await _CMSRepository.RemovePage(id);
            return new NoContentResult();
        }
    }
}
