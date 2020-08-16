using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure.MappingViews;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using MovieRentaMVC.Models;
using MovieRentaMVC.ViewModel;
using System.Data.Entity.Validation;
using System.Data.SqlClient;

namespace MovieRentaMVC.Controllers
{
    public class MoviesController : Controller
    {
        ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Movies/Random
        public ViewResult Index()
        {
            var movies = _context.movies.ToList();
            var genres = _context.genre.ToList();
            var viewModel = new MovieViewModel
            {
                movies = movies,
                genre = genres
            };
            return View(viewModel);
        }

        public ActionResult New()
        {
            var viewModel = new NewMovieViewModel {
                genres = _context.genre.ToList()
        };
            return View("NewMovieForm", viewModel);
        }

        public ActionResult Edit(int Id)
        {
            var movie = _context.movies.SingleOrDefault(c => c.Id == Id);
            var viewModel = new NewMovieViewModel {
                movies = movie,
                genres = _context.genre.ToList()
            };
            return View("Edit", viewModel);
        }
        public ActionResult Save(Movie movies)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new NewMovieViewModel {
                    movies = movies,
                    genres = _context.genre.ToList()
                };
                return View("NewMovieForm", viewModel);
            }
            if (movies.Id == 0)
            {
                _context.movies.Add(movies);
            }
            else {
                var moviesInDb = _context.movies.Single(c => c.Id == movies.Id);
                moviesInDb.Name = movies.Name;
                moviesInDb.InStock = movies.InStock;
                moviesInDb.ReleaseDate = movies.ReleaseDate;
                moviesInDb.genreId = movies.genreId;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }

        // GET: Movies/Details/Id
        public ActionResult Details(int Id)
        {
            var movies = _context.movies.Include(c => c.genre).SingleOrDefault(c => c.Id == Id);
            return View(movies);
        }
       
    }
}