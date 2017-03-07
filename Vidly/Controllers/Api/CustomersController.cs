using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Vidly.DTOs;
using Vidly.Models;
using static Vidly.App_Start.MappingProfile;

namespace Vidly.Controllers.Api
{
    public class CustomersController : ApiController
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

        // GET /api/customers
        public IHttpActionResult GetCustomers(string query = null)
        //public IEnumerable<CustomerDto> GetCustomers()
        {
            var customersQuerty = _context.Customers
                .Include(c => c.MembershipType);

            if (!String.IsNullOrWhiteSpace(query))
                customersQuerty = customersQuerty.Where(c => c.Name.Contains(query));

            var customerDtos = customersQuerty
                .ToList()
                .Select(mapper.Map<Customer, CustomerDto>)
            ;

            return Ok(customerDtos);
        }

        // GET /api/customers/id
        public IHttpActionResult GetCostomer(int id)
        {
            var customer = _context.Customers
                .Include(c => c.MembershipType)
                .SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return NotFound();
            return Ok(mapper.Map<Customer, CustomerDto>(customer));
        }

        // POST /api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto) // PostCustom method name don't requires [HttpPost]
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customer = mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDto.Id = customer.Id;

            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);
        }

        // PUT /api/customers/id
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest("Data object is Invalid");

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
                return NotFound();

            Mapper.Map<CustomerDto, Customer>(customerDto, customerInDb);

            _context.SaveChanges();

            var updatedCustomer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (updatedCustomer == null)
                return BadRequest();

            return Ok(Mapper.Map<Customer, CustomerDto>(updatedCustomer));

        }

        // Delete /api/customers/id
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
                return NotFound();

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();

            var deletedCustomer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (deletedCustomer != null)
                return NotFound();

            return Ok("Record Deleted");
            
        }
    }
}
