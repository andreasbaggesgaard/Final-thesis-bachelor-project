using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMSAPI.Models;
using CMSAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CMSAPI.Controllers
{
    [Route("api/[controller]")]
    public class ItemController : Controller
    {
        private readonly ICMSRepository _CMSRepository;

        public ItemController(ICMSRepository CMSRepository)
        {
            _CMSRepository = CMSRepository;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/item/5
        [HttpGet("{id}")]
        public async Task<IEnumerable<Item>> Get(string id)
        {
            return await _CMSRepository.GetAllItems(id);
        }

        // POST api/item/new
        [HttpPost("new")]
        public async Task<IActionResult> Post([FromBody]JObject value)
        {
            if (value == null)
            {
                return BadRequest();
            }
            Item item = value.ToObject<Item>();

            await _CMSRepository.AddItem(item);

            return new NoContentResult();
        }

        // PUT api/item/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/item/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = _CMSRepository.GetItem(id);
            if (item == null)
            {
                return NotFound();
            }
            await _CMSRepository.RemoveItem(id);
            return new NoContentResult();
        }
    }
}
