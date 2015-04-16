using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FiveTalent.Models;
using FiveTalent.DAL;
using System.Threading.Tasks;
using System.IO;
using System.Net;

namespace FiveTalent.Controllers
{
    public class ListingController : Controller
    {
        private ListingContext db = new ListingContext();

        //
        // GET: /Listing/

        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View(db.Listings.ToList());
            }

            ViewBag.ReturnUrl = "~/Views/Listing/Index.cshtml";
            return View("_LoginPartial");
        }

        //
        // GET: /Listing/Details/5

        public ActionResult Details(int id = 0)
        {
            Listing listing = db.Listings.Find(id);
            if (listing == null)
            {
                return HttpNotFound();
            }
            return View(listing);
        }

        //
        // GET: /Listing/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Listing/Create

        [HttpPost]
        public ActionResult Create(Listing listing)
        {
            if (ModelState.IsValid)
            {
                db.Listings.Add(listing);
                db.SaveChanges();

                ViewBag.ListingID = listing.ListingId;
                return View("~/Views/Image/Upload.cshtml");
            }

            return View(listing);
        }

        //
        // GET: /Listing/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Listing listing = db.Listings.Find(id);
            if (listing == null)
            {
                return HttpNotFound();
            }
            return View(listing);
        }

        //
        // POST: /Listing/Edit/5

        [HttpPost]
        public ActionResult Edit(Listing listing)
        {
            if (ModelState.IsValid)
            {
                db.Entry(listing).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(listing);
        }

        //
        // GET: /Listing/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Listing listing = db.Listings.Find(id);
            if (listing == null)
            {
                return HttpNotFound();
            }
            return View(listing);
        }

        //
        // POST: /Listing/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Listing listing = db.Listings.Find(id);
            db.Listings.Remove(listing);
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