using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MundoCanjeWeb.Models
{
    public class PedidoViewModel
    {
        public int Id { get; set; }
        public int IdProducto { get; set; }
        public int IdUsuario { get; set; }
        public int IdPedido_Estado { get; set; }
        public string Desc_Estado { get; set; }
        public string Nombre_Producto { get; set; }
        public string Desc_Producto { get; set; }
        public string Img_Usuario { get; set; }
        public string Nombre_Usuario { get; set; }
        public DateTime? Fecha_Pedido { get; set; }
        public DateTime? Fecha_Entrega { get; set; }
        public Decimal Importe { get; set; }
        public string CodigoDescuento { get; set; }
        public string Img_Comercio { get; set; }
        public string Nombre_Comercio { get; set; }
    }
}