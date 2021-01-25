using M226B_Rental_Proj.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace M226B_Rental_Proj.Controllers
{
    public class ReturnController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            if (userId != null)
            {
                using (ApplicationDbContext context = new ApplicationDbContext())
                {
                    ApplicationUser user = context.Users.Find(userId);
                    var model = new HistoryModell
                    {
                        Orders = context.Orders.Where(n => n.User.Id == user.Id).ToList(),
                        Vehicles = context.Vehicles.ToList()
                    };
                    return View(model);
                }
            }
            return View();
        }

        [Authorize]
        public ActionResult Return(int id)
        {
            var userId = User.Identity.GetUserId();
            if (userId != null)
            {
                using (ApplicationDbContext context = new ApplicationDbContext())
                {
                    Order order = context.Orders.Find(id);
                    order.IsTaken = !order.IsTaken;
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View();
        }
    }
}