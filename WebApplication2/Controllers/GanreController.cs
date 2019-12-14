using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class GanreController : Controller
    {
        // GET: Ganre
        public ActionResult Index()
        {
            using (Model1 db = new Model1()) 
            {
                var ganres = db.Ganres.OrderBy(g => g.Name).ToList();
                return View(ganres);
            }
                
        }
    }
}