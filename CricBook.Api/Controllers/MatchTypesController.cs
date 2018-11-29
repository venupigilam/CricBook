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
    public class MatchTypesController : ApiController
    {
        private CricBookEntities1 db = new CricBookEntities1();

        // GET: api/MatchTypes
        public IQueryable<tblMatchType> GettblMatchTypes()
        {
            return db.tblMatchTypes;
        }

        // GET: api/MatchTypes/5
        [ResponseType(typeof(tblMatchType))]
        public IHttpActionResult GettblMatchType(int id)
        {
            tblMatchType tblMatchType = db.tblMatchTypes.Find(id);
            if (tblMatchType == null)
            {
                return NotFound();
            }

            return Ok(tblMatchType);
        }

        // PUT: api/MatchTypes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttblMatchType(int id, tblMatchType tblMatchType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblMatchType.Id)
            {
                return BadRequest();
            }

            db.Entry(tblMatchType).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblMatchTypeExists(id))
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

        // POST: api/MatchTypes
        [ResponseType(typeof(tblMatchType))]
        public IHttpActionResult PosttblMatchType(tblMatchType tblMatchType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tblMatchTypes.Add(tblMatchType);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tblMatchType.Id }, tblMatchType);
        }

        // DELETE: api/MatchTypes/5
        [ResponseType(typeof(tblMatchType))]
        public IHttpActionResult DeletetblMatchType(int id)
        {
            tblMatchType tblMatchType = db.tblMatchTypes.Find(id);
            if (tblMatchType == null)
            {
                return NotFound();
            }

            db.tblMatchTypes.Remove(tblMatchType);
            db.SaveChanges();

            return Ok(tblMatchType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblMatchTypeExists(int id)
        {
            return db.tblMatchTypes.Count(e => e.Id == id) > 0;
        }
    }
}