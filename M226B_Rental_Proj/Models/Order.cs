using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace M226B_Rental_Proj.Models
{
    public class Order
    {
        public int ID { get; set; }
        public virtual Vehicle Vehicle { get; set; }
        public virtual ApplicationUser User { get; set; }
        public DateTime DateTime { get; set; }
        public bool IsCar { get; set; }
        public int PriceVehicle { get; set; }
        public bool IsTaken { get; set; }
    }
}