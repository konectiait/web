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
    public partial class Categorias : System.Web.UI.Page
    {
        public void IniciarControles()
        {
            HdnIdCategoria.Value = "0";
            
            //LblIdLocalidad.Text = "";
            //TxbDescripcion.Text = "";
            //TxbDirecGMap.Text = "";
            //TxbProvincia.Text = "";

        }
        protected void Page_Load(object sender, EventArgs e)
        {

            //if (!IsPostBack)
            //{
            //    int Categoria = 0;
            //    if (Session["Admin"] == null)
            //    {
            //        Response.Redirect("Login.aspx");
            //    }
            //    else
            //    {
            //        try
            //        {
            //            IniciarControles();
            //            if (Request["Cat"] == null)
            //            {
            //                HdnEsNuevaCat.Value = "1";
            //                GetCategorias().Wait();
            //            }
            //            else
            //            {
            //                Categoria = Convert.ToInt32(Request["Cat"]);
            //                HdnIdCategoria.Value = Categoria.ToString();
            //                GetDatosCategoria(Categoria);
            //            }


            //        }
            //        catch (Exception ex)
            //        {
            //            ClientScript.RegisterStartupScript(this.GetType(), "myScript", "alert('Error. No se pudo otener la informacion de la categoria ingresada.');", true);                        
            //        }
            //    }
            //}
            if (Session["Admin"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                try
                {
                    IniciarControles();
                    GetDetalleGrilla().Wait();                    
                }
                catch (Exception ex)
                {
                    //Elmah.ErrorSignal.FromCurrentContext().Raise(ex);
                }
            }
        }
        
        public async Task GetDetalleGrilla() 
        {
            ApiServices objApi = new ApiServices();
            string Request = "{}";
            HttpResponseMessage response=objApi.CallService("categorias", Request, ApiServices.TypeMethods.GET).Result;
            
            if (response.IsSuccessStatusCode)
            {
                //resp = await response.Content.ReadAsAsync();
                string RespuestaVtex = await response.Content.ReadAsStringAsync();
                List<ResponseServices.RespCategorias> obj = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ResponseServices.RespCategorias>>(RespuestaVtex);
                string data = "";
                foreach (var item in obj)
                {

                    data += "<tr> ";
                    data += "<td> " + item.Id + " </td> ";
                    data += "<td> " + item.Nombre + " </td>  ";
                    data += "<td><img src='"+ item.Imagen+ "' style='width:200px !important;border-radius:0px !important;height: auto !important;' ></td> ";
                    data += "<td style='font-size: x-large'>  ";
                    data += "<a style='cursor:pointer' onclick='GetEditId(" + item.Id + ");return false' ><i class='mdi mdi-lead-pencil'></i><span class='count-symbol bg-warning'></span></a> ";
                    data += "<a style='cursor:pointer' onclick='SetDeleteId(" + item.Id + ");return false' ><i class='mdi mdi-delete-outline'></i><span class='count-symbol bg-warning'></span></a> ";
                    data += "</td>	</tr> ";

                }
                LitCategorias.Text = data;
            }
            else
            {
                string RespuestaService = await response.Content.ReadAsStringAsync();
                ApiServices.Response obj = Newtonsoft.Json.JsonConvert.DeserializeObject<ApiServices.Response>(RespuestaService);
                RespuestaService = response.StatusCode + " - " + obj.Error.message;
            }
            //return ListaOrdenes;
        }

        [WebMethod]
        public static async Task<List<Models.Categorias>> IniModalEdit(string Id)
        {
            List<Models.Categorias> lista = new List<Models.Categorias>();
            try
            {
                if (Id != "0")
                {
                    Int64 IdCateg = Convert.ToInt64(Id);
                    ApiServices objApi = new ApiServices();
                    string Request = "{}";
                    HttpResponseMessage response = objApi.CallService("categorias/"+ IdCateg, Request, ApiServices.TypeMethods.GET).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        //resp = await response.Content.ReadAsAsync();
                        string Respuesta = await response.Content.ReadAsStringAsync();
                        Models.Categorias obj = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.Categorias>(Respuesta);
                        if (obj != null)
                        {
                            lista.Add(new Models.Categorias
                            {
                                Id = obj.Id,
                                Nombre = obj.Nombre,
                                Imagen = obj.Imagen
                            });
                        }
                        
                    }

                }
            }
            catch
            {
                int sss = 0;
            }
            return lista;


        }

        [WebMethod]
        public static int Grabar(Models.Categorias categ, int EsNuevo)
        {
            try
            {
                if (categ != null)
                {
                    ApiServices objApi = new ApiServices();
                    HttpResponseMessage response = null;
                    string Request = Newtonsoft.Json.JsonConvert.SerializeObject(categ);
                    if(EsNuevo==0)
                    {
                        response = objApi.CallService("categorias/"+categ.Id, Request, ApiServices.TypeMethods.PUT).Result;
                    }
                    else
                    {
                        response = objApi.CallService("categorias", Request, ApiServices.TypeMethods.POST).Result;
                    }

                    if (response.IsSuccessStatusCode)
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                    
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                //Elmah.ErrorSignal.FromCurrentContext().Raise(ex);
                return 0;
            }

        }

        [WebMethod]
        public static int Eliminar(int idCategoria)
        {
            try
            {
                if (idCategoria > 0)
                {
                    ApiServices objApi = new ApiServices();
                    HttpResponseMessage response = null;
                    string Request = "{}";
                    response = objApi.CallService("categorias/" + idCategoria, Request, ApiServices.TypeMethods.DELETE).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                //Elmah.ErrorSignal.FromCurrentContext().Raise(ex);
                return 0;
            }

        }
    }
}