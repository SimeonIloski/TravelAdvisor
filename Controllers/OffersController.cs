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
    public class OffersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        [AllowAnonymous]
        // GET: Offers
        public ActionResult Index()
        {
            List<Offers> offersList = db.Offers.ToList();
            List<Transportation> transportations = db.Transportations.ToList();
            List<OffersTrans> offersTransList = new List<OffersTrans>();
            foreach (Offers o in offersList)
            {
                
                
                foreach (Transportation trans in transportations)
                {
                    if (trans.Id == o.transportationId)
                    {
                        OffersTrans of = new OffersTrans();
                        of.offers = o;
                        of.transportation = trans;
                        offersTransList.Add(of);
                    }
                }
            }
            if (!User.IsInRole("Admin"))
            {
                if (User.IsInRole("Premium")) {
                    return View("IndexReadOnlySpecial", offersTransList);
                }
                return View("IndexReadOnly", offersTransList);
            }
            return View(offersTransList);
        }
        [Authorize]
        // GET: Offers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Offers offers = db.Offers.Find(id);
            if (offers == null)
            {
                return HttpNotFound();
            }
            return View(offers);
        }
        [Authorize]
        // GET: Offers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Offers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,locationName,transportationId,appartmentName,totalPrice,specialPrice")] Offers offers)
        {
            if (ModelState.IsValid)
            {
                db.Offers.Add(offers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(offers);
        }
        [Authorize]
        // GET: Offers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Offers offers = db.Offers.Find(id);
            if (offers == null)
            {
                return HttpNotFound();
            }
            return View(offers);
        }
        [Authorize]
        // POST: Offers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,locationName,transportationId,appartmentName,totalPrice,specialPrice")] Offers offers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(offers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(offers);
        }
        [Authorize]
        // GET: Offers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Offers offers = db.Offers.Find(id);
            if (offers == null)
            {
                return HttpNotFound();
            }
            return View(offers);
        }
        [Authorize]
        // POST: Offers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Offers offers = db.Offers.Find(id);
            db.Offers.Remove(offers);
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
