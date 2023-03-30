using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;

namespace presentacion
{
    public partial class Favoritos : System.Web.UI.Page
    {
        public List<Favoritos> ListaFavoritos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            FavoritosNegocio negocio = new FavoritosNegocio();
            ListaFavoritos = negocio.ListarFavoritos();
            
        }
    }
}