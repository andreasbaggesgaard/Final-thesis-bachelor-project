using System;
using System.Collections.Generic;

namespace CMSAPI.Models
{
    public class Project
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
       
        public ICollection<Item> Items { get; set; }
        public ICollection<Page> Pages { get; set; }
        public ICollection<ContentType> ContentTypes { get; set; }
        public ICollection<Template> Templates { get; set; }
    }
}
