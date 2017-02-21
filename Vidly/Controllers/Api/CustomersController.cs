using System;
using System.Collections.Generic;
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
        public IEnumerable<CustomerDto> GetCustomers()
        {
            return _context.Customers.ToList().Select(mapperCustomerToDto.Map<Customer, CustomerDto>);
        }

        // GET /api/customers/id
        public CustomerDto GetCostomer(int id)
        {

            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return mapperCustomerToDto.Map<Customer, CustomerDto>(customer);
        }

        // POST /api/customers
        [HttpPost]
        public CustomerDto CreateCostomer(CustomerDto customerDto) // PostCustom method name don't requires [HttpPost]
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customer = mapperDtoToCustomer.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDto.Id = customer.Id;

            return customerDto;
        }

        // PUT /api/customers/id
        [HttpPut]
        public CustomerDto UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            mapperDtoToCustomer.Map<CustomerDto, Customer>(customerDto, customerInDb);

            _context.SaveChanges();

            var updatedCustomer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (updatedCustomer == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            return mapperCustomerToDto.Map<Customer, CustomerDto>(updatedCustomer);

        }

        // Delete /api/customers/id
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();

            var deletedCustomer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (deletedCustomer != null)
                throw new HttpResponseException(HttpStatusCode.Found);
            
        }
    }
}
