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
using CricBook.Domain;

namespace CricBook.Api.Controllers
{
    public class ExtrasController : ApiController
    {
        private CricBookEntities1 db = new CricBookEntities1();

        // GET: api/Extras
        public IQueryable<tblExtra> GettblExtras()
        {
            return db.tblExtras;
        }

        // GET: api/Extras/5
        [ResponseType(typeof(tblExtra))]
        public IHttpActionResult GettblExtra(int id)
        {
            tblExtra tblExtra = db.tblExtras.Find(id);
            if (tblExtra == null)
            {
                return NotFound();
            }

            return Ok(tblExtra);
        }

        // PUT: api/Extras/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttblExtra(int id, tblExtra tblExtra)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblExtra.Id)
            {
                return BadRequest();
            }

            db.Entry(tblExtra).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblExtraExists(id))
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

        // POST: api/Extras
        [ResponseType(typeof(tblExtra))]
        public IHttpActionResult PosttblExtra(tblExtra tblExtra)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tblExtras.Add(tblExtra);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tblExtra.Id }, tblExtra);
        }

        // DELETE: api/Extras/5
        [ResponseType(typeof(tblExtra))]
        public IHttpActionResult DeletetblExtra(int id)
        {
            tblExtra tblExtra = db.tblExtras.Find(id);
            if (tblExtra == null)
            {
                return NotFound();
            }

            db.tblExtras.Remove(tblExtra);
            db.SaveChanges();

            return Ok(tblExtra);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblExtraExists(int id)
        {
            return db.tblExtras.Count(e => e.Id == id) > 0;
        }
    }
}