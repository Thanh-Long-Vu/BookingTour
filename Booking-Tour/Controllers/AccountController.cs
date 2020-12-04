using Booking_Tour.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Booking_Tour.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        ConnectDB_BookingTour db = new ConnectDB_BookingTour();
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult Logout()
        {
            Session.Abandon();//remove session
            return RedirectToAction("Login");
        }
        public ActionResult SettingsAccount()
        {
            if(Session["idUser"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            var User = db.Users.Find(Session["idUser"]);
            ViewBag.User = User;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditAccount()
        {
            /*var name = Request["name"];
            int userID = int.Parse(Session["idUser"].ToString());
            var user = db.Users.Where(u => u.id.Equals(userID)).FirstOrDefault();

            Users update = (from u in db.Users where u.id == userID).SingleOrDefault();
            update.name = name;
            db.SaveChanges();*/
            return Content("Cap nhat thanh cong");
        }
    }
}