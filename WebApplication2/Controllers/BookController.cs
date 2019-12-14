using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult Index()
        {
            using (Model1 db = new Model1()) 
            {
                var books = db.Books.OrderBy(b=>b.Title).ToList();
                return View(books);
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            using (Model1 db = new Model1()) 
            {
                ViewBag.AuthorList = new SelectList(db.Authors.ToList(), "Id", "FirstName");
                ViewBag.GanreList = new SelectList(db.Ganres.ToList(), "Id", "Name");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Create(Books book)
        {
            using (Model1 db = new Model1()) {
                if (ModelState.IsValid) {
                    db.Books.Add(book);
                    db.SaveChanges();
                }
                else {
                    return View(book);
                }
            }
            return Redirect("index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            using (Model1 db = new Model1()) 
            {
                var book = db.Books.Where(b => b.Id == id).FirstOrDefault();
                ViewBag.AuthorList = new SelectList(db.Authors.ToList(), "Id", "FirstName");
                ViewBag.GanreList = new SelectList(db.Ganres.ToList(), "Id", "Name");

                return View(book);
            }
            
        }

        [HttpPost]
        public ActionResult Edit(Books book)
        {
            using(Model1 db = new Model1()) 
            {

                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }           
            
        }

        public ActionResult Delete(int id)
        {
            return View();
        }
    }
}