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
        public List<Articulo> ListaArticulo { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            FavoritosNegocio negocio = new FavoritosNegocio();
            ListaArticulo = (List<Articulo>)Session["ListaArticulos"];
            List<Favoritos> ListaFavoritos = negocio.ListarFavoritos();
            List<Articulo> ListaAP = new List<Articulo>();
            int id = ((User)Session["usuario"]).Id;

            foreach (var item in ListaFavoritos)
            {
                if(id == item.IdUser)
                    ListaAP.Add(ListaArticulo.Find(x => x.Id == item.IdArticulo));
            }
            dgvFavoritos2.DataSource = ListaAP;
            dgvFavoritos2.DataBind();    

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

        protected void dgvFavoritos2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idArticulo = int.Parse(dgvFavoritos2.SelectedDataKey.Value.ToString());
            FavoritosNegocio negocio = new FavoritosNegocio();
            int idUsuario = ((User)Session["usuario"]).Id;
            negocio.eliminar2(idUsuario, idArticulo);

            
        }

        //Para eliminar favoritos.
        //    Obtengo el Id articulo ya tengo en sesion el id del usuario
        //    Recorro la lista de favoritos, hago una lista con los que coincidan id y idarticulo.
        //    REcorro la lista en cada vuelta elimino
        // o con el id de articulo y el id de usuario voy recorriendo la lista de favoritos y en cada coincidencia borro.
        // al finalizar recargar en la sesion la lista de favoritos.
    }
}