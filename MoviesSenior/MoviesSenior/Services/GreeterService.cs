using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using MoviesSenior.Model;
using Newtonsoft.Json;

namespace MoviesSenior
{
    public class GreeterService : Greeter.GreeterBase
    {
        private readonly ILogger<GreeterService> _logger;
        public GreeterService(ILogger<GreeterService> logger)
        {
            _logger = logger;
        }
        public override Task<MovieReply> MoviesData(MovieRequest request, ServerCallContext context)
        {
            List<Movies> movie = Util.Movies.MoviesRequest(request.Name);
            DataResult dataResults = Util.Settings.MoviesSettings(movie);
            

            return Task.FromResult(new MovieReply
            {
                Movies = JsonConvert.SerializeObject(movie),
                DataResult = JsonConvert.SerializeObject(dataResults)
            });
        }
    }
}
