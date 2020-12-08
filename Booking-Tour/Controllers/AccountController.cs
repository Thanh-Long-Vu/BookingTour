using Booking_Tour.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
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
        //Get Edit Account
        public ActionResult EditAccount(int ? id)
        {
            if(Session["idUser"] == null)
            {
                return RedirectToAction("Login", "Account");
            }    
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Users users = db.Users.Find(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditAccount([Bind(Include = "id,name,email,password,avatar,role")] Users users)
        {
            //if (inputImg != null)
            //{
            //    string extensionName = System.IO.Path.GetExtension(inputImg.FileName);
            //    string path = "Avatar/" + users.id + extensionName;
            //    string urlImg = System.IO.Path.Combine(Server.MapPath("~/Content/image/User/Avatar/"), users.id + extensionName);
            //    inputImg.SaveAs(urlImg);
            //    users.avatar = path;
            //}
            users.id = int.Parse(Session["idUser"].ToString());
            if (ModelState.IsValid)
            {
                db.Entry(users).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("SettingsAccount");
            }
            return View(users);
        }
        public ActionResult UpdatePasswordUser()
        {
            return View();
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