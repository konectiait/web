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
using MundoCanjeWeb.Models;

namespace MundoCanjeWeb.Controllers
{
    public class ChatsController : ApiController
    {
        private MundoCanjeDBEntities db = new MundoCanjeDBEntities();

        // GET: api/Chats
        public IQueryable<Chats> GetChats()
        {
            return db.Chats;
        }

        // GET: api/Chats/5
        [ResponseType(typeof(Chats))]
        public IHttpActionResult GetChats(int id)
        {
            Chats chats = db.Chats.Find(id);
            if (chats == null)
            {
                return NotFound();
            }

            return Ok(chats);
        }

        // PUT: api/Chats/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutChats(int id, Chats chats)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != chats.Id)
            {
                return BadRequest();
            }

            db.Entry(chats).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChatsExists(id))
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

        // POST: api/Chats
        [ResponseType(typeof(Chats))]
        public IHttpActionResult PostChats(Chats chats)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Chats.Add(chats);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ChatsExists(chats.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = chats.Id }, chats);
        }

        // DELETE: api/Chats/5
        [ResponseType(typeof(Chats))]
        public IHttpActionResult DeleteChats(int id)
        {
            Chats chats = db.Chats.Find(id);
            if (chats == null)
            {
                return NotFound();
            }

            db.Chats.Remove(chats);
            db.SaveChanges();

            return Ok(chats);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ChatsExists(int id)
        {
            return db.Chats.Count(e => e.Id == id) > 0;
        }
    }
}