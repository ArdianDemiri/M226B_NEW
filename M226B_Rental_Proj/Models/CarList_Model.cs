using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace M226B_Rental_Proj.Models
{
    public class CarList_Model
    {
        public Company _company { get; set; }
        public IEnumerable<Vehicle> _Vehicles { get; set; }

    }
}