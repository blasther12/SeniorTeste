using MoviesSenior.Model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MoviesSenior.Util
{
    public class Movies
    {
        public static List<Model.Movies> MoviesRequest(string name)
        {
            List<Model.Movies> movie = new List<Model.Movies>();
            Model.Movies u = new Model.Movies();
            int control = 1;
            for (int i = 0; i < control; i++)
            {
                string action = string.Format("https://jsonmock.hackerrank.com/api/movies/search/?Title={0}&page={1}", name, i);
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, action);
                HttpResponseMessage response = HttpInstance.GetHttpClientInstance().SendAsync(request).Result;
                JObject dados = JObject.Parse(response.Content.ReadAsStringAsync().Result);

                control = dados["data"].ToObject<List<Movies>>().Count() > 0 ? control + 1 : i;
                movie.AddRange(dados["data"].ToObject<List<Model.Movies>>());
            }
            return movie;
        }
    }
}
