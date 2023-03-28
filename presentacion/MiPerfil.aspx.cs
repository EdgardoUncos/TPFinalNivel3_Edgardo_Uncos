using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;

namespace presentacion
{
    public partial class MiPerfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Validamos en el page load, para no validar en todas las paginas habria que validar en la master
            User usuario = Session["usuario"] != null ? (User)Session["usuario"] : null;
            if(!(usuario != null))
                    Response.Redirect("Login.apx", false);
                
            
            
        }
    }
}