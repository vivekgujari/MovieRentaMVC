using AutoMapper;
using MovieRentaMVC.Dtos;
using MovieRentaMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Model;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace MovieRentaMVC.Controllers.api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        //[HttpGet]
        public IHttpActionResult GetMovies()
        {
            return Ok(_context.movies.ToList().Select(Mapper.Map<Movie, MovieDto>));
        }

        [HttpGet]
        public IHttpActionResult GetMovies(int Id)
        {
            var movie = _context.movies.SingleOrDefault(c => c.Id == Id);
            if (movie == null)
                return NotFound();
            return Ok(Mapper.Map<Movie, MovieDto>(movie));
        }

        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var movies = Mapper.Map<MovieDto, Movie>(movieDto);
            _context.movies.Add(movies);
            _context.SaveChanges();
            movieDto.Id = movies.Id;
            return Created(new Uri(Request.RequestUri + "/" + movies.Id), movieDto);
        }

        [HttpPut]
        public IHttpActionResult UpdateMovie(MovieDto movieDto, int Id)
        {
            var movieInDb = _context.movies.SingleOrDefault(c => c.Id == Id);
            if (movieInDb == null)
                return NotFound();
            Mapper.Map<MovieDto, Movie>(movieDto, movieInDb);
            _context.SaveChanges();
            return Created(new Uri(Request.RequestUri + "/" + movieInDb.Id), movieDto);
        }

        [HttpDelete]
        public IHttpActionResult DeleteMovie(int Id)
        {
            var movieInDb = _context.movies.SingleOrDefault(c => c.Id == Id);
            if (movieInDb == null)
                return NotFound();
            _context.movies.Remove(movieInDb);
            _context.SaveChanges();
            return Ok();
        }
    }
}
