//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MundoCanjeWeb.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Productos
    {
        public Productos()
        {
            this.Pedidos = new HashSet<Pedidos>();
        }
    
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
        public string Imagen { get; set; }
        public string Imagen2 { get; set; }
        public string Imagen3 { get; set; }
        public string Imagen4 { get; set; }
        public string CodigoDescuento { get; set; }
    
        public virtual Categorias Categorias { get; set; }
        public virtual Despublicaciones_Tipos Despublicaciones_Tipos { get; set; }
        public virtual ICollection<Pedidos> Pedidos { get; set; }
        public virtual Productos_Estados Productos_Estados { get; set; }
        public virtual Productos_Tipos Productos_Tipos { get; set; }
        public virtual Usuarios Usuarios { get; set; }
    }
}
