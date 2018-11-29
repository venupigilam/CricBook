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
    public class MatchesController : ApiController
    {
        private CricBookEntities1 db = new CricBookEntities1();

        // GET: api/Matches
        public IQueryable<tblMatch> GettblMatches()
        {
            return db.tblMatches;
        }

        // GET: api/Matches/5
        [ResponseType(typeof(tblMatch))]
        public IHttpActionResult GettblMatch(int id)
        {
            tblMatch tblMatch = db.tblMatches.Find(id);
            if (tblMatch == null)
            {
                return NotFound();
            }

            return Ok(tblMatch);
        }

        // PUT: api/Matches/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttblMatch(int id, tblMatch tblMatch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblMatch.Id)
            {
                return BadRequest();
            }

            db.Entry(tblMatch).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblMatchExists(id))
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

        // POST: api/Matches
        [ResponseType(typeof(tblMatch))]
        public IHttpActionResult PosttblMatch(tblMatch tblMatch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tblMatches.Add(tblMatch);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tblMatch.Id }, tblMatch);
        }

        // DELETE: api/Matches/5
        [ResponseType(typeof(tblMatch))]
        public IHttpActionResult DeletetblMatch(int id)
        {
            tblMatch tblMatch = db.tblMatches.Find(id);
            if (tblMatch == null)
            {
                return NotFound();
            }

            db.tblMatches.Remove(tblMatch);
            db.SaveChanges();

            return Ok(tblMatch);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblMatchExists(int id)
        {
            return db.tblMatches.Count(e => e.Id == id) > 0;
        }
    }
}