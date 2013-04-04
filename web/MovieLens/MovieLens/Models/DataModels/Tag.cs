using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieLens.Models.DataModels
{
    public class Tag
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>
        /// The id.
        /// </value>
        public double Id { get; set; }

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>
        /// The text.
        /// </value>
        public string Text { get; set; }
    }
}