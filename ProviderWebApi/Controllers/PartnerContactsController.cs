using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ProviderWebApi.Models;

namespace ProviderWebApi.Controllers
{
    public class PartnerContactsController : ApiController
    {
        private PartnerContactContext db = new PartnerContactContext();

        // GET: api/PartnerContacts
        public IQueryable<PartnerContact> GetPartnerContacts()
        {
            return db.PartnerContacts;
        }

        // GET: api/PartnerContacts/5
        [ResponseType(typeof(PartnerContact))]
        public IHttpActionResult GetPartnerContact(int id)
        {
            PartnerContact partnerContact = db.PartnerContacts.Find(id);
            if (partnerContact == null)
            {
                return NotFound();
            }

            return Ok(partnerContact);
        }

        // PUT: api/PartnerContacts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPartnerContact(int id, PartnerContact partnerContact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != partnerContact.Id)
            {
                return BadRequest();
            }

            db.Entry(partnerContact).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PartnerContactExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/PartnerContacts
        [ResponseType(typeof(PartnerContact))]
        public IHttpActionResult PostPartnerContact(PartnerContact partnerContact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PartnerContacts.Add(partnerContact);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = partnerContact.Id }, partnerContact);
        }

        // DELETE: api/PartnerContacts/5
        [ResponseType(typeof(PartnerContact))]
        public IHttpActionResult DeletePartnerContact(int id)
        {
            PartnerContact partnerContact = db.PartnerContacts.Find(id);
            if (partnerContact == null)
            {
                return NotFound();
            }

            db.PartnerContacts.Remove(partnerContact);
            db.SaveChanges();

            return Ok(partnerContact);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PartnerContactExists(int id)
        {
            return db.PartnerContacts.Count(e => e.Id == id) > 0;
        }
    }
}