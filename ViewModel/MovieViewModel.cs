using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieRentaMVC.Models;
namespace MovieRentaMVC.ViewModel
{
    public class MovieViewModel
    {
        public List<Movie> movies { get; set; }
        public List<Genre> genre { get; set; }
    }
}