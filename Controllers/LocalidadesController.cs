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
    public class LocalidadesController : ApiController
    {
        private MundoCanjeDBEntities db = new MundoCanjeDBEntities();

        // GET: api/Localidades
        public IQueryable<Localidades> GetLocalidades()
        {
            return db.Localidades;
        }

        // GET: api/Localidades/5
        [ResponseType(typeof(Localidades))]
        public IHttpActionResult GetLocalidades(int id)
        {
            Localidades localidades = db.Localidades.Find(id);
            if (localidades == null)
            {
                return NotFound();
            }

            return Ok(localidades);
        }

        // PUT: api/Localidades/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLocalidades(int id, Localidades localidades)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != localidades.Id)
            {
                return BadRequest();
            }

            db.Entry(localidades).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LocalidadesExists(id))
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

        // POST: api/Localidades
        [ResponseType(typeof(Localidades))]
        public IHttpActionResult PostLocalidades(Localidades localidades)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Localidades.Add(localidades);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = localidades.Id }, localidades);
        }

        // DELETE: api/Localidades/5
        [ResponseType(typeof(Localidades))]
        public IHttpActionResult DeleteLocalidades(int id)
        {
            Localidades localidades = db.Localidades.Find(id);
            if (localidades == null)
            {
                return NotFound();
            }

            db.Localidades.Remove(localidades);
            db.SaveChanges();

            return Ok(localidades);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LocalidadesExists(int id)
        {
            return db.Localidades.Count(e => e.Id == id) > 0;
        }
    }
}