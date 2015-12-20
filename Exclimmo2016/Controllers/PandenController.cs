using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Exclimmo2016.Models;

namespace Exclimmo2016.Controllers
{
    [Authorize]
    public class PandenController : Controller
    {
        private ExclimmoContext db = new ExclimmoContext();

        // GET: Panden
        public ActionResult Index()
        {
            return View(db.Panden.ToList());
        }

        // GET: Panden/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pand pand = db.Panden.Find(id);
            if (pand == null)
            {
                return HttpNotFound();
            }
            return View(pand);
        }

        // GET: Panden/Create
        [Authorize (Roles = "adminstrator")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Panden/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Soort,TransactieType,Beschrijving,Locatie,ImageUrl")] Pand pand)
        {
            if (ModelState.IsValid)
            {
                db.Panden.Add(pand);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pand);
        }

        // GET: Panden/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pand pand = db.Panden.Find(id);
            if (pand == null)
            {
                return HttpNotFound();
            }
            return View(pand);
        }

        // POST: Panden/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Soort,TransactieType,Beschrijving,Locatie,ImageUrl")] Pand pand)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pand).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pand);
        }

        // GET: Panden/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pand pand = db.Panden.Find(id);
            if (pand == null)
            {
                return HttpNotFound();
            }
            return View(pand);
        }

        // POST: Panden/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pand pand = db.Panden.Find(id);
            db.Panden.Remove(pand);
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
