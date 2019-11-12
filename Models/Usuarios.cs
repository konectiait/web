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
    
    public partial class Usuarios
    {
        public Usuarios()
        {
            this.Productos = new HashSet<Productos>();
            this.Pedidos = new HashSet<Pedidos>();
        }
    
        public int Id { get; set; }
        public string Nombre { get; set; }
        public Nullable<int> Telefono { get; set; }
        public string Mail { get; set; }
        public string Direccion { get; set; }
        public string token { get; set; }
        public Nullable<int> Estado { get; set; }
        public Nullable<int> IdTipo { get; set; }
        public string Cuit { get; set; }
        public string Razon_Social { get; set; }
        public string Lat { get; set; }
        public string Long { get; set; }
        public Nullable<int> Puntuacion { get; set; }
        public string Imagen { get; set; }
        public Nullable<int> IdPlan { get; set; }
        public Nullable<int> IdLocalidad { get; set; }
        public Nullable<System.DateTime> Fecha_Alta { get; set; }
    
        public virtual ICollection<Productos> Productos { get; set; }
        public virtual Usuarios_Tipos Usuarios_Tipos { get; set; }
        public virtual Planes Planes { get; set; }
        public virtual Localidades Localidades { get; set; }
        public virtual ICollection<Pedidos> Pedidos { get; set; }
    }
}
