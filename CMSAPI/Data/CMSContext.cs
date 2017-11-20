using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CMSAPI.Models;

namespace CMSAPI.Data
{
    public class CMSContext : DbContext
    {
        public CMSContext(DbContextOptions<CMSContext> options) : base(options)
        {
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Template> Templates { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<ContentType> ContentTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Project>().ToTable("Project");  
            modelBuilder.Entity<Template>().ToTable("Template");
            modelBuilder.Entity<Item>().ToTable("Item");
            modelBuilder.Entity<Page>().ToTable("Page");      
            modelBuilder.Entity<ContentType>().ToTable("ContentType");

            modelBuilder.Entity<Page>() 
            .HasOne(u => u.Template)
            .WithMany(u => u.Pages)
            .IsRequired().OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Page>()
            .HasOne(u => u.Project)
            .WithMany(u => u.Pages)
            .IsRequired().OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Page>()
            .HasMany(u => u.Items)
            .WithOne(u => u.Page)
            .IsRequired().OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Item>()
            .HasOne(u => u.Page)
            .WithMany(u => u.Items)
            .IsRequired().OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Item>()
            .HasOne(u => u.Page)
            .WithMany(u => u.Items)
            .IsRequired().OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Item>()
            .HasOne(u => u.Project)
            .WithMany(u => u.Items)
            .IsRequired().OnDelete(DeleteBehavior.Restrict);
            
            modelBuilder.Entity<Template>()
            .HasOne(u => u.Project)
            .WithMany(u => u.Templates);
            
            modelBuilder.Entity<Project>()
            .HasMany(u => u.Templates)
            .WithOne(x => x.Project);

            modelBuilder.Entity<Project>()
            .HasMany(u => u.Items)
            .WithOne(x => x.Project);

            modelBuilder.Entity<Project>()
            .HasMany(u => u.Pages)
            .WithOne(x => x.Project);

            modelBuilder.Entity<Project>()
            .HasMany(u => u.Templates)
            .WithOne(x => x.Project);

            modelBuilder.Entity<Project>()
            .HasMany(u => u.ContentTypes)
            .WithOne(x => x.Project);

        }

    }
}
