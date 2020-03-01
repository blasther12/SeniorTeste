using MoviesSenior.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesSenior.Util
{
    public class Settings
    {
        public static DataResult MoviesSettings(List<Model.Movies> movies)
        {
            List<MoviesByYear> moviesByYears = new List<MoviesByYear>();
            foreach (var stm in movies.GroupBy(x => x.year).Select(y => new { year = y.Key, total = y.Count() }).OrderBy(k => k.year))
            {
                moviesByYears.Add(new MoviesByYear
                {
                    year = stm.year,
                    movies = stm.total
                });
            }

            DataResult dataResults = new DataResult
            {
                moviesByYears = moviesByYears,
                total = movies.Count()
            };

            return dataResults;
        }
    }
}