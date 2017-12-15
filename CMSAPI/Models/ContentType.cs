using System;
using System.Collections.Generic;

namespace CMSAPI.Models
{
    public class ContentType
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public ICollection<Item> Item { get; set; }

    }
}
