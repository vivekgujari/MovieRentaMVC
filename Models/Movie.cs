using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieRentaMVC.Models
{
    public class Movie
    {
        [Required]
        public string Name { get; set; }
        public int Id { get; set; }
        public Genre genre { get; set; }
        public int genreId { get; set; }
        public int InStock { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime DateAdded { get; set; }
    }
}