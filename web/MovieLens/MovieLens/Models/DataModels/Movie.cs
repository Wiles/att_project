using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.ObjectModel;

namespace MovieLens.Models.DataModels
{
    public class Movie
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
        /// Gets or sets the genres.
        /// </summary>
        /// <value>
        /// The genres.
        /// </value>
        public Collection<Genre> Genres { get; set; }

        /// <summary>
        /// Gets or sets the tags.
        /// </summary>
        /// <value>
        /// The tags.
        /// </value>
        public Collection<Tag> Tags { get; set; }
    }
}