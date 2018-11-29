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
    public class PlayersController : ApiController
    {
        private CricBookEntities1 db = new CricBookEntities1();

        // GET: api/Players
        public IQueryable<tblPlayer> GettblPlayers()
        {
            return db.tblPlayers;
        }

        // GET: api/Players/5
        [ResponseType(typeof(tblPlayer))]
        public IHttpActionResult GettblPlayer(int id)
        {
            tblPlayer tblPlayer = db.tblPlayers.Find(id);
            if (tblPlayer == null)
            {
                return NotFound();
            }

            return Ok(tblPlayer);
        }

        // PUT: api/Players/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttblPlayer(int id, tblPlayer tblPlayer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblPlayer.Id)
            {
                return BadRequest();
            }

            db.Entry(tblPlayer).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblPlayerExists(id))
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

        // POST: api/Players
        [ResponseType(typeof(tblPlayer))]
        public IHttpActionResult PosttblPlayer(tblPlayer tblPlayer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tblPlayers.Add(tblPlayer);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tblPlayer.Id }, tblPlayer);
        }

        // DELETE: api/Players/5
        [ResponseType(typeof(tblPlayer))]
        public IHttpActionResult DeletetblPlayer(int id)
        {
            tblPlayer tblPlayer = db.tblPlayers.Find(id);
            if (tblPlayer == null)
            {
                return NotFound();
            }

            db.tblPlayers.Remove(tblPlayer);
            db.SaveChanges();

            return Ok(tblPlayer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblPlayerExists(int id)
        {
            return db.tblPlayers.Count(e => e.Id == id) > 0;
        }
    }
}