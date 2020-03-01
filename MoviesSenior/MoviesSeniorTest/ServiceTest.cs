using MoviesSenior;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MoviesSeniorTest
{
    public class ServiceTest
    {
        [Fact]
        public void MoviesData()
        {
            MoviesSenior.Util.Movies.MoviesRequest("spi");
        }
        [Fact]
        public static void Values_Get_ReturnsOkResponse()
        {
            string action = string.Format("https://jsonmock.hackerrank.com/api/movies/search/?Title={0}&page={1}", "wor", 1);
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, action);
            HttpResponseMessage response = HttpInstance.GetHttpClientInstance().SendAsync(request).Result;
            response.EnsureSuccessStatusCode();
        }
    }
}
