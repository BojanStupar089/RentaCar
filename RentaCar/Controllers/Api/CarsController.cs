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
    public class CarsController : ApiController
    {
        private RentaCarEntities _context;

        public CarsController() {

            _context = new RentaCarEntities();
        }

        public IEnumerable<CarDto> GetCars() {

         return _context.Cars.ToList().Select(Mapper.Map<Car, CarDto>);
        }


        public IHttpActionResult GetCar(int id) {

          var car = _context.Cars.SingleOrDefault(c => c.CarId == id);

            if (car == null) {
              return NotFound();
            }

            return Ok(Mapper.Map<Car, CarDto>(car));
        }

        [HttpPost]
        public IHttpActionResult CreateCar(CarDto carDto) {

            if (!ModelState.IsValid) {
               return BadRequest();
            }

            var car = Mapper.Map<CarDto, Car>(carDto);
            _context.Cars.Add(car);
            _context.SaveChanges();

            carDto.CarId = car.CarId;
            return Created(new Uri(Request.RequestUri + "/" + car.CarId), carDto);
        
        }

        [HttpPut]
        public void UpdateCar(int id, CarDto carDto) {

            if (!ModelState.IsValid)
            throw new HttpResponseException(HttpStatusCode.BadRequest);
            
            var car = _context.Cars.SingleOrDefault(c => c.CarId == id);

            if (car == null)
            throw new HttpResponseException(HttpStatusCode.NotFound);
            
            car.Manufacturer = carDto.Manufacturer;
            car.Model = carDto.Model;
            car.LicensePlate = carDto.LicensePlate;
            car.Year = carDto.Year;
            car.Available = carDto.Available;

            _context.SaveChanges();
}

        [HttpDelete]
        public void DeleteCar(int id) {

            var car = _context.Cars.SingleOrDefault(c => c.CarId == id);

            if (car == null)
            throw new HttpResponseException(HttpStatusCode.NotFound);
            
            _context.Cars.Remove(car);
            _context.SaveChanges();

        }

    }
}
