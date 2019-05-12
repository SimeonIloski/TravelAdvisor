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
    public class TransportationsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Transportations
        [AllowAnonymous]
        public ActionResult Index()
        {
            if (!User.IsInRole("Admin")) {
                return View("IndexReadOnly", db.Transportations.ToList());
            }
            return View(db.Transportations.ToList());
        }
        [Authorize(Roles="Admin")]
        // GET: Transportations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transportation transportation = db.Transportations.Find(id);
            if (transportation == null)
            {
                return HttpNotFound();
            }
            return View(transportation);
        }
        public ActionResult City(int? id)
        {
            if (id==null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            List<Transportation> transportationList = db.Transportations.ToList();
                if (transportationList == null)
            {
                return HttpNotFound();
            }
            String startLocation = db.Transportations.Find(id).startLocation;
            List<Transportation> list = new List<Transportation>();
            foreach(Transportation t in transportationList)
            {
                if (t.startLocation.Equals(startLocation))
                {
                    list.Add(t);
                }
            }
            return View(list);
        }

        [Authorize(Roles = "Admin")]
        // GET: Transportations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Transportations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,name,startLocation,endLocation,price")] Transportation transportation)
        {
            if (ModelState.IsValid)
            {
                db.Transportations.Add(transportation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(transportation);
        }
        [Authorize(Roles = "Admin")]
        // GET: Transportations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transportation transportation = db.Transportations.Find(id);
            if (transportation == null)
            {
                return HttpNotFound();
            }
            return View(transportation);
        }
        [Authorize(Roles = "Admin")]
        // POST: Transportations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,name,startLocation,endLocation,price")] Transportation transportation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transportation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(transportation);
        }
        [Authorize(Roles = "Admin")]
        // GET: Transportations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transportation transportation = db.Transportations.Find(id);
            if (transportation == null)
            {
                return HttpNotFound();
            }
            return View(transportation);
        }
        [Authorize(Roles = "Admin")]
        // POST: Transportations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Transportation transportation = db.Transportations.Find(id);
            db.Transportations.Remove(transportation);
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
