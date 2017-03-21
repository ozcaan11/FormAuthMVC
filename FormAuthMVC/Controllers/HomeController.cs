using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FormAuthMVC.Models;

namespace AuthDemo.Controllers
{
    public class HomeController : Controller
    {
        mydb db = new mydb();

        public ActionResult Index()
        {
            return View(db.Students.ToList());
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Admin()
        {
            return View();
        }

        [Authorize(Roles = "Vip")]
        public ActionResult Vip()
        {
            return View();
        }

        [Authorize(Roles = "Admin,Vip")]
        public ActionResult AdminVip()
        {
            return View();
        }
    }
}