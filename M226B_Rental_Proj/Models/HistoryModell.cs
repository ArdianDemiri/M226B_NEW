using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace M226B_Rental_Proj.Models
{
    public class HistoryModell
    {
        public List<Order> Orders { get; set; }
        public List<Vehicle> Vehicles { get; set; }
    }
}