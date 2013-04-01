using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieLens.Models.DataModels
{
    public class Rating
    {
        /// <summary>
        /// Gets or sets the movie title.
        /// </summary>
        /// <value>
        /// The movie title.
        /// </value>
        public string MovieTitle { get; set; }

        /// <summary>
        /// Gets or sets the movie id.
        /// </summary>
        /// <value>
        /// The movie id.
        /// </value>
        public double MovieId { get; set; }

        /// <summary>
        /// Gets or sets the rating.
        /// </summary>
        /// <value>
        /// The rating.
        /// </value>
        public decimal Stars { get; set; }
    }
}