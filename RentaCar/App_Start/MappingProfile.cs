using AutoMapper;
using RentaCar.Dtos;
using RentaCar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentaCar.App_Start
{
    public class MappingProfile:Profile
    {

        public MappingProfile() {

            Mapper.CreateMap<Car, CarDto>().ReverseMap();
            Mapper.CreateMap<Customer, CustomerDto>().ReverseMap();
            Mapper.CreateMap<Rental, RentalDto>().ReverseMap();
        
        }
    }
}