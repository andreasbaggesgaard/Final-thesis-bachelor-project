using System;
using System.Collections.Generic;

namespace CMSAPI.Models
{
    public class ContentType
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int ProjectID { get; set; }

        public Item Item { get; set; }
        public Project Project { get; set; }

    }
}
