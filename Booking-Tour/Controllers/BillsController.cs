using Booking_Tour.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace Booking_Tour.Controllers
{
    public class BillsController : Controller
    {
        public ConnectDB_BookingTour db = new ConnectDB_BookingTour();
        // GET: Bills
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult OrderMagement(int? page)
        {
            if (Session["idUser"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            var bill = db.Bills.ToList();
            ViewBag.Bill = bill;
            var pageSize = 1;
            int pageNumber = page ?? 1;
            return View(bill.ToPagedList(pageNumber, pageSize));
        }
    }
}