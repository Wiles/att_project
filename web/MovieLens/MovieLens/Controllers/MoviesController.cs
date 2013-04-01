using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieLens.Services;
using System.Configuration;

namespace MovieLens.Controllers
{
    public class MoviesController : Controller
    {
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="MoviesController" /> class.
        /// </summary>
        public MoviesController()
        {
            this.Service = new MoviesService(ConfigurationManager.ConnectionStrings["MovieLens"].ConnectionString);
        }

        /// <summary>
        /// Gets or sets the service.
        /// </summary>
        /// <value>
        /// The service.
        /// </value>
        private MoviesService Service { get; set; }

        /// <summary>
        /// Action for the home page.
        /// </summary>
        /// <returns>Index view.</returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Action for the users page.
        /// </summary>
        /// <returns>Users view.</returns>
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
        /// Action for the movies page.
        /// </summary>
        /// <returns>Movies view.</returns>
        public ActionResult Movies()
        {
            return View();
        }

        /// <summary>
        /// Action for the tags page.
        /// </summary>
        /// <returns>Tags view.</returns>
        public ActionResult Tags()
        {
            return View();
        }

        /// <summary>
        /// Action for the genres page.
        /// </summary>
        /// <returns>Genres view.</returns>
        public ActionResult Genres()
        {
            return View();
        }
    }
}
