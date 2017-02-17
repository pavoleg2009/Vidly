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
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {   
            _context.Dispose();
            // base.Dispose(disposing); // authigenerated sting, wasn't in tutor;
        }

        // GET: Customers
        [Route("customers")]
        public ActionResult Index(int? pageIndex, string sortBy)
        {   
            if (!pageIndex.HasValue)
                pageIndex = 1;
            if (String.IsNullOrWhiteSpace(sortBy))
                sortBy = "byName";

            var customers = _context.Customers.Include(c => c.MembershipType).ToList(); // to join by foreing key. Need to use System.Data.Entity

            return View(customers);
        }

        [Route("customers/{id}")]
        public ActionResult Get(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
           
            if (customer == null)
                return HttpNotFound();
            
            return View(customer);

        }

    }
}