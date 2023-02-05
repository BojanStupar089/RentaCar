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
    public class RentalsController : ApiController
    {
       private RentaCarEntities _context;

        public RentalsController() {

          _context = new RentaCarEntities();
        }


        public IEnumerable<RentalDto> GetRentals() {

         return _context.Rentals.ToList().Select(Mapper.Map<Rental, RentalDto>);
        }


        public IHttpActionResult GetRental(int id) {

         var rental = _context.Rentals.SingleOrDefault(r => r.RentalId == id);
            
            if (rental == null) {
              return NotFound();
            }

             return Ok(Mapper.Map<Rental, RentalDto>(rental));
        }

        [HttpPost]
        public IHttpActionResult CreateRental(RentalDto rentalDto) {

           if (!ModelState.IsValid) {
              return BadRequest();
            }

            var rental = Mapper.Map<RentalDto, Rental>(rentalDto);
            
            _context.Rentals.Add(rental);
           _context.SaveChanges();

            rentalDto.RentalId = rental.RentalId;

            return Created(new Uri(Request.RequestUri + "/" + rental.RentalId),rentalDto);
        }


        [HttpPut]
        public void UpdateRental(int id, RentalDto rentalDto) {

            if (!ModelState.IsValid)
            throw new HttpResponseException(HttpStatusCode.BadRequest);
            
            var rental = _context.Rentals.SingleOrDefault(r => r.RentalId == id);

            if (rental == null) 
            throw new HttpResponseException(HttpStatusCode.NotFound);
            
            rental.CustomerId = rentalDto.CustomerId;
            rental.CarId = rentalDto.CarId;
            rental.DateRented = rentalDto.DateRented;
            rental.DateReturned = rentalDto.DateReturned;

            _context.SaveChanges();
        }

        [HttpDelete]
        public void DeleteRental(int id) {

            var rental = _context.Rentals.SingleOrDefault(r => r.RentalId == id);

            if (rental == null)
            throw new HttpResponseException(HttpStatusCode.NotFound);
            
            _context.Rentals.Remove(rental);
            _context.SaveChanges();
       
        }
    }
}
