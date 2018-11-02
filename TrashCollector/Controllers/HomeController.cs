using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrashCollector.Models;

namespace TrashCollector.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            var userName = User.Identity.Name;
            var userId = User.Identity.GetUserId();
            var user = db.Users.Where(u => u.Id == userId).SingleOrDefault();
           //bool test = User.IsInRole("Customer");
           if(user != null)
            {
                if (user.UserRole == "Customer")
                {
                    return RedirectToAction("Index", "Customers");
                }

                if (user.UserRole == "Employee")
                {
                    return RedirectToAction("Index", "Employees");
                }
            }
            
            //add employee section here

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}