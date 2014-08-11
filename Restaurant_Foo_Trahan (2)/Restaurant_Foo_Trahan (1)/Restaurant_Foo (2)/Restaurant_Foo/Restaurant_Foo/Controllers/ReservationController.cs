using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Restaurant_Foo.Models;

namespace Restaurant_Foo.Controllers
{
    public class ReservationController : Controller
    {
        private RestaurantFooDB db = new RestaurantFooDB();

        //
        // GET: /Reservation/

        public ActionResult Index()
        {
            if (User.IsInRole("Admin"))
            {
                var model =
                    db.ReservationSlots
                    .OrderBy(r => r.Time);

                return View(model);
            }
            else
            {
                var model =
                    db.ReservationSlots
                    .OrderBy(r => r.Time)
                    .Where(r => r.Name == null);

                return View(model);
            }
        }

        //
        // GET: /Reservation/Details/5

        public ActionResult Details(int id = 0)
        {
            ReservationSlot reservationslot = db.ReservationSlots.Find(id);
            if (reservationslot == null)
            {
                return HttpNotFound();
            }
            return View(reservationslot);
        }

        //
        // GET: /Reservation/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Reservation/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ReservationSlot reservationslot)
        {
            if (ModelState.IsValid)
            {
                db.ReservationSlots.Add(reservationslot);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(reservationslot);
        }

        //
        // GET: /Reservation/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ReservationSlot reservationslot = db.ReservationSlots.Find(id);
            if (reservationslot == null)
            {
                return HttpNotFound();
            }
            return View(reservationslot);
        }

        //
        // POST: /Reservation/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ReservationSlot reservationslot)
        {
            if (ModelState.IsValid)
            { 
                db.Entry(reservationslot).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(reservationslot);
        }

        //
        // GET: /Reservation/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ReservationSlot reservationslot = db.ReservationSlots.Find(id);
            if (reservationslot == null)
            {
                return HttpNotFound();
            }
            return View(reservationslot);
        }

        //
        // POST: /Reservation/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ReservationSlot reservationslot = db.ReservationSlots.Find(id);
            db.ReservationSlots.Remove(reservationslot);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}