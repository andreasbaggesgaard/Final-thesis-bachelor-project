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
    public class MenuController : Controller
    {
        private readonly ICMSRepository _CMSRepository;

        public MenuController(ICMSRepository CMSRepository)
        {
            _CMSRepository = CMSRepository;
        }

        // GET api/menu/5
        [HttpGet("{id}")]
        public async Task<IEnumerable<Menu>> Get(string id)
        {
            return await _CMSRepository.GetAllMenuItems(id);
        }

        // POST api/menu/new
        [HttpPost("new")]
        public async Task<IActionResult> Post([FromBody]JObject value)
        {
            if (value == null)
            {
                return BadRequest();
            }
            Menu menu = value.ToObject<Menu>();

            await _CMSRepository.AddMenu(menu);

            return new NoContentResult();
        }

        // PUT api/menu/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/menu/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var menuitem = _CMSRepository.GetMenuItem(id);
            if (menuitem == null)
            {
                return NotFound();
            }
            await _CMSRepository.RemoveMenuItem(id);
            return new NoContentResult();
        }
    }
}
