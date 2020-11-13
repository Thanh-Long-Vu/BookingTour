﻿using Booking_Tour.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Booking_Tour.Controllers
{
    public class BookingController : Controller
    {
        ConnectDB_BookingTour db = new ConnectDB_BookingTour();
        // GET: Booking
        public ActionResult Booking(int? id)
        {
            if (id == null)
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

        public ActionResult CreateBill()
        {
            return Redirect("");
        }    
    }
}