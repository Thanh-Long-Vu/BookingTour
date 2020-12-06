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

        /*Start Login*/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string email, string password)
        {
            if (ModelState.IsValid)
            {
                var f_password = GetMD5(password);
                var data = db.Users.Where(s => s.email.Equals(email) && s.password.Equals(f_password)).ToList();
                if (data.Count() > 0)
                {
                    //add session
                    Session["Name"] = data.FirstOrDefault().name;
                    Session["idUser"] = data.FirstOrDefault().id;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.error = "Wrong email or password, please try again !";
                    return View();
                }
            }
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        //POST: Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Users _user)
        {
            if (ModelState.IsValid)
            {
                var check = db.Users.FirstOrDefault(s => s.email == _user.email);
                if (check == null)
                {
                    _user.password = GetMD5(_user.password);
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.Users.Add(_user);
                    db.SaveChanges();
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    ViewBag.Error = "Email has been taken";
                    return View();
                }
            }
            return RedirectToAction("Register", "Account");
        }
        /*End Register*/

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

        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;
            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");
            }
            return byte2String;
        }
    }
}