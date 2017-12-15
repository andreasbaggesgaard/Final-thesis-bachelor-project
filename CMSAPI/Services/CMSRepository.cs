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
using CMSAPI.Models.ApiModels;

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

        public async Task<IEnumerable<Project>> GetAllProjectContent(string pid)
        {
            var ProjectContent = await _context.Projects
                .Include(i => i.Pages)
                .Include(i => i.Items)
                .Include(i => i.Templates)
                .Where(i => i.ID == pid)
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

        public async Task<Project> GetProject(string id)
        {
            return await _context.Projects.FirstOrDefaultAsync(i => i.ID == id);
        }

        public async Task<Project> RemoveProject(string id)
        {
            var item = await GetProject(id);

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

        // Items
        public async Task<IEnumerable<Item>> GetAllItems(string pid)
        {
            var items = await _context.Items.Where(i => i.ProjectID == pid).ToListAsync();
            return items;
        }

        public async Task<IEnumerable<Item>> GetPageItems(string pid, int pageid)
        {
            var items = await _context.Items
                                      .Where(p => (p.PageID == pageid))
                                      .Where(i => i.ProjectID == pid)
                                      .ToListAsync();
            return items;
        }

        public async Task<Item> AddItem(Item newItem)
        {
            var item = new Item
            {
                Name = newItem.Name,
                Title = newItem.Title,
                Text = newItem.Text,
                Image = newItem.Image,
                SortNumber = newItem.SortNumber,
                ContentTypeID = newItem.ContentTypeID,
                PageID = newItem.PageID,
                ProjectID = newItem.ProjectID
            };

            await _context.Items.AddAsync(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<Item> GetItem(int id)
        {
            return await _context.Items.FirstOrDefaultAsync(i => i.ID == id);
        }

        public async Task<Item> RemoveItem(int id)
        {
            var item = await GetItem(id);

            _context.Items.Remove(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<Item> EditItem(Item item)
        {
            _context.Items.Update(item);
            await _context.SaveChangesAsync();
            return item;
        }

        // ContentTypes
        public async Task<IEnumerable<ContentType>> GetAllContentTypes()
        {
            var ct = await _context.ContentTypes.ToListAsync();
            return ct;
        }

        // Pages
        public async Task<IEnumerable<Page>> GetAllPages(string pid)
        {
            var pages = await _context.Pages.Where(i => i.ProjectID == pid).ToListAsync();
            return pages;
        }

        public async Task<Page> AddPage(Page newPage)
        {
            var page = new Page 
            {
                Name = newPage.Name,
                Title = newPage.Title,
                Text = newPage.Text,
                Image = newPage.Image,
                TemplateID = newPage.TemplateID,
                ProjectID = newPage.ProjectID
            };

            await _context.Pages.AddAsync(page);
            await _context.SaveChangesAsync();
            return page;
        }

        public async Task<Page> GetPage(int id)
        {
            return await _context.Pages.FirstOrDefaultAsync(i => i.ID == id);
        }

        public async Task<Page> RemovePage(int id)
        {
            var page = await GetPage(id);

            _context.Pages.Remove(page);
            await _context.SaveChangesAsync();
            return page;
        }

        public async Task<Page> EditPage(Page page)
        {
            _context.Pages.Update(page);
            await _context.SaveChangesAsync();
            return page;
        }

        // Templates
        public async Task<IEnumerable<Template>> GetAllTemplates(string pid)
        {
            var templates = await _context.Templates.Where(i => i.ProjectID == pid).ToListAsync();
            return templates;
        }

        public async Task<Template> AddTemplate(Template newTemplate)
        {
            var template = new Template
            {
                Name = newTemplate.Name,
                PreviewImage = newTemplate.PreviewImage,
                ProjectID = newTemplate.ProjectID
            };

            await _context.Templates.AddAsync(template);
            await _context.SaveChangesAsync();
            return template;
        }

        // Menu
        public async Task<IEnumerable<Menu>> GetAllMenuItems(string pid)
        {
            var menuitems = await _context.Menus.Where(i => i.ProjectID == pid).ToListAsync();
            return menuitems;
        }

        public async Task<Menu> AddMenu(Menu newMenu)
        {
            var menu = new Menu
            {
                PageID = newMenu.PageID,
                ProjectID = newMenu.ProjectID
            };

            await _context.Menus.AddAsync(menu);
            await _context.SaveChangesAsync();
            return menu;
        }

        public async Task<Menu> GetMenuItem(int pageid)
        {
            return await _context.Menus.FirstOrDefaultAsync(i => i.PageID == pageid);
        }

        public async Task<Menu> RemoveMenuItem(int pageid)
        {
            var menuitem = await GetMenuItem(pageid);

            _context.Menus.Remove(menuitem);
            await _context.SaveChangesAsync();
            return menuitem;
        }


    }
}
