using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.Models.ViewModels
{
    public class MovieViewModel2
    {
        public IEnumerable<MovieModel> Movies { get; set; }
        public Genre? Genre { get; set; }
        public string Title { get; set; }
    }
}
