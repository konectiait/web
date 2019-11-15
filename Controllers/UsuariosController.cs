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
    public class UsuariosController : ApiController
    {
        private MundoCanjeDBEntities db = new MundoCanjeDBEntities();

        // GET: api/Usuarios
        public IQueryable<Usuarios> GetUsuarios()
        {
            return db.Usuarios;
        }

        // GET: api/Usuarios/5
        [ResponseType(typeof(Usuarios))]
        public IHttpActionResult GetUsuarios(int id)
        {
            Usuarios usuarios = db.Usuarios.Find(id);
            if (usuarios == null)
            {
                return NotFound();
            }

            return Ok(usuarios);
        }

        [HttpGet]
        [Route("api/usuarios/GetUsuariosByTipo/{TipoId}")]
        public IHttpActionResult GetUsuariosByTipo(int TipoId)
        {
            List<Usuarios> listUsuarios = db.Usuarios.Where(x => x.IdTipo == TipoId).ToList();
            if (listUsuarios == null)
            {
                return NotFound();
            }

            return Ok(listUsuarios);
        }

        [HttpGet]
        [Route("api/usuarios/GetUsuariosById/{Id}")]
        public UsuarioViewModel GetUsuariosById(int Id)
        {
            Usuarios listUsuarios = db.Usuarios.Where(x => x.Id == Id).FirstOrDefault();
            if (listUsuarios == null)
            {
                return null;
            }
            UsuarioViewModel listVM = new UsuarioViewModel()
            {
                Id = listUsuarios.Id,
                Nombre = listUsuarios.Nombre,
                Telefono = (listUsuarios.Telefono != null) ? listUsuarios.Telefono.Value : 0,
                Mail = listUsuarios.Mail,
                Direccion = listUsuarios.Direccion,
                token = listUsuarios.token,
                Estado = (listUsuarios.Estado != null) ? listUsuarios.Estado.Value : 0,
                IdTipo = (listUsuarios.IdTipo != null) ? listUsuarios.IdTipo.Value : 0,
                Cuit = listUsuarios.Cuit,
                Razon_Social = listUsuarios.Razon_Social,
                Lat = listUsuarios.Lat,
                Long = listUsuarios.Long,
                Puntuacion = (listUsuarios.Puntuacion != null) ? listUsuarios.Puntuacion.Value : 0,
                Imagen = listUsuarios.Imagen,
                IdPlan = (listUsuarios.IdPlan != null) ? listUsuarios.IdPlan.Value : 0,
                IdLocalidad = (listUsuarios.IdLocalidad != null) ? listUsuarios.IdLocalidad.Value : 0,
                Fecha_Alta = (listUsuarios.Fecha_Alta != null) ? listUsuarios.Fecha_Alta.Value : DateTime.MinValue,
            };
            

            return listVM;
        }

        [HttpGet]
        [Route("api/usuarios/GetUsuarioByToken/{Token}")]
        public IHttpActionResult GetUsuarioByToken(string Token)
        {
            Usuarios objUsuarios = db.Usuarios.Where(x => x.token == Token).FirstOrDefault();
            if (objUsuarios == null)
            {
                return NotFound();
            }

            return Ok(objUsuarios);
        }

        [HttpGet]
        [Route("api/usuarios/UltimosUsuarios/{Cantidad}")]
        public IHttpActionResult UltimosUsuarios(int Cantidad)
        {
            var listaUsuarios = db.Usuarios.OrderByDescending(z => z.Id).Take(Cantidad).ToList();
            if (listaUsuarios == null)
            {
                return NotFound();
            }

            return Ok(listaUsuarios);
        }

        // PUT: api/Usuarios/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUsuarios(int id, Usuarios usuarios)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != usuarios.Id)
            {
                return BadRequest();
            }

            db.Entry(usuarios).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuariosExists(id))
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

        // POST: api/Usuarios
        [ResponseType(typeof(Usuarios))]
        public IHttpActionResult PostUsuarios(Usuarios usuarios)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Usuarios.Add(usuarios);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (UsuariosExists(usuarios.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = usuarios.Id }, usuarios);
        }

        // DELETE: api/Usuarios/5
        [ResponseType(typeof(Usuarios))]
        public IHttpActionResult DeleteUsuarios(int id)
        {
            Usuarios usuarios = db.Usuarios.Find(id);
            if (usuarios == null)
            {
                return NotFound();
            }

            db.Usuarios.Remove(usuarios);
            db.SaveChanges();

            return Ok(usuarios);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UsuariosExists(int id)
        {
            return db.Usuarios.Count(e => e.Id == id) > 0;
        }
    }
}