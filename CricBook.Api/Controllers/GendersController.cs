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
    public class GendersController : ApiController
    {
        private CricBookEntities1 db = new CricBookEntities1();

        // GET: api/Genders
        public IQueryable<tblGender> GettblGenders()
        {
            return db.tblGenders;
        }

        // GET: api/Genders/5
        [ResponseType(typeof(tblGender))]
        public IHttpActionResult GettblGender(int id)
        {
            tblGender tblGender = db.tblGenders.Find(id);
            if (tblGender == null)
            {
                return NotFound();
            }

            return Ok(tblGender);
        }

        // PUT: api/Genders/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttblGender(int id, tblGender tblGender)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblGender.Id)
            {
                return BadRequest();
            }

            db.Entry(tblGender).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblGenderExists(id))
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

        // POST: api/Genders
        [ResponseType(typeof(tblGender))]
        public IHttpActionResult PosttblGender(tblGender tblGender)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tblGenders.Add(tblGender);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tblGender.Id }, tblGender);
        }

        // DELETE: api/Genders/5
        [ResponseType(typeof(tblGender))]
        public IHttpActionResult DeletetblGender(int id)
        {
            tblGender tblGender = db.tblGenders.Find(id);
            if (tblGender == null)
            {
                return NotFound();
            }

            db.tblGenders.Remove(tblGender);
            db.SaveChanges();

            return Ok(tblGender);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblGenderExists(int id)
        {
            return db.tblGenders.Count(e => e.Id == id) > 0;
        }
    }
}