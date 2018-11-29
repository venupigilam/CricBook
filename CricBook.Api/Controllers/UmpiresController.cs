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
    public class UmpiresController : ApiController
    {
        private CricBookEntities1 db = new CricBookEntities1();

        // GET: api/Umpires
        public IQueryable<tblUmpire> GettblUmpires()
        {
            return db.tblUmpires;
        }

        // GET: api/Umpires/5
        [ResponseType(typeof(tblUmpire))]
        public IHttpActionResult GettblUmpire(int id)
        {
            tblUmpire tblUmpire = db.tblUmpires.Find(id);
            if (tblUmpire == null)
            {
                return NotFound();
            }

            return Ok(tblUmpire);
        }

        // PUT: api/Umpires/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttblUmpire(int id, tblUmpire tblUmpire)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblUmpire.Id)
            {
                return BadRequest();
            }

            db.Entry(tblUmpire).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblUmpireExists(id))
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

        // POST: api/Umpires
        [ResponseType(typeof(tblUmpire))]
        public IHttpActionResult PosttblUmpire(tblUmpire tblUmpire)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tblUmpires.Add(tblUmpire);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tblUmpire.Id }, tblUmpire);
        }

        // DELETE: api/Umpires/5
        [ResponseType(typeof(tblUmpire))]
        public IHttpActionResult DeletetblUmpire(int id)
        {
            tblUmpire tblUmpire = db.tblUmpires.Find(id);
            if (tblUmpire == null)
            {
                return NotFound();
            }

            db.tblUmpires.Remove(tblUmpire);
            db.SaveChanges();

            return Ok(tblUmpire);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblUmpireExists(int id)
        {
            return db.tblUmpires.Count(e => e.Id == id) > 0;
        }
    }
}