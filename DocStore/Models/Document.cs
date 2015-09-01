using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocStore.Models
{
    public class Document
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Tags { get; set; }
        public string Location { get; set; }
    }
}