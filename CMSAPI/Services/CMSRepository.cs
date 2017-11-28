using System;
using System.Collections.Generic;
using CMSAPI.Models;
using CMSAPI.Data;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace CMSAPI.Services
{
    public class CMSRepository : ICMSRepository
    {
        private readonly CMSContext _context;
        private readonly UserManager<Person> _userManager;
        private readonly SignInManager<Person> _signInManager;

        public CMSRepository(CMSContext context, UserManager<Person> userManager, SignInManager<Person> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // Users
        public async Task<bool> CreateUser(ApiUser obj)
        {
            var user = new Person { 
                Id = obj.Uid,
                UserName = obj.Username, 
                Email = obj.Email,
                Name = obj.Name,
                Picture = "picture",
                PhoneNumber = obj.Phone,
                Age = obj.Age,
                Country = obj.Country,
                Joined = obj.Joined 
            };
            IdentityResult result = await _userManager.CreateAsync(user, obj.Password);
            if (result.Succeeded) { return true; } else { return false; }
        }

        public async Task<bool> Login(string username, string password)
        {
            username = "andreasbaggesgaard";
            password = "Andreas1912c7a3@";
            Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(username, password, isPersistent: true, lockoutOnFailure: false);
            if (result.Succeeded) { return true; } else { return false; }
        }

        public async Task<bool> Logout()
        {
            await _signInManager.SignOutAsync();
            return true;
        }

        // Projects
        public async Task<IEnumerable<Project>> GetAllProjects()
        {
            return await _context.Projects.ToListAsync();
        }

        public async Task<IEnumerable<Project>> GetAllProjectContent(string id)
        {
            var ProjectContent = await _context.Projects
                .Include(i => i.Pages)
                .Include(i => i.Items)
                .Include(i => i.Templates)
                .Include(i => i.ContentTypes)
                .Where(i => i.ID == id)
                .ToListAsync();         
            return ProjectContent;
        }

        public async Task<Project> AddProject(Project newProject)
        {
            var project = new Project
            {
                ID = newProject.ID,
                Name = newProject.Name,
                Created = DateTime.Now.ToString(),
                Background = "",
                NavbarColor = "",
                Theme = "",
                Configured = false
            };

            await _context.Projects.AddAsync(project);
            await _context.SaveChangesAsync();
            return newProject;
        }

        public Project GetProject(string id)
        {
            return _context.Projects.FirstOrDefault(i => i.ID == id);
        }

        public async Task<Project> RemoveProject(string id)
        {
            var item = GetProject(id);

            _context.Projects.Remove(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<Project> EditProject(Project project)
        {
            _context.Projects.Update(project);
            await _context.SaveChangesAsync();
            return project;
        }


    }
}
