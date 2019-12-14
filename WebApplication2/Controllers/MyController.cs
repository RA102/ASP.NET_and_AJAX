using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class MyController : Controller
    {
        // GET: My
        public ActionResult Index()
        {
            using (Model1 db = new Model1())
            {
                var authors = db.Authors.ToList();
            
                return View(authors);
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Authors author)
        {
            using (Model1 db = new Model1())
            {
                if(ModelState.IsValid)
                {               
                    db.Authors.Add(author);
                    db.SaveChanges();
                } else {
                    return View(author);
                }
                
                //RedirectToAction("Index");
            }
            return RedirectToAction("Index");

        }

        public ActionResult Hi()
        {
            return Content("<div>Hi</div>");
        }

        public ActionResult Details()
        {
            return new HttpStatusCodeResult(204);
            //return View();
        }

    }
}