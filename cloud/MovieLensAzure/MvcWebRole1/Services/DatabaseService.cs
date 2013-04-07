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

        public Collection<double> GetRecommendationUsers(double userId)
        {
            var model = new Collection<double>();

            var query =
@"select distinct [user_id] from ratings
where [user_id] != @userId and movie_id in
     (select top 5 movie_id from ratings where [user_id] = @userId and rating >= 3 order by rating)
   and rating >= 3";

            var command = new SqlCommand(query, this.Connection);
            command.Parameters.Add(new SqlParameter("@userId", userId));
            command.CommandTimeout = 600;

            this.Connection.Open();

            using (var reader = command.ExecuteReader(CommandBehavior.CloseConnection))
            {
                while (reader.Read())
                {
                    var d = (Int64)reader["user_id"];
                    model.Add(d);
                }
            }

            return model;
        }

        public Collection<Recommendation> GetRecommendations(double userId, double[] userIds)
        {
            var model = new Collection<Recommendation>();
            var str = string.Join(",", userIds.Take(15000));

            var query = string.Format(
@"select top 25 movie_id, m.title, AVG(rating) as avgrating, COUNT(rating) as [count]
  from ratings
  inner join movies as m
  on movie_id = m.id
where  [user_id] in ({0})
 and movie_id not in (select movie_id from ratings where [user_id] = @userId and rating >= 3)
group by movie_id, title
order by avgrating desc", str);

            this.Connection.Open();

            var command = new SqlCommand(query, this.Connection);
            command.Parameters.Add(new SqlParameter("@userId", userId));
            command.CommandTimeout = 600;

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var r = new Recommendation();
                    r.MovieTitle = (string)reader["title"];
                    r.MovieId = (Int64)reader["movie_id"];
                    r.Stars = (decimal)reader["avgrating"];
                    r.Count = (int)reader["count"];
                    model.Add(r);
                }
            }

            return model;
        }

        public Collection<Recommendation> GetRecommendationsByMovie(double movieId)
        {
            throw new NotImplementedException();
        }
    }
}