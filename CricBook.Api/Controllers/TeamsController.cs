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
    public class TeamsController : ApiController
    {
        private CricBookEntities1 db = new CricBookEntities1();

        // GET: api/Teams
        public IQueryable<tblTeam> GettblTeams()
        {
            return db.tblTeams;
        }

        // GET: api/Teams/5
        [ResponseType(typeof(tblTeam))]
        public IHttpActionResult GettblTeam(int id)
        {
            tblTeam tblTeam = db.tblTeams.Find(id);
            if (tblTeam == null)
            {
                return NotFound();
            }

            return Ok(tblTeam);
        }

        // PUT: api/Teams/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttblTeam(int id, tblTeam tblTeam)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblTeam.Id)
            {
                return BadRequest();
            }

            db.Entry(tblTeam).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblTeamExists(id))
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

        // POST: api/Teams
        [ResponseType(typeof(tblTeam))]
        public IHttpActionResult PosttblTeam(tblTeam tblTeam)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tblTeams.Add(tblTeam);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tblTeam.Id }, tblTeam);
        }

        // DELETE: api/Teams/5
        [ResponseType(typeof(tblTeam))]
        public IHttpActionResult DeletetblTeam(int id)
        {
            tblTeam tblTeam = db.tblTeams.Find(id);
            if (tblTeam == null)
            {
                return NotFound();
            }

            db.tblTeams.Remove(tblTeam);
            db.SaveChanges();

            return Ok(tblTeam);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblTeamExists(int id)
        {
            return db.tblTeams.Count(e => e.Id == id) > 0;
        }
    }
}