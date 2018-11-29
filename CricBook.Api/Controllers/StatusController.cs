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
    public class StatusController : ApiController
    {
        private CricBookEntities1 db = new CricBookEntities1();

        // GET: api/Status
        public IQueryable<tblStatu> GettblStatus()
        {
            return db.tblStatus;
        }

        // GET: api/Status/5
        [ResponseType(typeof(tblStatu))]
        public IHttpActionResult GettblStatu(int id)
        {
            tblStatu tblStatu = db.tblStatus.Find(id);
            if (tblStatu == null)
            {
                return NotFound();
            }

            return Ok(tblStatu);
        }

        // PUT: api/Status/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttblStatu(int id, tblStatu tblStatu)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblStatu.Id)
            {
                return BadRequest();
            }

            db.Entry(tblStatu).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblStatuExists(id))
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

        // POST: api/Status
        [ResponseType(typeof(tblStatu))]
        public IHttpActionResult PosttblStatu(tblStatu tblStatu)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tblStatus.Add(tblStatu);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tblStatu.Id }, tblStatu);
        }

        // DELETE: api/Status/5
        [ResponseType(typeof(tblStatu))]
        public IHttpActionResult DeletetblStatu(int id)
        {
            tblStatu tblStatu = db.tblStatus.Find(id);
            if (tblStatu == null)
            {
                return NotFound();
            }

            db.tblStatus.Remove(tblStatu);
            db.SaveChanges();

            return Ok(tblStatu);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblStatuExists(int id)
        {
            return db.tblStatus.Count(e => e.Id == id) > 0;
        }
    }
}