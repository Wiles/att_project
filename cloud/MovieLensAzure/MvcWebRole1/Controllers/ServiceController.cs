using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcWebRole1.Services;
using System.Configuration;

namespace MvcWebRole1.Controllers
{
    public class ServiceController : Controller
    {
        public ServiceController()
        {
            this.DbService = new DatabaseService(ConfigurationManager.ConnectionStrings["MovieLens"].ConnectionString);
        }

        public DatabaseService DbService { get; set; }

        public ActionResult Ratings(double userId)
        {
            var ratings = this.DbService.GetRatings(userId);
            return Json(ratings, JsonRequestBehavior.AllowGet);
        }
    }
}
