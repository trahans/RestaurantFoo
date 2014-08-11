using Restaurant_Foo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Restaurant_Foo.Controllers
{
    public class HomeController : Controller
    {
        RestaurantFooDB _db = new RestaurantFooDB();

        public ActionResult Index(string searchTerm = null)
        {
            var model =
                _db.MenuItems
                .OrderBy(r => r.Name)
                .Where(r => searchTerm == null || r.Name.Contains(searchTerm) || r.Description.Contains(searchTerm));

            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (_db != null)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
