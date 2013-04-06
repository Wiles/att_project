using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcWebRole1.Models;

namespace MvcWebRole1.Services
{
    public class DistributedService
    {
        public DistributedService(params string[] workers)
        {

        }

        public RatingsModel GetRatings(double userId)
        {
            throw new NotImplementedException();
        }

        public RecommendationModel GetRecommendations(double userId)
        {
            throw new NotImplementedException();
        }

        public RecommendationModel GetRecommendationsByMovie(double movieId)
        {
            throw new NotImplementedException();
        }
    }
}