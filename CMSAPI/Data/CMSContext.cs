using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CMSAPI.Models;

namespace CMSAPI.Data
{
    public class CMSContext : IdentityDbContext<Person>
    {
        public CMSContext(DbContextOptions<CMSContext> options) : base(options)
        {
        }

        public DbSet<Person> People { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Template> Templates { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<ContentType> ContentTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Person>().ToTable("User");
            builder.Entity<Menu>().ToTable("Menu");
            builder.Entity<Project>().ToTable("Project");  
            builder.Entity<Template>().ToTable("Template");
            builder.Entity<Item>().ToTable("Item");
            builder.Entity<Page>().ToTable("Page");      
            builder.Entity<ContentType>().ToTable("ContentType");

            builder.Entity<Page>()
                .HasOne(u => u.Template)
                .WithMany(u => u.Pages);

            builder.Entity<Page>()
                .HasOne(u => u.Project)
                .WithMany(u => u.Pages);

            builder.Entity<Item>()
                .HasOne(u => u.Project)
                .WithMany(u => u.Items);
            
            builder.Entity<Template>()
                .HasOne(u => u.Project)
                .WithMany(u => u.Templates);
            
            builder.Entity<Project>()
                .HasMany(u => u.Templates)
                .WithOne(x => x.Project);

            builder.Entity<Project>()
                .HasMany(u => u.Items)
                .WithOne(x => x.Project);

            builder.Entity<Project>()
                .HasMany(u => u.Pages)
                .WithOne(x => x.Project);

            builder.Entity<Project>()
                .HasMany(u => u.Templates)
                .WithOne(x => x.Project);
            
            builder.Entity<Project>()
                .HasMany(u => u.Menu)
                .WithOne(x => x.Project);

            builder.Entity<Menu>()
                .HasKey(c => new { c.PageID, c.ProjectID });

        }

    }
}
