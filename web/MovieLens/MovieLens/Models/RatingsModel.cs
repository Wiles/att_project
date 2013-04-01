using System.Collections.ObjectModel;
using MovieLens.Models.DataModels;

namespace MovieLens.Models
{
    public class RatingsModel
    {
        /// <summary>
        /// Gets or sets the elapsed time.
        /// </summary>
        /// <value>
        /// The elapsed time.
        /// </value>
        public double ElapsedTime { get; set; }

        /// <summary>
        /// Gets or sets the ratings.
        /// </summary>
        /// <value>
        /// The ratings.
        /// </value>
        public Collection<Rating> Ratings { get; set; }
    }    
}