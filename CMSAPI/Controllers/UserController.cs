using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMSAPI.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CMSAPI.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly UserManager<Person> _userManager;
        private readonly SignInManager<Person> _signInManager;
        private readonly IHostingEnvironment _environment;

        public UserController(UserManager<Person> userManager, SignInManager<Person> signInManager, IHostingEnvironment environment)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _environment = environment;
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

        // POST api/user/newuser
        [HttpPost("newuser")]
        public async Task<IActionResult> NewUser(string username, string password)
        {
            //TODO: put in repository
            username = "andreasbaggesgaard";
            password = "Andreas1912c7a3@";
            var user = new Person { UserName = username, Joined = DateTime.Now.ToString() };
            IdentityResult result = await _userManager.CreateAsync(user, password);
            if (result.Succeeded)
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
        public async Task<IActionResult> Login(string username, string password)
        {
            username = "andreasbaggesgaard";
            password = "Andreas1912c7a3@";
            Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(username, password, isPersistent: true, lockoutOnFailure: false);
            if (result.Succeeded)
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
            await _signInManager.SignOutAsync();
            return Ok();
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
