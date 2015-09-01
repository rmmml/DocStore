using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace DocStore.Models
{
    public class DocumentContext : DbContext
    {
        public DbSet<Document> Documents { get; set; }
    }
}