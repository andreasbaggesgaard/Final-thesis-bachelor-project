using System;
using System.Collections.Generic;

namespace CMSAPI.Models
{
    public class Template
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string PreviewImage { get; set; }
        public string ProjectID { get; set; }

        public Project Project { get; set; }
        public ICollection<Page> Pages { get; set; }
    }
}
