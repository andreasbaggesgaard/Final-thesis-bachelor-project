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
    public class PageController : Controller
    {
        private readonly ICMSRepository _CMSRepository;

        public PageController(ICMSRepository CMSRepository)
        {
            _CMSRepository = CMSRepository;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/page/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string pid)
        {
            if (string.IsNullOrWhiteSpace(pid))
            { 
                return NotFound();
            } else {
                var pages = await _CMSRepository.GetAllPages(pid);
                if (pages == null)
                {
                    return NotFound();
                }
                return new ObjectResult(pages);
            }
        }

        // POST api/item/new
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

        // PUT api/page/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/page/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var page = _CMSRepository.GetPage(id);
            if (page == null)
            {
                return NotFound();
            }
            await _CMSRepository.RemovePage(id);
            return new NoContentResult();
        }
    }
}
