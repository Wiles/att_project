using System.IO;
using System.Net;

namespace MvcWebRole1
{
    public static class RequestHelper
    {
        public static TModel Call<TModel>(string url) where TModel : new()
        {
            var req = HttpWebRequest.Create(url);

            using (var response = req.GetResponse())
            using (var stream = response.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                return JsonHelper.Deserialize<TModel>(reader.ReadToEnd());
            }
        }
    }
}