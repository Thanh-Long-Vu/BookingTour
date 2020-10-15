using Booking_Tour.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Booking_Tour.Controllers
{
    public class HomeController : Controller
    {
        private ConnectDB_BookingTour db = new ConnectDB_BookingTour();
        public ActionResult Index()
        {
            var tours = (from t in db.Tours select t).Take(6);
            ViewBag.Tours = tours;
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Tours()
        {
            return View();
        }

        public ActionResult ShowTour()
        {
            return View();
        }
    }
}