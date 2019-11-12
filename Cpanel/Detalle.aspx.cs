using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MundoCanjeWeb.Cpanel.Clases;
using System.Threading.Tasks;
using System.Web.Services;

namespace MundoCanjeWeb.Cpanel
{
    public partial class Detalle : System.Web.UI.Page
    {
        public void IniciarControles()
        {
            HdnIdCanje.Value = "0";


        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Admin"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                try
                {
                    string idPedido = Request.QueryString["id"];
                    IniciarControles();

                    if (idPedido != null)
                    {
                        GetDetallePedido(Convert.ToInt32(idPedido));
                    }

                }
                catch (Exception ex)
                {
                    //Elmah.ErrorSignal.FromCurrentContext().Raise(ex);
                }
            }
        }

        public void GetDetallePedido(int idPed)
        {
            
            ApiServices objApi = new ApiServices();
            string Request = "{}";
            HttpResponseMessage response=objApi.CallService("Pedidos/"+ idPed, Request, ApiServices.TypeMethods.GET).Result;
            
            if (response.IsSuccessStatusCode)
            {
                string Respuesta = response.Content.ReadAsStringAsync().Result;
                Models.Pedidos obj = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.Pedidos>(Respuesta);

                LblTitulo.Text = "Detalle de Canje #"+ obj.Id.ToString();
                LblUsuarioVendedor.Text = obj.Productos.Usuarios.Nombre.ToString();
                LblFechaAltaCanje.Text = obj.FechaPedido.Value.ToShortDateString();
                LblImporte.Text = "$" +obj.Productos.Importe.ToString();
                imgUsuario.ImageUrl = obj.Productos.Usuarios.Imagen;

                string data = "";
                data += "<div class='row mt-3'> ";
                data += "<div class='col-6 pr-1'> ";
                data += "<img src='"+ obj.Productos.Imagen+ "' class='mb-2 mw-100 w-100 rounded' alt='image'> ";
                if(obj.Productos.Imagen2!=null)
                    data += "<img src='" + obj.Productos.Imagen2 + "' class='mw-100 w-100 rounded' alt='image'> ";

                data += "</div> ";                
                data += "</div> ";

                LitImgCanje.Text = data;

                ///////////////
                string dataProd = "";
                dataProd += "<div class='d-flex mt-5 align-items-top'> ";
               //dataProd += "<img src='"+obj.Usuarios.Imagen+"' class='img-sm rounded-circle mr-3' alt='image'> ";
                dataProd += "<div class='mb-0 flex-grow'> ";
                dataProd += "<h5 class='mr-2 mb-2'>"+obj.Productos.Nombre+"</h5> ";
                dataProd += "<p class='mb-0 font-weight-light'>" + obj.Productos.Descripcion + "</p> ";
                dataProd += "</div></div> ";

                LitDetalleCanje.Text = dataProd;

                if(obj.IdPedido_Estado>2)
                {
                    DivMatch.Visible = true;
                    GetDatosComprador(obj);
                }
                else
                {
                    DivMatch.Visible = false;
                }
            }
            else
            {
                string RespuestaService = response.Content.ReadAsStringAsync().Result;
                ApiServices.Response obj = Newtonsoft.Json.JsonConvert.DeserializeObject<ApiServices.Response>(RespuestaService);
                RespuestaService = response.StatusCode + " - " + obj.Error.message;
            }
            //return ListaOrdenes;
        }
        public void GetDatosComprador(Models.Pedidos obj)
        {

            LblUsuarioComprador.Text = obj.Usuarios.Nombre.ToString();
            LblFechaEntrega.Text = (obj.FechaEntrega!=null) ? obj.FechaEntrega.Value.ToShortDateString():"";
            LblImporteDiferencia.Text = "Diferencia $" + obj.ImporteDiferencia.ToString();
            imgUsuarioComprador.ImageUrl = obj.Usuarios.Imagen;

            string data = "";
            data += "<div class='row mt-3'> ";
            data += "<div class='col-6 pr-1'> ";
            data += "<img src='" + obj.ImagenMatch + "' class='mb-2 mw-100 w-100 rounded' alt='image'> ";
            
            data += "</div> ";
            data += "</div> ";

            LitImgCanjeComprador.Text = data;

            ///////////////
            string dataProd = "";
            dataProd += "<div class='d-flex mt-5 align-items-top'> ";
            dataProd += "<div class='mb-0 flex-grow'> ";
            dataProd += "<h5 class='mr-2 mb-2'>" + obj.ProductoNombreMatch + "</h5> ";
            dataProd += "<p class='mb-0 font-weight-light'>" + obj.ProductoDescripcionMatch + "</p> ";
            dataProd += "</div></div> ";

            LitDetalleCanjeComprador.Text = dataProd;
        }
        
    }
}