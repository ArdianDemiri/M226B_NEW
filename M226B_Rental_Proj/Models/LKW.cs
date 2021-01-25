using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace M226B_Rental_Proj.Models
{
    public class LKW : Vehicle
    {
        public string License { get; set; }
        public int MaxWeight { get; set; }
    }
}