using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TripAdvisor.Models;

namespace TripAdvisor.Controllers
{
    public class AppartmentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        [AllowAnonymous]
        // GET: Appartments
        public ActionResult Index()
        {
            if (!User.IsInRole("Admin")) {
                return View("IndexReadOnly", db.Appartments.ToList());
            }
            return View(db.Appartments.ToList());
        }
        [Authorize]
        // GET: Appartments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appartment appartment = db.Appartments.Find(id);
            if (appartment == null)
            {
                return HttpNotFound();
            }
            return View(appartment);
        }
        [Authorize]
        // GET: Appartments/Create
        public ActionResult Create()
        {
            return View();
        }
        [Authorize]
        // POST: Appartments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,name,locationName,singleBedPrice,doubleBedPrice,rating,imagepath")] Appartment appartment)
        {
            if (ModelState.IsValid)
            {
                db.Appartments.Add(appartment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(appartment);
        }
        [Authorize]
        // GET: Appartments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appartment appartment = db.Appartments.Find(id);
            if (appartment == null)
            {
                return HttpNotFound();
            }
            return View(appartment);
        }
        [Authorize]
        // POST: Appartments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,name,locationName,singleBedPrice,doubleBedPrice,rating,imagepath")] Appartment appartment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(appartment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(appartment);
        }
        [Authorize]
        // GET: Appartments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appartment appartment = db.Appartments.Find(id);
            if (appartment == null)
            {
                return HttpNotFound();
            }
            return View(appartment);
        }
        [Authorize]
        // POST: Appartments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Appartment appartment = db.Appartments.Find(id);
            db.Appartments.Remove(appartment);
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
