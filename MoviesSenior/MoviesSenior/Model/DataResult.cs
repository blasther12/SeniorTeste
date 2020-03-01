using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesSenior.Model
{
    public class DataResult
    {
        public List<MoviesByYear> moviesByYears { get; set; }
        public int total { get; set; }
    }
}
