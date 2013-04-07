using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcWebRole1.Services;

namespace MvcWebRole1.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
            this.Service = new DistributedService(
                    "http://tkempton.cloudapp.net/",
                    "http://samuelewis.cloudapp.net/",
                    "http://hekarwebrole.cloudapp.net/");
        }

        public DistributedService Service { get; set; }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Users()
        {
            return View();
        }
        
        /// <summary>
        /// Action for ratings results.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <returns>Ratings partial view.</returns>
        public ActionResult Ratings(double userId)
        {
            var ratings = this.Service.GetRatings(userId);

            return PartialView(ratings);
        }

        /// <summary>
        /// Action for recommendations results.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <returns>Recommendations partial view.</returns>
        public ActionResult Recommendations(double userId)
        {
            var recommendations = this.Service.GetRecommendations(userId);
            return PartialView(recommendations);
        }

        public ActionResult Movies()
        {
            return View();
        }

        /// <summary>
        /// Recommends movies by movie.
        /// </summary>
        /// <param name="movieId">The movie id.</param>
        /// <returns>Recommendations by movie partial view</returns>
        public ActionResult RecommendByMovie(double movieId)
        {
            var recommendations = this.Service.GetRecommendationsByMovie(movieId);
            return PartialView("Recommendations", recommendations);
        }
    }
}
