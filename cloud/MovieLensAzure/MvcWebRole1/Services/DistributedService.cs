using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcWebRole1.Models;
using System.Collections.ObjectModel;
using System.Net;
using System.IO;
using MvcWebRole1.Models.DataModels;

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
            var model = new RatingsModel();

            var url = this.WorkerUrls.First();

            var str = url.ToString() + "/Service/Ratings?userId=" + userId;

            var start = DateTime.Now;

            model.Ratings = RequestHelper.Call<Collection<Rating>>(str);

            model.ElapsedTime = DateTime.Now.Subtract(start).TotalMilliseconds;

            return model;
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