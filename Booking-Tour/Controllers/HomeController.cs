using Booking_Tour.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Booking_Tour.Controllers
{
    public class HomeController : Controller
    {
        private ConnectDB_BookingTour db = new ConnectDB_BookingTour();
        public ActionResult Index()
        {
            ViewBag.ActiveHome = null;
            if (Request.CurrentExecutionFilePath == "/" || Request.CurrentExecutionFilePath == "/Home/Index")
            {
                ViewBag.ActiveHome = "active";
            }
            var tours = (from t in db.Tours select t).Take(6);
            var recommendedTours = (from ot in db.Tours 
                                    where ot.Provinces.name == "Hà Nội"
                                    select ot).Take(4);
            ViewBag.Tours = tours;
            ViewBag.RecommendedTours = recommendedTours;
            ViewBag.Provinces = (from p in db.Provinces select p).ToList();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.ActiveAbout = null;
            if (Request.CurrentExecutionFilePath == "/Home/About")
            {
                ViewBag.ActiveAbout = "active";
            }
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.ActiveContact = null;
            if (Request.CurrentExecutionFilePath == "/Home/Contact")
            {
                ViewBag.ActiveContact = "active";
            }
            return View();
        }

        public ActionResult Tours()
        {
            ViewBag.ActiveTours = null;
            if (Request.CurrentExecutionFilePath == "/Home/Tours")
            {
                ViewBag.ActiveTours = "active";
            }
            ViewBag.Provinces = (from p in db.Provinces select p).ToList();
            ViewBag.Tours = (from t in db.Tours select t).ToList();
            return View();
        }

        public ActionResult ShowTour(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tours tour = db.Tours.Find(id);
            if(tour == null)
            {
                return HttpNotFound();
            }
            ViewBag.Tour = tour;
            return View();
        }
        /*Start Login */
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
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Email already exists";
                    return Redirect(Request.UrlReferrer.ToString());
                }
            }
            return Redirect(Request.UrlReferrer.ToString());
        }
        /*End Register*/
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
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Login failed";
                    return Redirect(Request.UrlReferrer.ToString());
                }
            }
            return Redirect(Request.UrlReferrer.ToString());
        }

        /*End Login*/
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
