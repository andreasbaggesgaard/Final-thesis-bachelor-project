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

            if (context.Items.Any())
            {
                return;   // DB has been seeded
            }

            var people = new Person[]
            {
                new Person { Id = "123A", UserName = "user1", PasswordHash = "asdaklkkkdkkd"  },
                new Person { Id = "123B", UserName = "user2", PasswordHash = "asdaklkkkdkkd"  },
                new Person { Id = "123C", UserName = "user3", PasswordHash = "asdaklkkkdkkd"  }

            };

            foreach (Person p in people)
            {
                context.People.Add(p);
            }
            context.SaveChanges();

            var projects = new Project[]
            {
                new Project { Name = "project1", Created = new DateTime(2008, 3, 1, 7, 0, 0).ToString(), ID = people.Single(p => p.Id == "123A").Id },
                new Project { Name = "project2", Created = new DateTime(2008, 3, 1, 7, 0, 0).ToString(), ID = people.Single(p => p.Id == "123B").Id },
                new Project { Name = "project3", Created = new DateTime(2008, 3, 1, 7, 0, 0).ToString(), ID = people.Single(p => p.Id == "123C").Id }
            };

            foreach (Project p in projects)
            {
                context.Projects.Add(p);
            }
            context.SaveChanges();

            var templates = new Template[]
            {
                new Template { Name = "template1", ProjectID = projects.Single(p => p.ID == "123A").ID },
                new Template { Name = "template2", ProjectID = projects.Single(p => p.ID == "123B").ID },
                new Template { Name = "template2", ProjectID = projects.Single(p => p.ID == "123C").ID }
            };

            foreach (Template p in templates)
            {
                context.Templates.Add(p);
            }
            context.SaveChanges();

            var pages = new Page[]
            {
                new Page { Title = "Page1", TemplateID = templates.Single(p => p.ID == 1).ID, ProjectID = projects.Single(p => p.ID == "123A").ID },
                new Page { Title = "Page2", TemplateID = templates.Single(p => p.ID == 2).ID, ProjectID = projects.Single(p => p.ID == "123B").ID },
                new Page { Title = "Page3", TemplateID = templates.Single(p => p.ID == 2).ID, ProjectID = projects.Single(p => p.ID == "123C").ID }
            };

            foreach (Page p in pages)
            {
                context.Pages.Add(p);
            }
            context.SaveChanges();

            var contenttypes = new ContentType[]
            { 
                new ContentType { Name = "Contenttype1", ProjectID = projects.Single(p => p.ID == "123A").ID },
                new ContentType { Name = "Contenttype2", ProjectID = projects.Single(p => p.ID == "123B").ID },
                new ContentType { Name = "Contenttype3", ProjectID = projects.Single(p => p.ID == "123C").ID }
            };

            foreach (ContentType c in contenttypes)
            {
                context.ContentTypes.Add(c);
            }
            context.SaveChanges();

            var items = new Item[]
            {
                new Item { Name = "Item1", PageID = pages.Single(c => c.ID == 1).ID, ContentTypeID = contenttypes.Single(c => c.ID == 1).ID, ProjectID = projects.Single(p => p.ID == "123A").ID},
                new Item { Name = "Item2", PageID = pages.Single(c => c.ID == 2).ID, ContentTypeID = contenttypes.Single(c => c.ID == 2).ID, ProjectID = projects.Single(p => p.ID == "123B").ID},
                new Item { Name = "Item3", PageID = pages.Single(c => c.ID == 2).ID, ContentTypeID = contenttypes.Single(c => c.ID == 2).ID, ProjectID = projects.Single(p => p.ID == "123B").ID},
                new Item { Name = "Item4", PageID = pages.Single(c => c.ID == 2).ID, ContentTypeID = contenttypes.Single(c => c.ID == 2).ID, ProjectID = projects.Single(p => p.ID == "123B").ID},
                new Item { Name = "Item5", PageID = pages.Single(c => c.ID == 1).ID, ContentTypeID = contenttypes.Single(c => c.ID == 1).ID, ProjectID = projects.Single(p => p.ID == "123A").ID}
            };

            foreach (Item i in items)
            {
                context.Items.Add(i);
            }
            context.SaveChanges();

        }
    }
}
