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
    public class CompaniesController : ApiController
    {
        private CricBookEntities1 db = new CricBookEntities1();

        // GET: api/Companies
        public IQueryable<tblCompany> GettblCompanies()
        {
            return db.tblCompanies;
        }

        // GET: api/Companies/5
        [ResponseType(typeof(tblCompany))]
        public IHttpActionResult GettblCompany(int id)
        {
            tblCompany tblCompany = db.tblCompanies.Find(id);
            if (tblCompany == null)
            {
                return NotFound();
            }

            return Ok(tblCompany);
        }

        // PUT: api/Companies/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttblCompany(int id, tblCompany tblCompany)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblCompany.Id)
            {
                return BadRequest();
            }

            db.Entry(tblCompany).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblCompanyExists(id))
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

        // POST: api/Companies
        [ResponseType(typeof(tblCompany))]
        public IHttpActionResult PosttblCompany(tblCompany tblCompany)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tblCompanies.Add(tblCompany);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tblCompany.Id }, tblCompany);
        }

        // DELETE: api/Companies/5
        [ResponseType(typeof(tblCompany))]
        public IHttpActionResult DeletetblCompany(int id)
        {
            tblCompany tblCompany = db.tblCompanies.Find(id);
            if (tblCompany == null)
            {
                return NotFound();
            }

            db.tblCompanies.Remove(tblCompany);
            db.SaveChanges();

            return Ok(tblCompany);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblCompanyExists(int id)
        {
            return db.tblCompanies.Count(e => e.Id == id) > 0;
        }
    }
}