using System;
using System.Collections.Generic;
using CMSAPI.Models;
using CMSAPI.Data;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CMSAPI.Services
{
    public class CMSRepository : ICMSRepository
    {
        private readonly CMSContext _context;

        public CMSRepository(CMSContext context)
        {
            _context = context;
        }

        // Projects
        public async Task<IEnumerable<Project>> GetAllProjectContent(int id)
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
            await _context.Projects.AddAsync(newProject);
            await _context.SaveChangesAsync();
            return newProject;
        }

        public Project GetProject(int id)
        {
            return _context.Projects.FirstOrDefault(i => i.ID == id);
        }

        public async Task<Project> RemoveProject(int id)
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
