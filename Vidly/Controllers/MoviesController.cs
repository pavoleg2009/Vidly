using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller 
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {   
            _context.Dispose();
            // base.Dispose(disposing);
        }

        // GET: Movies/Random
        public ActionResult Random() // good practice to change to ViewResult - for unit testing
        {
            var movie = new Movie() { Name = "Shrack!" };
            // ViewData["Movie"] = movie; -> @(((Movie) ViewData["Movie"]).Name) in Random.chtml
            var customers = new List<Customer>
            {
                new Customer {Name = "Customer 1"},
                new Customer {Name = "Customer 2"}
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);

            //  return View(movie);
            // return Content("Hello");
            // return HttpNotFound();
            // return RedirectToAction("Index", "Home", new {page = 1, sortBy = "name"});
        }

        public ActionResult Edit(int id)
        {
            return Content("Id=" + id);
        }

        [Route("movies")]
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;
            if (String.IsNullOrWhiteSpace(sortBy))
                sortBy = "name";

            var movies = _context.Movies.Include(m => m.Genre).ToList();
            return View(movies);
        }

        [Route("movies/{id}")]
        public ActionResult Get(int id)
        {

            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }

        [Route("movies/released/{year:regex(\\d{4})}/{month:range(1, 12)}")] // possible COnstraints: min, max, minlength, maxlength, int, float, guid 
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

    }
}