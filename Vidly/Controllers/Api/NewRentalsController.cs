using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.DTOs;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class NewRentalsController : ApiController
    {
        private ApplicationDbContext _context;

        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // POST api/<controller>
        [HttpPost]
        public IHttpActionResult CreateNewRentals (NewRentalDto newRental)
        {
            if (newRental.MoviesId.Count == 0)
                return BadRequest("Movies list to rent is empty");

            var customer = _context.Customers.Find(newRental.CustomerId);
            if (customer == null)
                return BadRequest("Customer with Id: " + newRental.CustomerId + " not found");

            var movies = _context.Movies.Where(m => newRental.MoviesId.Contains(m.Id)).ToList();
            if (movies.Count != newRental.MoviesId.Count)
                return BadRequest("One or more movieIds are invalid");


            foreach (var movie in movies)
            {   
                if (movie.NumberAvailable == 0)
                    return BadRequest("Movie with Id:" + movie.Id + " is noe available");

                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };

                movie.NumberAvailable--;

                _context.Rentals.Add(rental);
            }

            _context.SaveChanges();

            return Ok();
        }


    }
}