using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MundoCanjeWeb.Models
{
    public class ProductoViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public Nullable<int> IdTipo { get; set; }
        public Nullable<int> IdEstado { get; set; }
        public Nullable<decimal> Importe { get; set; }
        public Nullable<System.DateTime> Fecha_Publicacion { get; set; }
        public Nullable<int> TipoDespublicacion { get; set; }
        public Nullable<int> IdCategoria { get; set; }
        public Nullable<int> IdUsuario { get; set; }
        public Nullable<int> Cantidad { get; set; }
    }
}