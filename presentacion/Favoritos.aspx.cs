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
        public List<Favoritos> ListaFavoritos { get; set; }
        public List<Articulo> ListaArticulo { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            //FavoritosNegocio negocio = new FavoritosNegocio();
            

            //ArticuloNegocio negocio2 = new ArticuloNegocio();
            //ListaArticulo = negocio2.listar2();
            
        }
    }
}