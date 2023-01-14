using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RentaCar.Dtos
{
    public class CustomerDto
    {
        public int CustomerId { get; set; }
        [Required]
        public string Name { get; set; }
        public int DriverLicNo { get; set; }
    }
}