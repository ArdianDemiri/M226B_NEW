using M226B_Rental_Proj.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace M226B_Rental_Proj.Controllers
{
    public class AdminCenterController : Controller
    {
        // GET: AdminCenter
        [Authorize]
        public ActionResult Index()
        {
            var UserID = User.Identity.GetUserId();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                ApplicationUser user = db.Users.Find(UserID);
                if(user.IsAdmin)
                {
                    return View();
                } else { return View(nameof(Failed)); }
            }
        }

        [Authorize]
        public ActionResult Failed()
        {
            return View();
        }

        [Authorize]
        public ActionResult AllUsers()
        {
            var UserID = User.Identity.GetUserId();
            using(ApplicationDbContext db = new ApplicationDbContext())
            {
                var model = new AllUsersModell
                {
                    Users = db.Users.ToList()
                };
                return View(model);
            }
        }

        [Authorize]
        public ActionResult Privileges()
        {
            return View();
        }

        [Authorize]
        public ActionResult Charts()
        {
            var UserID = User.Identity.GetUserId();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var model = new ChartModel
                {
                    Orders = db.Orders.ToList(),
                    CarList = db.Orders.Where(n => n.IsCar == true && n.DateTime.Month == DateTime.Now.Month).ToList(),
                    LKWList = db.Orders.Where(n => n.IsCar == false && n.DateTime.Month == DateTime.Now.Month).ToList(),
                    CarSumme = 0,
                    LKWSumme = 0
                };
                return View(model);
            }
        }
    }
}