using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;
using Vidly.Dtos;
using AutoMapper;


namespace Vidly.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();

        }
        // GET /api/customers
        public IHttpActionResult GetCustomers(string query = null)
        {
            var customersQuery = _context.Customers.Include(c => c.MembershipType);

            if(!String.IsNullOrWhiteSpace(query)) {
                customersQuery = customersQuery.Where(c => c.Name.Contains(query));
            }

            var customerDtos = customersQuery.ToList().Select(Mapper.Map<Customer, CustomersDto>);

            return Ok(customerDtos);
        }

        //GET /api/customers/1
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            
            if(customer == null)
            {
                //throw new HttpResponseException(HttpStatusCode.NotFound);
                return NotFound();
            }

            return Ok(Mapper.Map<Customer, CustomersDto>(customer));

        }

        //POST /api/customers
        [HttpPost]
        //API should never return or receive domain objects such as Customer in this case
        //we are opening up security holes in our application
        public IHttpActionResult CreateCustomer(CustomersDto customerDto) //restful convention says when creating a resource, the status code returned should be 201 for created
        {
            if(!ModelState.IsValid)
            {
                //throw new HttpResponseException(HttpStatusCode.BadRequest);
                return BadRequest();
            }
                                        //source    target
            var customer = Mapper.Map<CustomersDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();


            customerDto.Id = customer.Id;
            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto); //URI = Unified Resource Identier i.e /api/customers/10
        }

        [HttpPut]
        //PUT /api/customers/1
        public void UpdateCustomer(int id, CustomersDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if(customerInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            Mapper.Map(customerDto, customerInDb); //the compiler can infer our source and target types so we don't need the <CustomersDto, Customer>

            _context.SaveChanges();
        }

        //DELETE /api/customers/1
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customerinDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _context.Customers.Remove(customerinDb);
            _context.SaveChanges();

        }
    }
}
