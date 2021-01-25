using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace M226B_Rental_Proj.Models
{
    public class Car : Vehicle
    {
        public int Seats { get; set; }
        public string PlateNumber { get; set; }
    }
}