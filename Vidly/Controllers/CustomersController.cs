﻿using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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
        }

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                MembershipTypes = membershipTypes
            };
            return View("CustomerForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("CustomerForm", viewModel); // "New" to override MVC convention: to render <New> view, not <Edit> view 
        }

        [HttpPost]
        public ActionResult Save(Customer customer) // model-binding: MVC binds request data to viewModel param
        {   
            if (customer.Id == 0)
                _context.Customers.Add(customer);
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);

                //TryUpdateModel(customerInDb, "", new string[] {"Name", "BrthDate..."}); // recomended in MSDN, but open some security holes

                customerInDb.Name = customer.Name;
                customerInDb.BirthDate = customer.BirthDate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;

            }
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                Console.WriteLine(e);
                
            }
            

            return RedirectToAction("Index", "Customers");
        }
        // GET: Customers
        //[Route("customers")]
        public ActionResult Index(int? pageIndex, string sortBy)
        {   
            if (!pageIndex.HasValue)
                pageIndex = 1;
            if (String.IsNullOrWhiteSpace(sortBy))
                sortBy = "byName";

            var customers = _context.Customers.Include(c => c.MembershipType).ToList(); // to join by foreing key. Need to use System.Data.Entity

            return View(customers);
        }

        //[Route("customers/Details/{id}")]
        //public ActionResult Get(int id)
        //{
        //    var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
           
        //    if (customer == null)
        //        return HttpNotFound();
            
        //    return View(customer);

        //}


    }
}