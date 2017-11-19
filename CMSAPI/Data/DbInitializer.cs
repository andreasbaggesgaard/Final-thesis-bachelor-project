using System;
using System.Linq;
using CMSAPI.Models;
namespace CMSAPI.Data
{
    public static class DbInitializer
    {
        public static void Initialize(CMSContext context)
        {
             
            context.Database.EnsureCreated();

            /*if (context.Items.Any())
            {
                return;   // DB has been seeded
            }

            var projects = new Project[]
            {
                new Project { Name = "test", Created = new DateTime(2008, 3, 1, 7, 0, 0) }
            };

            foreach (Project p in projects)
            {
                context.Projects.Add(p);
            }
            context.SaveChanges();

            var templates = new Template[]
            {
                new Template { ProjectID = projects.Single(p => p.ID == 1).ID }
                //new Template { Name = "asdas" }
            };

            foreach (Template p in templates)
            {
                context.Templates.Add(p);
            }
            context.SaveChanges();

            var pages = new Page[]
            {
                new Page { TemplateID = templates.Single(p => p.ID == 1).ID }
                //new Page { Title = "sdd" }
            };

            foreach (Page p in pages)
            {
                context.Pages.Add(p);
            }
            context.SaveChanges();

            var contenttypes = new ContentType[]
            { 
                new ContentType { Name = "ct"  }
            };

            foreach (ContentType c in contenttypes)
            {
                context.ContentTypes.Add(c);
            }
            context.SaveChanges();

            var items = new Item[]
            {
                new Item { Name = "Cool name", SortNumber = 0, Used = false, PageID = pages.Single(c => c.ID == 1).ID,  ContentTypeID = contenttypes.Single(c => c.ID == 1).ID}
                //new Item { Name = "Cool name", SortNumber = 0, Used = false, ContentTypeID = contenttypes.Single(c => c.ID == 1).ID}

            };

            foreach (Item i in items)
            {
                context.Items.Add(i);
            }
            context.SaveChanges();*/


        }
    }
}
