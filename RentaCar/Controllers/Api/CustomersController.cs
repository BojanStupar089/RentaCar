using AutoMapper;
using RentaCar.Dtos;
using RentaCar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace RentaCar.Controllers.Api
{
    public class CustomersController : ApiController
    {

        private RentaCarEntities _context;
        public CustomersController() {

         _context = new RentaCarEntities();
        }


        public IEnumerable<CustomerDto> GetCustomer(){
            
            return _context.Customers.ToList().Select(Mapper.Map<Customer, CustomerDto>);
        }

        public IHttpActionResult GetCustomer(int id) {

            var customer = _context.Customers.SingleOrDefault(c => c.CustomerId == id);

            if (customer == null) {

                return NotFound();
            }

            return Ok(Mapper.Map<Customer, CustomerDto>(customer));
        }

        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto) {

            if (!ModelState.IsValid) {
               return BadRequest();
            }

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDto.CustomerId = customer.CustomerId;
            return Created(new Uri(Request.RequestUri + "/" + customer.CustomerId), customerDto);
        }


        [HttpPut]
        public void UpdateCustomer(int id,CustomerDto customerDto) {

            if (!ModelState.IsValid)
            throw new HttpResponseException(HttpStatusCode.BadRequest);
            
            var customer = _context.Customers.SingleOrDefault(c => c.CustomerId == id);

            if (customer == null) 
            throw new HttpResponseException(HttpStatusCode.NotFound);
            
            customer.Name = customerDto.Name;
            customer.DriverLicNo = customerDto.DriverLicNo;

            _context.SaveChanges();

        }


        [HttpDelete]
        public void DeleteCustomer(int id) {

            var customer = _context.Customers.SingleOrDefault(c => c.CustomerId == id);

            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            
            _context.Customers.Remove(customer);
            _context.SaveChanges();

        }
    }
}
