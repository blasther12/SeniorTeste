using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSenior.Models
{
    public class DataResult
    {
        public List<MoviesByYear> moviesByYears { get; set; }
        public int total { get; set; }
    }
}
