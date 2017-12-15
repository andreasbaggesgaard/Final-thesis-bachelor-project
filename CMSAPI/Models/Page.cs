using System;
using System.Collections.Generic;

namespace CMSAPI.Models
{
    public class Page
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string Image { get; set; }      
        public int TemplateID { get; set; }
        public string ProjectID { get; set; }

        public Template Template { get; set; }
        public ICollection<Item> Items { get; set; }
        public Project Project { get; set; }
        public Menu Menu { get; set; }


    }
}
