using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using dominio;

namespace presentacion
{
    public partial class Favoritos : System.Web.UI.Page
    {
        public List<Favoritos> UsuarioFavoritos { get; set; }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            FavoritosNegocio negocio = new FavoritosNegocio();
            Session.Add("listafavoritos", negocio.ListarFavoritos());
            int id = ((User)Session["usuario"]).Id;
            UsuarioFavoritos = ((List<Favoritos>)Session["listafavoritos"]);
           

            dgvFavoritos.DataBind();
            

        }
    }
}