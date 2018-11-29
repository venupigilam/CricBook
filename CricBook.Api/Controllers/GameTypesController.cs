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
    public class GameTypesController : ApiController
    {
        private CricBookEntities1 db = new CricBookEntities1();

        // GET: api/GameTypes
        public IQueryable<tblGameType> GettblGameTypes()
        {
            return db.tblGameTypes;
        }

        // GET: api/GameTypes/5
        [ResponseType(typeof(tblGameType))]
        public IHttpActionResult GettblGameType(int id)
        {
            tblGameType tblGameType = db.tblGameTypes.Find(id);
            if (tblGameType == null)
            {
                return NotFound();
            }

            return Ok(tblGameType);
        }

        // PUT: api/GameTypes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttblGameType(int id, tblGameType tblGameType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblGameType.Id)
            {
                return BadRequest();
            }

            db.Entry(tblGameType).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblGameTypeExists(id))
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

        // POST: api/GameTypes
        [ResponseType(typeof(tblGameType))]
        public IHttpActionResult PosttblGameType(tblGameType tblGameType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tblGameTypes.Add(tblGameType);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tblGameType.Id }, tblGameType);
        }

        // DELETE: api/GameTypes/5
        [ResponseType(typeof(tblGameType))]
        public IHttpActionResult DeletetblGameType(int id)
        {
            tblGameType tblGameType = db.tblGameTypes.Find(id);
            if (tblGameType == null)
            {
                return NotFound();
            }

            db.tblGameTypes.Remove(tblGameType);
            db.SaveChanges();

            return Ok(tblGameType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblGameTypeExists(int id)
        {
            return db.tblGameTypes.Count(e => e.Id == id) > 0;
        }
    }
}