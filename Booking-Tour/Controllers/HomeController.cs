using Booking_Tour.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Tours()
        {
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
    }
}