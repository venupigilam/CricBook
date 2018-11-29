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
    public class StatesController : ApiController
    {
        private CricBookEntities1 db = new CricBookEntities1();

        // GET: api/States
        public IQueryable<tblState> GettblStates()
        {
            return db.tblStates;
        }

        // GET: api/States/5
        [ResponseType(typeof(tblState))]
        public IHttpActionResult GettblState(int id)
        {
            tblState tblState = db.tblStates.Find(id);
            if (tblState == null)
            {
                return NotFound();
            }

            return Ok(tblState);
        }

        // PUT: api/States/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttblState(int id, tblState tblState)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblState.Id)
            {
                return BadRequest();
            }

            db.Entry(tblState).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblStateExists(id))
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

        // POST: api/States
        [ResponseType(typeof(tblState))]
        public IHttpActionResult PosttblState(tblState tblState)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tblStates.Add(tblState);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tblState.Id }, tblState);
        }

        // DELETE: api/States/5
        [ResponseType(typeof(tblState))]
        public IHttpActionResult DeletetblState(int id)
        {
            tblState tblState = db.tblStates.Find(id);
            if (tblState == null)
            {
                return NotFound();
            }

            db.tblStates.Remove(tblState);
            db.SaveChanges();

            return Ok(tblState);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblStateExists(int id)
        {
            return db.tblStates.Count(e => e.Id == id) > 0;
        }
    }
}