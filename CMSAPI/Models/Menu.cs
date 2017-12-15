using System;
using System.Collections.Generic;

namespace CMSAPI.Models
{
    public class Menu
    {
        public int PageID { get; set; }
        public string ProjectID { get; set; }

        public ICollection<Page> Pages { get; set; }
        public Project Project { get; set; }
    }
}
