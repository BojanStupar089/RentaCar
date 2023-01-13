using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentaCar.Dtos
{
    public class RentalDto
    {
        public int RentalId { get; set; }

        public int CustomerId { get; set; }

        public int CarId { get; set; }

        public DateTime DateRented { get; set; }

        public DateTime DateReturned { get; set; }
    }
}