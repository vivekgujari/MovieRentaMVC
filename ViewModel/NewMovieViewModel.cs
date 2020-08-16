using MovieRentaMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieRentaMVC.ViewModel
{
    public class NewMovieViewModel
    {
        public Movie movies { get; set; }
        public IEnumerable<Genre> genres { get; set; }
    }
}