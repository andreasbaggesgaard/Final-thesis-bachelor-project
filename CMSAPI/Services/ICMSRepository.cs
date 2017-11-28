using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CMSAPI.Models;

namespace CMSAPI.Services
{
    public interface ICMSRepository
    {
        // user
        Task<bool> CreateUser(ApiUser obj);
        Task<bool> Login(string username, string password);
        Task<bool> Logout();

        // project
        Task<IEnumerable<Project>> GetAllProjects();
        Task<IEnumerable<Project>> GetAllProjectContent(string id);
        Task<Project> AddProject(Project newProject);
        Project GetProject(string id);
        Task<Project> RemoveProject(string id);
        Task<Project> EditProject(Project project);

    }
}
