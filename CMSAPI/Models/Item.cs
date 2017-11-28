using System;

namespace CMSAPI.Models
{
    public class Item
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int SortNumber { get; set; }
        public bool Used { get; set; }
        public int ContentTypeID { get; set; }
        public int PageID { get; set; }
        public string ProjectID { get; set; }


        public ContentType ContentType { get; set; }
        public Page Page { get; set; }
        public Project Project { get; set; }

    }
}
