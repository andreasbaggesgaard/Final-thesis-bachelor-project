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

        public DbSet<Items> Items { get; set; }
        public DbSet<Pages> Pages { get; set; }
        public DbSet<Projects> Projects { get; set; }
        public DbSet<Templates> Templates { get; set; }

        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }*/

    }
}
