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
    public class PedidosController : ApiController
    {
        private MundoCanjeDBEntities db = new MundoCanjeDBEntities();

        // GET: api/Pedidos
        public IQueryable<Pedidos> GetPedidos()
        {
            return db.Pedidos;
        }

        // GET: api/Pedidos/5
        [ResponseType(typeof(Pedidos))]
        public IHttpActionResult GetPedidos(int id)
        {
            Pedidos pedidos = db.Pedidos.Find(id);
            if (pedidos == null)
            {
                return NotFound();
            }

            return Ok(pedidos);
        }

        [HttpGet]
        [Route("api/Pedidos/PedidosByState/{idEstado}")]
        public List<PedidoViewModel> PedidosByState(int idEstado)
        {
            List<Pedidos> listaPedidos = db.Pedidos.Where(x => x.IdPedido_Estado == idEstado).ToList();

            if (listaPedidos == null)
            {
                return null;
            }

            List<PedidoViewModel> listVM = new List<PedidoViewModel>();
            foreach (var item in listaPedidos)
            {
                listVM.Add(new PedidoViewModel
                {
                    Id = item.Id,
                    IdProducto = item.IdProducto.Value,
                    IdUsuario = item.IdUsuario.Value,
                    IdPedido_Estado = item.IdPedido_Estado.Value,
                    Desc_Estado = item.Pedidos_Estados.Nombre,
                    Nombre_Producto = item.Productos.Nombre,
                    Desc_Producto = item.Productos.Descripcion,
                    Fecha_Pedido = (item.FechaPedido !=null)? item.FechaPedido.Value: item.FechaPedido,
                    Fecha_Entrega = (item.FechaEntrega != null) ? item.FechaEntrega.Value : item.FechaEntrega,
                    Img_Usuario = item.Productos.Usuarios.Imagen,
                    Nombre_Usuario = item.Productos.Usuarios.Nombre,
                    Importe = item.Importe.Value
                });

            }

            return listVM;
        }
        [HttpGet]
        [Route("api/Pedidos/CanjesByState/{idEstado}")]
        public List<PedidoViewModel> CanjesByState(int idEstado)
        {
            List<Pedidos> listaPedidos = db.Pedidos.Where(x => x.IdPedido_Estado == idEstado && x.Productos.IdTipo==1).ToList();

            if (listaPedidos == null)
            {
                return null;
            }

            List<PedidoViewModel> listVM = new List<PedidoViewModel>();
            foreach (var item in listaPedidos)
            {
                listVM.Add(new PedidoViewModel
                {
                    Id = item.Id,
                    IdProducto = item.IdProducto.Value,
                    IdUsuario = item.IdUsuario.Value,
                    IdPedido_Estado = item.IdPedido_Estado.Value,
                    Desc_Estado = item.Pedidos_Estados.Nombre,
                    Nombre_Producto = item.Productos.Nombre,
                    Desc_Producto = item.Productos.Descripcion,
                    Fecha_Pedido = (item.FechaPedido != null) ? item.FechaPedido.Value : item.FechaPedido,
                    Fecha_Entrega = (item.FechaEntrega != null) ? item.FechaEntrega.Value : item.FechaEntrega,
                    Img_Usuario = item.Productos.Usuarios.Imagen,
                    Nombre_Usuario = item.Productos.Usuarios.Nombre,
                    Importe = item.Importe.Value
                });

            }

            return listVM;
        }

        [HttpGet]
        [Route("api/Pedidos/UltimosCanjes/{Cantidad}")]
        public List<PedidoViewModel> UltimosCanjes(int Cantidad)
        {
            List<Pedidos> listaPedidos = db.Pedidos.Where(x => x.Productos.IdTipo == 1).OrderByDescending(z=> z.FechaPedido).Take(Cantidad).ToList();

            if (listaPedidos == null)
            {
                return null;
            }

            List<PedidoViewModel> listVM = new List<PedidoViewModel>();
            foreach (var item in listaPedidos)
            {
                listVM.Add(new PedidoViewModel
                {
                    Id = item.Id,
                    IdProducto = item.IdProducto.Value,
                    IdUsuario = item.IdUsuario.Value,
                    IdPedido_Estado = item.IdPedido_Estado.Value,
                    Desc_Estado = item.Pedidos_Estados.Nombre,
                    Nombre_Producto = item.Productos.Nombre,
                    Desc_Producto = item.Productos.Descripcion,
                    Fecha_Pedido = (item.FechaPedido != null) ? item.FechaPedido.Value : item.FechaPedido,
                    Fecha_Entrega = (item.FechaEntrega != null) ? item.FechaEntrega.Value : item.FechaEntrega,
                    Img_Usuario = item.Productos.Usuarios.Imagen,
                    Nombre_Usuario = item.Productos.Usuarios.Nombre,
                    Importe = item.Importe.Value
                });

            }

            return listVM;
        }

        [HttpGet]
        [Route("api/Pedidos/DescuentosByState/{idEstado}")]
        public List<PedidoViewModel> DescuentosByState(int idEstado)
        {
            
            List<PedidoViewModel> listVM = new List<PedidoViewModel>();
            if (idEstado == 1)
            {
                var ListaProd = db.Productos.Where(x => x.IdEstado == idEstado && x.IdTipo == 2).ToList();
                foreach (var item in ListaProd)
                {
                    listVM.Add(new PedidoViewModel
                    {
                        Id = item.Id,
                        IdProducto = item.Id,
                        IdUsuario = item.IdUsuario.Value,
                        IdPedido_Estado = item.IdEstado.Value,
                        Desc_Estado = item.Productos_Estados.Nombre,
                        Nombre_Producto = item.Nombre,
                        Desc_Producto = item.Descripcion,
                        Fecha_Pedido = (item.Fecha_Publicacion != null) ? item.Fecha_Publicacion.Value : item.Fecha_Publicacion,
                        Fecha_Entrega = null,
                        Img_Usuario = item.Usuarios.Imagen,
                        Nombre_Usuario = item.Usuarios.Nombre,
                        Importe = item.Importe.Value,
                        CodigoDescuento = item.CodigoDescuento
                    });
                }
            }
            else
            {
                List<Pedidos> listaPedidos = new List<Pedidos>();
                listaPedidos = db.Pedidos.Where(x => x.IdPedido_Estado == idEstado && x.Productos.IdTipo == 2).ToList();
                
                foreach (var item in listaPedidos)
                {
                    listVM.Add(new PedidoViewModel
                    {
                        Id = item.Id,
                        IdProducto = item.IdProducto.Value,
                        IdUsuario = item.IdUsuario.Value,
                        IdPedido_Estado = item.IdPedido_Estado.Value,
                        Desc_Estado = item.Pedidos_Estados.Nombre,
                        Nombre_Producto = item.Productos.Nombre,
                        Desc_Producto = item.Productos.Descripcion,
                        Fecha_Pedido = (item.FechaPedido != null) ? item.FechaPedido.Value : item.FechaPedido,
                        Fecha_Entrega = (item.FechaEntrega != null) ? item.FechaEntrega.Value : item.FechaEntrega,
                        Img_Usuario = item.Productos.Usuarios.Imagen,
                        Nombre_Usuario = item.Productos.Usuarios.Nombre,
                        Importe = item.Importe.Value
                    });
                }

                
            }
            return listVM;
        }

        [HttpGet]
        [Route("api/Pedidos/UltDescuentosDescargados/{Cantidad}")]
        public List<PedidoViewModel> UltimosDescuentos(int Cantidad)
        {

            List<PedidoViewModel> listVM = new List<PedidoViewModel>();            
            List<Pedidos> listaPedidos = new List<Pedidos>();
            listaPedidos = db.Pedidos.Where(x => x.Productos.IdTipo == 2).OrderByDescending(z => z.FechaPedido).Take(Cantidad).ToList();

            foreach (var item in listaPedidos)
            {
                listVM.Add(new PedidoViewModel
                {
                    Id = item.Id,
                    IdProducto = item.IdProducto.Value,
                    IdUsuario = item.IdUsuario.Value,
                    IdPedido_Estado = item.IdPedido_Estado.Value,
                    Desc_Estado = item.Pedidos_Estados.Nombre,
                    Nombre_Producto = item.Productos.Nombre,
                    Desc_Producto = item.Productos.Descripcion,
                    Fecha_Pedido = (item.FechaPedido != null) ? item.FechaPedido.Value : item.FechaPedido,
                    Fecha_Entrega = (item.FechaEntrega != null) ? item.FechaEntrega.Value : item.FechaEntrega,
                    Img_Comercio = item.Productos.Usuarios.Imagen,
                    Img_Usuario = item.Usuarios.Imagen,
                    Nombre_Usuario = item.Usuarios.Nombre,
                    Nombre_Comercio = item.Productos.Usuarios.Nombre,
                    Importe = (item.Importe!=null)? item.Importe.Value: 0,
                    CodigoDescuento = item.Productos.CodigoDescuento
                });
            }


            
            return listVM;
        }

        [HttpGet]
        [Route("api/Pedidos/PedidosCount/")]
        public ContadoresProductos PedidosCount()
        {
            try
            {


                //var CantCanjesPendientes = (from u in db.Productos where u.IdTipo==1 && u.IdEstado == 1 select u.Id).Count();
                var CantCanjesPendientes = (from u in db.Pedidos where u.Productos.IdTipo == 1 && u.IdPedido_Estado == 1 select u.Id).Count();
                var CantCanjesCancelados = (from u in db.Pedidos where u.Productos.IdTipo == 1 && u.IdPedido_Estado == 2 select u.Id).Count();
                var CantCanjesIniciados = (from u in db.Pedidos where u.Productos.IdTipo == 1 && u.IdPedido_Estado == 3 select u.Id).Count();
                var CantCanjesConfirmados = (from u in db.Pedidos where u.Productos.IdTipo == 1 && u.IdPedido_Estado == 4 select u.Id).Count();

                var CantDescuentosPendientes = (from u in db.Productos where u.IdTipo == 2 && u.IdEstado == 1 select u.Id).Count();
                var CantDescuentosCancelados = (from u in db.Pedidos where u.Productos.IdTipo == 2 && u.IdPedido_Estado == 2 select u.Id).Count();
                var CantDescuentosIniciados = (from u in db.Pedidos where u.Productos.IdTipo == 2 && u.IdPedido_Estado == 3 select u.Id).Count();
                var CantDescuentosConfirmados = (from u in db.Pedidos where u.Productos.IdTipo == 2 && u.IdPedido_Estado == 4 select u.Id).Count();

                
                ContadoresProductos Lista = new ContadoresProductos()
                {
                    CanjesPendientes = CantCanjesPendientes.ToString(),
                    CanjesCancelados = CantCanjesCancelados.ToString(),
                    CanjesIniciados = CantCanjesIniciados.ToString(),
                    CanjesConfirmados = CantCanjesConfirmados.ToString(),
                    DescuentosPendientes = CantDescuentosPendientes.ToString(),
                    DescuentosCancelados = CantDescuentosCancelados.ToString(),
                    DescuentosIniciados = CantDescuentosIniciados.ToString(),
                    DescuentosConfirmados = CantDescuentosConfirmados.ToString()
                };

                return Lista;

            }
            catch
            {
                return null;
            }


        }


        [HttpGet]
        [Route("api/Pedidos/HomeWebCount/")]
        public ContadoresHomeWeb HomeWebCount()
        {
            try
            {
                var CantPlanesVendidos = (from u in db.Usuarios where u.IdPlan != null && u.IdTipo == 1 select u.Id).Count();
                var CantCanjesConfirmados = (from u in db.Pedidos where u.Productos.IdTipo == 1 && u.IdPedido_Estado == 4 select u.Id).Count();
                var CantUsuariosActivos = (from u in db.Usuarios where u.Estado == 1 select u.Id).Count();


                ContadoresHomeWeb Lista = new ContadoresHomeWeb()
                {
                    PlanVendidoCant = CantPlanesVendidos.ToString(),
                    CanjesRealizadosCant = CantCanjesConfirmados.ToString(),
                    UsuariosActivosCant = CantUsuariosActivos.ToString()
                };


                return Lista;

            }
            catch
            {
                return null;
            }


        }

        // PUT: api/Pedidos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPedidos(int id, Pedidos pedidos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pedidos.Id)
            {
                return BadRequest();
            }

            db.Entry(pedidos).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PedidosExists(id))
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

        // POST: api/Pedidos
        [ResponseType(typeof(Pedidos))]
        public IHttpActionResult PostPedidos(Pedidos pedidos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Pedidos.Add(pedidos);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (PedidosExists(pedidos.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = pedidos.Id }, pedidos);
        }

        // DELETE: api/Pedidos/5
        [ResponseType(typeof(Pedidos))]
        public IHttpActionResult DeletePedidos(int id)
        {
            Pedidos pedidos = db.Pedidos.Find(id);
            if (pedidos == null)
            {
                return NotFound();
            }

            db.Pedidos.Remove(pedidos);
            db.SaveChanges();

            return Ok(pedidos);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PedidosExists(int id)
        {
            return db.Pedidos.Count(e => e.Id == id) > 0;
        }
    }
}