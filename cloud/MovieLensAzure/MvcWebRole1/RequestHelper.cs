using System.IO;
using System.Net;

namespace MvcWebRole1
{
    public static class RequestHelper
    {
        public static TModel Get<TModel>(string url) where TModel : new()
        {
            var req = HttpWebRequest.Create(url);

            using (var response = req.GetResponse())
            using (var stream = response.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                return JsonHelper.Deserialize<TModel>(reader.ReadToEnd());
            }
        }

        public static TModel Post<TModel>(string url, string body) where TModel : new()
        {
            var req = HttpWebRequest.Create(url);
            req.Method = "POST";
            req.Timeout = int.MaxValue;

            using (var stream = req.GetRequestStream())
            using (var writer = new StreamWriter(stream))
            {
                writer.Write(body);
            }

            using (var response = req.GetResponse())
            using (var stream = response.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                return JsonHelper.Deserialize<TModel>(reader.ReadToEnd());
            }
        }
    }
}