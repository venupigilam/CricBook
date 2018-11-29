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
    public class CountriesController : ApiController
    {
        private CricBookEntities1 db = new CricBookEntities1();

        // GET: api/Countries
        public IQueryable<tblCountry> GettblCountries()
        {
            return db.tblCountries;
        }

        // GET: api/Countries/5
        [ResponseType(typeof(tblCountry))]
        public IHttpActionResult GettblCountry(int id)
        {
            tblCountry tblCountry = db.tblCountries.Find(id);
            if (tblCountry == null)
            {
                return NotFound();
            }

            return Ok(tblCountry);
        }

        // PUT: api/Countries/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttblCountry(int id, tblCountry tblCountry)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblCountry.Id)
            {
                return BadRequest();
            }

            db.Entry(tblCountry).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblCountryExists(id))
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

        // POST: api/Countries
        [ResponseType(typeof(tblCountry))]
        public IHttpActionResult PosttblCountry(tblCountry tblCountry)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tblCountries.Add(tblCountry);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tblCountry.Id }, tblCountry);
        }

        // DELETE: api/Countries/5
        [ResponseType(typeof(tblCountry))]
        public IHttpActionResult DeletetblCountry(int id)
        {
            tblCountry tblCountry = db.tblCountries.Find(id);
            if (tblCountry == null)
            {
                return NotFound();
            }

            db.tblCountries.Remove(tblCountry);
            db.SaveChanges();

            return Ok(tblCountry);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblCountryExists(int id)
        {
            return db.tblCountries.Count(e => e.Id == id) > 0;
        }
    }
}