using System;
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

            var movieList = new List<Movie>
            {
                new Movie {Name = "Shrack", Id=1},
                new Movie {Name = "Walle-E", Id=2},
                new Movie {Name = "Die Hard", Id=3},
                new Movie {Name = "Games ot Throne", Id=4},
                new Movie {Name = "Batman", Id=5}
            };
 

            var viewModel = new MovieIndexViewModel
            {
                Movies = movieList
            };

            return View(viewModel);
        }

        [Route("movies/{id}")]
        public ActionResult Get(int id)
        {

            var movieList = new List<Movie>
            {
                new Movie {Name = "Shrack", Id=1},
                new Movie {Name = "Walle-E", Id=2},
                new Movie {Name = "Die Hard", Id=3},
                new Movie {Name = "Games ot Throne", Id=4},
                new Movie {Name = "Batman", Id=5}
            };

            var selectedMovie = movieList.Find(x => x.Id.Equals(id));

            if (selectedMovie != null)
            {
                var viewModel = new MovieGewViewModel
                {
                    Movie = selectedMovie
                };
                return View(viewModel);
            }
            else
            {
                return HttpNotFound();
            }
        }

        [Route("movies/released/{year:regex(\\d{4})}/{month:range(1, 12)}")] // possible COnstraints: min, max, minlength, maxlength, int, float, guid 
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

    }
}