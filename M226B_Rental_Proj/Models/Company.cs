using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace M226B_Rental_Proj.Models
{
    public class Company
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual List<Vehicle> Vehicles { get; set; }
    }
}