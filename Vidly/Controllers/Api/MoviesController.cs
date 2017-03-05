using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Vidly.DTOs;
using Vidly.Models;
using static Vidly.App_Start.MappingProfile;

namespace Vidly.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET /api/movies
        public IHttpActionResult GetMovies()
        {
            return Ok(_context
                .Movies
                .Include(m => m.Genre)
                .ToList()
                //.Select(Mapper.Map<Movie, MovieDto>)
                );
        }

        // GET /api/movies/id
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (movie == null)
                return NotFound();

            return Ok(Mapper.Map<Movie, MovieDto>(movie));
        }

        // POST /api/movies
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto MovieDto) // PostCustom method name don't requires [HttpPost]
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = Mapper.Map<MovieDto, Movie>(MovieDto);
            _context.Movies.Add(movie);
            _context.SaveChanges();

            MovieDto.Id = movie.Id;

            return Created(new Uri(Request.RequestUri + "/" + movie.Id), MovieDto);
        }

        // PUT /api/movies/id
        [HttpPut]
        public IHttpActionResult UpdateMovie(int id, MovieDto MovieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest("Data object is Invalid");

            var movieInDb = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (movieInDb == null)
                return NotFound();

            Mapper.Map<MovieDto, Movie>(MovieDto, movieInDb);

            _context.SaveChanges();

            var updatedMovie = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (updatedMovie == null)
                return BadRequest();

            return Ok(Mapper.Map<Movie, MovieDto>(updatedMovie));

        }

        // Delete /api/movies/id
        [HttpDelete]
        public IHttpActionResult DeleteMovie(int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (movieInDb == null)
                return NotFound();

            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();

            var deletedMovie = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (deletedMovie != null)
                return NotFound();

            return Ok("Record Deleted");

        }

    }
}
