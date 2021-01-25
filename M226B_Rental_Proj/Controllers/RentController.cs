using M226B_Rental_Proj.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace M226B_Rental_Proj.Controllers
{
    public class RentController : Controller
    {
        //Global 
        double _money = 0.0;

        // GET: Rent
        [Authorize]
        public ActionResult Index(int id)
        {
            var userId = User.Identity.GetUserId();
            if (userId != null)
            {
                using (ApplicationDbContext context = new ApplicationDbContext())
                {
                    ApplicationUser user = context.Users.Find(userId);
                    Vehicle vehicle = context.Vehicles.Find(id);
                    var model = new OrderModel
                    {
                        BrandName = vehicle.Brand,
                        ModelName = vehicle.Model,
                        PricePerDay = vehicle.PricePerDay,
                        UserName = user.UserName,
                        UserID = user.Id,
                        VehicleID = vehicle.ID,
                        Orders = context.Orders.Where(n => n.Vehicle.ID == vehicle.ID && n.DateTime >= DateTime.Now).ToList(),
                        //Orders = context.Orders.Where(n => n.Vehicle.ID == vehicle.ID).Where(n => n.DateTime.Date > DateTime.Now.Date).ToList()
                        _Vehicle = context.Vehicles.Where(n => n.ID == id).First()
                    };
                    return View(model);
                }
            }
            return View();
        }


        [HttpPost]
        // TO DO HERE FROM 04.01.2021: ISCAR Error and get Information from the string in Object Vehicle / Car / LKW
        public ActionResult Index(DateTime rentDate, string UserID, int VehicleID, int _PricePerDay = 500, bool _IsCar = true, double money = 0.0)
        {
            using(ApplicationDbContext db = new ApplicationDbContext())
            {
                OrderModel model = new OrderModel();
                
                if(model.IsUsed(rentDate, VehicleID) == true)
                {
                    if (rentDate >= DateTime.Now)
                    {
                        ApplicationUser user = db.Users.Find(UserID);
                        Vehicle vehicle = db.Vehicles.Find(VehicleID);
                        if (money >= vehicle.PricePerDay || money == 0.0)
                        {
                            if(money > vehicle.PricePerDay)
                            {
                                money = money - vehicle.PricePerDay;
                                _money = money;
                            } else
                            {
                                money = 0;
                            }
                            Order order = new Order { User = user, Vehicle = vehicle, DateTime = rentDate, PriceVehicle = _PricePerDay, IsCar = _IsCar };
                            db.Orders.Add(order);
                            db.SaveChanges();
                            return RedirectToAction("ThankYou");
                        } else { return View(nameof(Reserved)); }
                    } else { return View(nameof(Reserved)); }
                }
                else
                {
                    return View(nameof(Reserved));
                }
            }
        }

        [Authorize]
        public ActionResult ThankYou(double moneyBack = 0)
        {
            moneyBack = _money;
            MoneyBackModell model = new MoneyBackModell();
            model.MoneyBack = moneyBack;
            return View(model);
        }

        [Authorize]
        public ActionResult Reserved()
        {
            return View();
        }
    }
}