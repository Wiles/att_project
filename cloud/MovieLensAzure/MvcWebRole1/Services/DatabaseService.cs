using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.ObjectModel;
using MvcWebRole1.Models.DataModels;

namespace MvcWebRole1.Services
{
    public class DatabaseService
    {
        public Collection<Rating> GetRatings(double userId)
        {
            throw new NotImplementedException();
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