using System.Collections.ObjectModel;
using MvcWebRole1.Models.DataModels;

namespace MvcWebRole1.Models
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