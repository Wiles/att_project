using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using MvcWebRole1.Models;
using MvcWebRole1.Models.DataModels;
using System.Threading;

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


            this.DbService = new DatabaseService(ConfigurationManager.ConnectionStrings["MovieLens"].ConnectionString);

            this.WorkerUrls = new Collection<Uri>();

            foreach (var url in workers)
            {
                this.WorkerUrls.Add(new Uri(url));
            }
        }

        private Collection<Uri> WorkerUrls { get; set; }

        private DatabaseService DbService { get; set; }

        public RatingsModel GetRatings(double userId)
        {
            var model = new RatingsModel();

            var url = this.WorkerUrls.First();

            var str = url.ToString() + "/Service/Ratings?userId=" + userId;

            var start = DateTime.Now;

            model.Ratings = RequestHelper.Get<Collection<Rating>>(str);

            model.ElapsedTime = DateTime.Now.Subtract(start).TotalMilliseconds;

            return model;
        }

        public RecommendationModel GetRecommendations(double userId)
        {
            var model = new RecommendationModel();
            var tasks = new Task[this.WorkerUrls.Count];

            var start = DateTime.Now;

            var userIds = this.DbService.GetRecommendationUsers(userId);
            var part = userIds.Count / this.WorkerUrls.Count;
            var args = new string[this.WorkerUrls.Count];

            for (int i = 0; i < this.WorkerUrls.Count; i++)
            {
                if (i == this.WorkerUrls.Count - 1)
                {
                    args[i] = string.Join(",", userIds.Skip(i * part));
                }
                else
                {
                    args[i] = string.Join(",", userIds.Skip(i * part).Take(part));
                }
            }

            var ret = new IEnumerable<Recommendation>[this.WorkerUrls.Count];
            var index = 0;

            foreach (var worker in this.WorkerUrls)
            {
                var task = Task.Factory.StartNew(() =>
                {
                    var i = index;
                    var url = worker.ToString() + "/Service/Recommendations?userId=" + userId.ToString();
                    ret[i] = RequestHelper.Post<Collection<Recommendation>>(url, args[i]);
                });

                Thread.Sleep(100);

                tasks[index++] = task;
            }

            Task.WaitAll(tasks);

            var q = new Collection<Recommendation>();
            foreach (var list in ret)
            {
                foreach (var r in list)
                {
                    if (!q.Any(e => e.MovieId == r.MovieId))
                    {
                        q.Add(r);
                    }
                }
            }

            model.Recommendations = new Collection<Recommendation>(q.Take(25).ToList());
            model.ElapsedTime = DateTime.Now.Subtract(start).TotalMilliseconds;

            return model;
        }

        public RecommendationModel GetRecommendationsByMovie(double movieId)
        {
            throw new NotImplementedException();
        }
    }
}