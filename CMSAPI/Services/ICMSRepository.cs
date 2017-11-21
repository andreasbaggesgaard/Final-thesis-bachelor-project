using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CMSAPI.Models;

namespace CMSAPI.Services
{
    public interface ICMSRepository
    {
        Task<IEnumerable<Project>> GetAllProjects();
        Task<IEnumerable<Project>> GetAllProjectContent(int id);
        Task<Project> AddProject(Project newProject);
        Project GetProject(int id);
        Task<Project> RemoveProject(int id);
        Task<Project> EditProject(Project project);

    }
}
