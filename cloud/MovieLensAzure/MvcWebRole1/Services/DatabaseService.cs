using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.ObjectModel;
using MvcWebRole1.Models.DataModels;
using System.Data.SqlClient;
using System.Data;

namespace MvcWebRole1.Services
{
    public class DatabaseService
    {
        public DatabaseService(string connectionString)
        {
            this.Connection = new SqlConnection(connectionString);
        }

        public SqlConnection Connection { get; set; }

        public Collection<Rating> GetRatings(double userId)
        {
            var model = new Collection<Rating>();

            var query =
@"select title, movie_id, rating
  from ratings
  inner join movies 
  on movie_id = id
where user_id = @userId";

            var command = new SqlCommand(query, this.Connection);
            command.Parameters.Add(new SqlParameter("@userId", userId));

            this.Connection.Open();
            using (var reader = command.ExecuteReader(CommandBehavior.CloseConnection))
            {
                while (reader.Read())
                {
                    var r = new Rating();
                    r.MovieTitle = (string)reader["title"];
                    r.MovieId = (Int64)reader["movie_id"];
                    r.Stars = (decimal)reader["rating"];
                    model.Add(r);
                }
            }

            return model;
        }

        public Collection<Recommendation> GetRecommendations(double userId)
        {
            throw new NotImplementedException();
        }

        public Collection<Recommendation> GetRecommendationsByMovie(double movieId)
        {
            throw new NotImplementedException();
        }
    }
}