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

            // var customers = GetCustomers(); 
            var customers = _context.Customers.Include(c => c.MembershipType).ToList(); // to join by foreing key. Need to use System.Data.Entity

            // var viewModel = new CustomerIndexViewModel
            // {
            //     Customers = customers
            // };

            // return View(viewModel);
            return View(customers);
        }

        [Route("customers/{id}")]
        public ActionResult Get(int id)
        {
            //var customerList = new List<Customer>
            //{
            //    new Customer() { Id=1, Name = "John Weak" },
            //    new Customer() { Id=2, Name = "John Show" },
            //    new Customer() { Id=3, Name = "Donald Trump" },
            //    new Customer() { Id=4, Name = "Mad Max" },
            //    new Customer() { Id=5, Name = "Dart Waider" }
            //};

            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
            //var selectedCustomer = customerList.Find(x => x.Id.Equals(id));

            if (customer == null)
                return HttpNotFound();
            
            return View(customer);

        }

        //private IEnumerable<Customer> GetCustomers()
        //{
        //    return new List<Customer>
        //    {
        //        new Customer() { Id=1, Name = "John Weak" },
        //        new Customer() { Id=2, Name = "John Show" },
        //        new Customer() { Id=3, Name = "Donald Trump" },
        //        new Customer() { Id=4, Name = "Mad Max" },
        //        new Customer() { Id=5, Name = "Dart Waider" }
        //    };

        //    //Get 
        //}
    }
}