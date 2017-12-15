using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CMSAPI.Models;
using CMSAPI.Models.ApiModels;

namespace CMSAPI.Services
{
    public interface ICMSRepository
    {
        // Users
        Task<bool> CreateUser(ApiUser obj);
        Task<bool> Login(string username, string password);
        Task<bool> Logout();

        // Projects
        Task<IEnumerable<Project>> GetAllProjects();
        Task<IEnumerable<Project>> GetAllProjectContent(string pid);
        Task<Project> AddProject(Project newProject);
        Task<Project> GetProject(string id);
        Task<Project> RemoveProject(string id);
        Task<Project> EditProject(Project project);

        // Items
        Task<IEnumerable<Item>> GetAllItems(string pid);
        Task<IEnumerable<Item>> GetPageItems(string pid, int pageid);
        Task<Item> AddItem(Item newItem);
        Task<Item> GetItem(int id);
        Task<Item> RemoveItem(int id);
        Task<Item> EditItem(Item item);

        // Contenttypes
        Task<IEnumerable<ContentType>> GetAllContentTypes();

        // Pages
        Task<IEnumerable<Page>> GetAllPages(string pid);
        Task<Page> AddPage(Page newPage);
        Task<Page> GetPage(int id);
        Task<Page> RemovePage(int id);
        Task<Page> EditPage(Page project);

        // Templates
        Task<IEnumerable<Template>> GetAllTemplates(string pid);
        Task<Template> AddTemplate(Template newTemplate);

        // Menu
        Task<IEnumerable<Menu>> GetAllMenuItems(string pid);
        Task<Menu> AddMenu(Menu newMenu);
        Task<Menu> GetMenuItem(int pageid);
        Task<Menu> RemoveMenuItem(int pageid);
    }
}
