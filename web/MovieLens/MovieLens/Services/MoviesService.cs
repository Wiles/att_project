using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using MovieLens.Models;
using System.Data;
using MovieLens.Models.DataModels;
using System.Collections.ObjectModel;

namespace MovieLens.Services
{
    public class MoviesService
    {
        public MoviesService(string connectionString)
        {
            this.Connection = new SqlConnection(connectionString);
        }

        /// <summary>
        /// Gets or sets the connection.
        /// </summary>
        /// <value>
        /// The connection.
        /// </value>
        private SqlConnection Connection { get; set; }

        /// <summary>
        /// Gets the ratings.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <returns></returns>
        public RatingsModel GetRatings(double userId)
        {
            var model = new RatingsModel();
            model.Ratings = new Collection<Rating>();


            var query =
@"select title, movie_id, rating
  from ratings
  inner join movies 
  on movie_id = id
where user_id = @userId";

            var command = new SqlCommand(query, this.Connection);
            command.Parameters.Add(new SqlParameter("@userId", userId));

            var start = DateTime.Now;

            this.Connection.Open();
            using (var reader = command.ExecuteReader(CommandBehavior.CloseConnection))
            {
                while (reader.Read())
                {
                    var r = new Rating();
                    r.MovieTitle = (string)reader["title"];
                    r.MovieId = (Int64)reader["movie_id"];
                    r.Stars = (decimal)reader["rating"];
                    model.Ratings.Add(r);
                }
            }

            model.ElapsedTime = DateTime.Now.Subtract(start).TotalMilliseconds;

            return model;
        }
    }
}