using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentaCar.Dtos
{
    public class CarDto
    {
        public int CarId { get; set; }

        public string Manufacturer { get; set;}

        public string Model { get; set; }

        public string LicencePlate { get; set; }

        public int Year { get; set; }

        public bool Available { get; set; }
    }
}