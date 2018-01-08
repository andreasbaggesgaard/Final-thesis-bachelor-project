using System;
using System.Collections.Generic;

namespace CMSAPI.Models
{
    public class Project
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Created { get; set; }
        public string Background { get; set; }
        public string NavbarColor { get; set; }
        public string Theme { get; set; }
        public bool Configured { get; set; }
              
        public Person Person { get; set; }
        public ICollection<Menu> Menu { get; set; }
        public ICollection<Item> Items { get; set; }
        public ICollection<Page> Pages { get; set; }
        public ICollection<Template> Templates { get; set; }

    }
}
