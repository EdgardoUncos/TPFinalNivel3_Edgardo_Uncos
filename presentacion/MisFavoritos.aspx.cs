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
    public partial class MisFavoritos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FavoritosNegocio negocio = new FavoritosNegocio();
            
            if(!IsPostBack)
            {
                if(Request.QueryString["IdArticulo"]!= null)
                {
                    
                    Favoritos nuevo = new Favoritos();
                    nuevo.IdUser = ((User)Session["usuario"]).Id;
                    nuevo.IdArticulo = int.Parse(Request.QueryString["IdArticulo"]);

                    negocio.agregar(nuevo);
                }    
            }
            dgvFavoritos.DataSource = negocio.ListarFavoritos();
            dgvFavoritos.DataBind();

        }

        // Este metodo se ejecuta cuando seleccionamos la accion
        protected void dgvFavoritos_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = int.Parse(dgvFavoritos.SelectedDataKey.Value.ToString());
        }
    }
}