using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace M226B_Rental_Proj.Models
{
    public class OrderModel
    {
        public string BrandName { get; set; }
        public string ModelName { get; set; }
        public int PricePerDay { get; set; }
        public string UserName { get; set; }
        public string UserID { get; set; }
        public int VehicleID { get; set; }
        public List<Order> Orders { get; set; }
        public Vehicle _Vehicle { get; set; }
        public bool IsCar { get; set; }
        public bool IsTaken { get; set; }

        public bool IsUsed(DateTime dateTime, int vehicleID)
        {
            bool notUsed = true;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                Vehicle vehicle = db.Vehicles.Where(n => n.ID == vehicleID).First();
                List<Order> orders = db.Orders.Where(n => n.Vehicle.ID == vehicle.ID).ToList();
                foreach (Order _order in orders)
                {
                    if (_order.DateTime.Date == dateTime.Date)
                    {
                        notUsed = false;
                    }
                }
            }
            return notUsed;
        }
    }
}