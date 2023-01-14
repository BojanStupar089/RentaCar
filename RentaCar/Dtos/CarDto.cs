using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RentaCar.Dtos
{
    public class CarDto
    {
        public int CarId { get; set; }
        [Required]
        public string Manufacturer { get; set;}
        [Required]
        public string Model { get; set; }
        [Required]
        public string LicensePlate { get; set; }
        public int Year { get; set; }
        
        [DefaultValue(true)]
        public bool Available { get; set; }
    }
}