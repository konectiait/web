using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MundoCanjeWeb.Cpanel
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void BtnIngresar_Click(object sender, EventArgs e)
        {
            if ((TxbEmail.Text == "adminchris" && TxbClave.Text == "adminchris"))
            {
                Session.Add("Admin", TxbEmail.Text);                
                Response.Redirect("Default.aspx", false);

            }
            else
            {
                LblError.Text = "Usuario incorrecto.";
            }
        }
    }
}