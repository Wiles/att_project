using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieLens.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.CurrentTab = "tab_index";
            return View();
        }

        public ActionResult Users()
        {
            ViewBag.CurrentTab = "tab_users";
            return View();
        }

        public ActionResult Movies()
        {
            ViewBag.CurrentTab = "tab_movies";
            return View();
        }

        public ActionResult Tags()
        {
            ViewBag.CurrentTab = "tab_tags";
            return View();
        }

        public ActionResult Genres()
        {
            ViewBag.CurrentTab = "tab_genres";
            return View();
        }
    }
}
