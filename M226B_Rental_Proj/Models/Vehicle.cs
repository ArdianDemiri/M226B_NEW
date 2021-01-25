using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace M226B_Rental_Proj.Models
{
    public class Vehicle
    {
        public int ID { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int PricePerDay { get; set; }
        public int PS_Power { get; set; }
        public bool IsFullTank { get; set; }
        public virtual Company Company { get; set; }
        public string Type { get; set; }
        public virtual IEnumerable<Order> Orders { get; set; }
    }
}