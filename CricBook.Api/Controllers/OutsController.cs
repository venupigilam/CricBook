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
    public class OutsController : ApiController
    {
        private CricBookEntities1 db = new CricBookEntities1();

        // GET: api/Outs
        public IQueryable<tblOut> GettblOuts()
        {
            return db.tblOuts;
        }

        // GET: api/Outs/5
        [ResponseType(typeof(tblOut))]
        public IHttpActionResult GettblOut(int id)
        {
            tblOut tblOut = db.tblOuts.Find(id);
            if (tblOut == null)
            {
                return NotFound();
            }

            return Ok(tblOut);
        }

        // PUT: api/Outs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttblOut(int id, tblOut tblOut)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblOut.Id)
            {
                return BadRequest();
            }

            db.Entry(tblOut).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblOutExists(id))
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

        // POST: api/Outs
        [ResponseType(typeof(tblOut))]
        public IHttpActionResult PosttblOut(tblOut tblOut)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tblOuts.Add(tblOut);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tblOut.Id }, tblOut);
        }

        // DELETE: api/Outs/5
        [ResponseType(typeof(tblOut))]
        public IHttpActionResult DeletetblOut(int id)
        {
            tblOut tblOut = db.tblOuts.Find(id);
            if (tblOut == null)
            {
                return NotFound();
            }

            db.tblOuts.Remove(tblOut);
            db.SaveChanges();

            return Ok(tblOut);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblOutExists(int id)
        {
            return db.tblOuts.Count(e => e.Id == id) > 0;
        }
    }
}