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
    public class ItemController : Controller
    {
        private readonly ICMSRepository _CMSRepository;

        public ItemController(ICMSRepository CMSRepository)
        {
            _CMSRepository = CMSRepository;
        }

        // GET api/item/5
        [HttpGet("{id}")]
        public async Task<IEnumerable<Item>> Get(string id)
        {
            return await _CMSRepository.GetAllItems(id);
        }

        // GET api/item/5/4
        [HttpGet("{id}/{pageid}")]
        public async Task<IEnumerable<Item>> GetPageItems(string id, int pageid)
        {
            return await _CMSRepository.GetPageItems(id, pageid);
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
        public async Task<IActionResult> Put(int id, [FromBody]Item i)
        {
            if (i == null || i.ID != id)
            {
                return BadRequest();
            }

            var item = await _CMSRepository.GetItem(id);
            if (item == null)
            {
                return NotFound();
            }

            item.Name = i.Name;
            item.Title = i.Title;
            item.Text = i.Text;
            item.Image = i.Image;
            item.SortNumber = i.SortNumber;

            await _CMSRepository.EditItem(item);
            return new NoContentResult();
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
