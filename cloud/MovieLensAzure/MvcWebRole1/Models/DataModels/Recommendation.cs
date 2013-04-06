using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcWebRole1.Models.DataModels
{
    public class Recommendation
    {
        /// <summary>
        /// Gets or sets the movie id.
        /// </summary>
        /// <value>
        /// The movie id.
        /// </value>
        public double MovieId { get; set; }

        /// <summary>
        /// Gets or sets the movie title.
        /// </summary>
        /// <value>
        /// The movie title.
        /// </value>
        public string MovieTitle { get; set; }

        /// <summary>
        /// Gets or sets the stars.
        /// </summary>
        /// <value>
        /// The stars.
        /// </value>
        public decimal Stars { get; set; }

        /// <summary>
        /// Gets or sets the count.
        /// </summary>
        /// <value>
        /// The count.
        /// </value>
        public double Count { get; set; }
    }
}