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
        /// Action for recommendations results.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <returns>Recommendations partial view.</returns>
        public ActionResult Recommendations(double userId)
        {
            var recommendations = this.Service.GetRecommendations(userId);
            return PartialView(recommendations);
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
