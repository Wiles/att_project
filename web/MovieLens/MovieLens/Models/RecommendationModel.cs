using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.ObjectModel;
using MovieLens.Models.DataModels;

namespace MovieLens.Models
{
    public class RecommendationModel
    {
        /// <summary>
        /// Gets or sets the movie id.
        /// </summary>
        /// <value>
        /// The movie id.
        /// </value>
        public double MovieId { get; set; }

        /// <summary>
        /// Gets or sets the recommendations.
        /// </summary>
        /// <value>
        /// The recommendations.
        /// </value>
        public Collection<Recommendation> Recommendations { get; set; }

        /// <summary>
        /// Gets or sets the elapsed time.
        /// </summary>
        /// <value>
        /// The elapsed time.
        /// </value>
        public double ElapsedTime { get; set; }
    }
}