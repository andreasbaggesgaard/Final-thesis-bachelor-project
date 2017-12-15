using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMSAPI.Models;
using CMSAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CMSAPI.Controllers
{
    [Route("api/[controller]")]
    public class ContentTypeController : Controller
    {
        private readonly ICMSRepository _CMSRepository;

        public ContentTypeController(ICMSRepository CMSRepository)
        {
            _CMSRepository = CMSRepository;
        }

        // GET: api/contenttype
        [HttpGet]
        public async Task<IEnumerable<ContentType>> Get()
        {
            return await _CMSRepository.GetAllContentTypes();
        }

    }
}
