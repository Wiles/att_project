using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcWebRole1.Models;
using System.Collections.ObjectModel;

namespace MvcWebRole1.Services
{
    public class DistributedService
    {
        public DistributedService(params string[] workers)
        {
            if (workers.Length == 0)
            {
                throw new ArgumentException("list of workers cannot be empty");
            }

            this.WorkerUrls = new Collection<Uri>();

            foreach (var url in workers)
            {
                this.WorkerUrls.Add(new Uri(url));
            }
        }

        private Collection<Uri> WorkerUrls { get; set; }

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