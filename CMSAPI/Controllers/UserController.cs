﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMSAPI.Models;
using CMSAPI.Models.ApiModels;
using CMSAPI.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace CMSAPI.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IHostingEnvironment _environment;
        private readonly ICMSRepository _CMSRepository;

        public UserController(IHostingEnvironment environment, ICMSRepository CMSRepository)
        {
            _environment = environment;
            _CMSRepository = CMSRepository;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // GET api/user/authenticated
        [HttpGet("authenticated")]
        public bool GetUserAuth()
        {
            bool isAuthenticated = User.Identity.IsAuthenticated;
            return isAuthenticated;
        }

        // POST api/user/newuser
        [HttpPost("newuser")]
        public async Task<IActionResult> CreateUser([FromBody]JObject jsonData)
        {
            if (jsonData == null)
            {
                return BadRequest();
            }

            ApiUser user = jsonData.ToObject<ApiUser>();

            bool result = await _CMSRepository.CreateUser(user);
            if (result)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        // POST api/user/login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]ApiLogin user)
        {
            string username = user.Username;
            string password = user.Password;
            bool result = await _CMSRepository.Login(username, password);
            if (result) 
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        // POST api/user/logout
        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            bool result = await _CMSRepository.Logout();
            if(result) 
            {
                return Ok();
            }
            else 
            {
                return BadRequest();
            }

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
