using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcWebRole1.Services;
using System.Configuration;
using System.IO;

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

        [HttpPost]
        public ActionResult Recommendations(double userId, string userIds)
        {
            string str;
            using (var reader = new StreamReader(HttpContext.Request.InputStream))
            {
                str = reader.ReadToEnd();
            }

            var list = str.Split(new [] { ',' });
            var ids = new double[list.Length];

            for (int i = 0; i < list.Length; i++)
            {
                ids[i] = double.Parse(list[i]);
            }

            var recommendations = this.DbService.GetRecommendations(userId, ids);
            return Json(recommendations, JsonRequestBehavior.AllowGet);
        }
    }
}
