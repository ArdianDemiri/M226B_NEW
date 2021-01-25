using M226B_Rental_Proj.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace M226B_Rental_Proj.Controllers
{
    public class VehicleController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult Vehicle()
        {
            return View();
        }

        [Authorize]
        public ActionResult Car()
        {
            var userId = User.Identity.GetUserId();
            if (userId != null)
            {
                using (ApplicationDbContext context = new ApplicationDbContext())
                {
                    ApplicationUser user = context.Users.Find(userId);
                    Company company = context.Companies.FirstOrDefault();
                    var model = new CarList_Model
                    {
                        _company = company,
                        _Vehicles = company.Vehicles.Where(n => n.Type == "car").ToList()
                    };
                    return View(model);
                }
            }
            return View();
        }

        [Authorize]
        public ActionResult LKW()
        {
            var userId = User.Identity.GetUserId();
            if (userId != null)
            {
                using (ApplicationDbContext context = new ApplicationDbContext())
                {
                    ApplicationUser user = context.Users.Find(userId);
                    Company company = context.Companies.FirstOrDefault();
                    var model = new CarList_Model
                    {
                        _company = company,
                        _Vehicles = company.Vehicles.Where(n => n.Type == "lkw").ToList()
                    };
                    return View(model);
                }
            }
            return View();
        }
    }
}