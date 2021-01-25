using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace M226B_Rental_Proj.Models
{
    public class ChartModel
    {
        public List<Order> Orders { get; set; }
        public List<Order> CarList { get; set; }
        public List<Order> LKWList { get; set; }
        public int CarSumme { get; set; }
        public int LKWSumme { get; set; }
    }
}