using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CricBook.Domain;

namespace CrickBook.UI.Controllers
{
    public class CountriesController : Controller
    {
        private CricBookEntities1 db = new CricBookEntities1();

        // GET: Countries
        public ActionResult Index()
        {
            return View(db.tblCountries.ToList());
        }

        // GET: Countries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblCountry tblCountry = db.tblCountries.Find(id);
            if (tblCountry == null)
            {
                return HttpNotFound();
            }
            return View(tblCountry);
        }

        // GET: Countries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Countries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] tblCountry tblCountry)
        {
            if (ModelState.IsValid)
            {
                db.tblCountries.Add(tblCountry);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblCountry);
        }

        // GET: Countries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblCountry tblCountry = db.tblCountries.Find(id);
            if (tblCountry == null)
            {
                return HttpNotFound();
            }
            return View(tblCountry);
        }

        // POST: Countries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] tblCountry tblCountry)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblCountry).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblCountry);
        }

        // GET: Countries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblCountry tblCountry = db.tblCountries.Find(id);
            if (tblCountry == null)
            {
                return HttpNotFound();
            }
            return View(tblCountry);
        }

        // POST: Countries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblCountry tblCountry = db.tblCountries.Find(id);
            db.tblCountries.Remove(tblCountry);
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
