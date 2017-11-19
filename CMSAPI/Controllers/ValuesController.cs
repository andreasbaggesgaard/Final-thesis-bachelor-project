using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CMSAPI.Data;
using CMSAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CMSAPI.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly CMSContext _context;

        public ValuesController(CMSContext context)
        {
            _context = context;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<Item> Get()
        {
            return _context.Items.ToList();
        } 

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sproject = await _context.Projects
                 .Where(i => i.ID == id)
                 .Include(c => c.Templates)
                 .Include(c => c.Items)
                 .Include(c => c.Pages)
                 .Include(c => c.ContentTypes)
                 .AsNoTracking()
                 .SingleOrDefaultAsync(m => m.ID == id);
            if (sproject == null)
            {
                return NotFound();
            }

            return new ObjectResult(sproject);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
            _context.Items.Add(new Item { Name = "Some question" });
            _context.SaveChanges();
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
