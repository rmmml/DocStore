using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DocStore.Models;
using System.Xml;

namespace DocStore.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        DocumentContext db = new DocumentContext();
        
        [HandleError]
        public ActionResult Index()
        {
            IEnumerable<Document> docs = db.Documents;
            ViewBag.Documents = docs;

            return View();
        }

        [HttpGet]
        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        public ActionResult New(Document doc)
        {
            XmlWriter writer = XmlWriter.Create(Server.MapPath("/Files/" + doc.Title + ".xml"));
            writer.Close();
            doc.CreatedDate = DateTime.Now;
            doc.Author = User.Identity.Name;
            doc.Location = "/Files/" + doc.Title + ".xml";
            
            db.Documents.Add(doc);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Search(string to_find)
        {
            IEnumerable<Document> docs = db.Documents.Where(doc => doc.Title.Contains(to_find) || doc.Tags.Contains(to_find));
            ViewBag.Documents = docs;
            return View("Index");
        }

        public ActionResult Sort(string sort_by)
        {
            switch (sort_by)
            {
                case "Title":
                    ViewBag.Documents = db.Documents.OrderBy(d => d.Title);
                    break;
                case "Author":
                    ViewBag.Documents = db.Documents.OrderBy(d => d.Author);
                    break;
                case "CreatedDate":
                    ViewBag.Documents = db.Documents.OrderBy(d => d.CreatedDate);
                    break;
                case "Tags":
                    ViewBag.Documents = db.Documents.OrderBy(d => d.Tags);
                    break;
            }
            return View("Index");
        }
    }
}
