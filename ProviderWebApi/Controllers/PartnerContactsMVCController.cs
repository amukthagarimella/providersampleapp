using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProviderWebApi.Models;

namespace ProviderWebApi.Controllers
{
    public class PartnerContactsMVCController : Controller
    {
        private PartnerContactContext db = new PartnerContactContext();

        // GET: PartnerContactsMVC
        public ActionResult Index()
        {
            return View(db.PartnerContacts.ToList());
        }

        // GET: PartnerContactsMVC/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PartnerContact partnerContact = db.PartnerContacts.Find(id);
            if (partnerContact == null)
            {
                return HttpNotFound();
            }
            return View(partnerContact);
        }

        // GET: PartnerContactsMVC/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PartnerContactsMVC/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,ProviderName,ContactNo,ContactEmail")] PartnerContact partnerContact)
        {
            if (ModelState.IsValid)
            {
                db.PartnerContacts.Add(partnerContact);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(partnerContact);
        }

        // GET: PartnerContactsMVC/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PartnerContact partnerContact = db.PartnerContacts.Find(id);
            if (partnerContact == null)
            {
                return HttpNotFound();
            }
            return View(partnerContact);
        }

        // POST: PartnerContactsMVC/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,ProviderName,ContactNo,ContactEmail")] PartnerContact partnerContact)
        {
            if (ModelState.IsValid)
            {
                db.Entry(partnerContact).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(partnerContact);
        }

        // GET: PartnerContactsMVC/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PartnerContact partnerContact = db.PartnerContacts.Find(id);
            if (partnerContact == null)
            {
                return HttpNotFound();
            }
            return View(partnerContact);
        }

        // POST: PartnerContactsMVC/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PartnerContact partnerContact = db.PartnerContacts.Find(id);
            db.PartnerContacts.Remove(partnerContact);
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
