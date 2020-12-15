using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Booking_Tour.Models;

namespace Booking_Tour.Areas.Admin.Controllers
{
    public class DescriptionToursController : Controller
    {
        private ConnectDB_BookingTour db = new ConnectDB_BookingTour();

        // GET: Admin/DescriptionTours
        public ActionResult Index()
        {
            var descriptionTours = db.DescriptionTours.Include(d => d.Tours);
            return View(descriptionTours.ToList());
        }

        // GET: Admin/DescriptionTours/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DescriptionTour descriptionTour = db.DescriptionTours.Find(id);
            if (descriptionTour == null)
            {
                return HttpNotFound();
            }
            return View(descriptionTour);
        }

        // GET: Admin/DescriptionTours/Create
        public ActionResult Create()
        {
            ViewBag.tour_id = new SelectList(db.Tours, "id", "name");
            return View();
        }

        // POST: Admin/DescriptionTours/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,avatar,day_tour,description,tour_id")] DescriptionTour descriptionTour)
        {
            if (ModelState.IsValid)
            {
                db.DescriptionTours.Add(descriptionTour);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.tour_id = new SelectList(db.Tours, "id", "name", descriptionTour.tour_id);
            return View(descriptionTour);
        }

        // GET: Admin/DescriptionTours/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DescriptionTour descriptionTour = db.DescriptionTours.Find(id);
            if (descriptionTour == null)
            {
                return HttpNotFound();
            }
            ViewBag.tour_id = new SelectList(db.Tours, "id", "name", descriptionTour.tour_id);
            return View(descriptionTour);
        }

        // POST: Admin/DescriptionTours/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,avatar,day_tour,description,tour_id")] DescriptionTour descriptionTour, HttpPostedFileBase inputAvatar)
        {

            if (inputAvatar != null)
            {
                string extensionName = System.IO.Path.GetExtension(inputAvatar.FileName);
                string fileName = DateTime.Now.Ticks.ToString();
                string path = "DescreptionTour/" + descriptionTour.id + extensionName;
                string urlImg = System.IO.Path.Combine(Server.MapPath("~/Content/images/DescreptionTour/"), descriptionTour.id + extensionName);
                inputAvatar.SaveAs(urlImg);
                descriptionTour.avatar = path;
            }
            if (ModelState.IsValid)
            {
                db.DescriptionTours.Add(descriptionTour);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.tour_id = new SelectList(db.Tours, "id", "name", descriptionTour.tour_id);
            return View(descriptionTour);
        }

        // GET: Admin/DescriptionTours/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DescriptionTour descriptionTour = db.DescriptionTours.Find(id);
            if (descriptionTour == null)
            {
                return HttpNotFound();
            }
            return View(descriptionTour);
        }

        // POST: Admin/DescriptionTours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DescriptionTour descriptionTour = db.DescriptionTours.Find(id);
            db.DescriptionTours.Remove(descriptionTour);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
