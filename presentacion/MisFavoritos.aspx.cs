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
        public void cargarGrid2(object data, object control)
        {
            ((GridView)control).DataSource = (List<Articulo>)data;
            ((GridView)control).DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //Validamos en el page load, Porque la validacin de la master falla en esta pagina
                User usuario = Session["usuario"] != null ? (User)Session["usuario"] : null;
                if (!(usuario != null))
                    Response.Redirect("Login.aspx");

                ArticuloNegocio articulonegocio = new ArticuloNegocio();
                FavoritosNegocio negocio = new FavoritosNegocio();

                // si al ingresar al login viene directo a Mis Favoritos no existe aun en session la ListaArticulo
                if (Session["ListaArticulos"] == null)
                    Session.Add("ListaArticulos", articulonegocio.listar2());

                
                List<Favoritos> ListaFavoritos = negocio.ListarFavoritos();
                List<Articulo> ListaArticulos = (List<Articulo>)Session["ListaArticulos"];

                // Hacemos una lista todos los productos para una determinado Id de usuario, Usando Las Lista levantadas en sesion
                Session.Add("ListaFavoritosxIdUsuario", Helper.ListaFavUser(usuario.Id, ListaArticulos, ListaFavoritos));
                //dgvFavoritos2.DataSource = Session["ListaFavoritosxIdUsuario"];
                //dgvFavoritos2.DataBind();
                cargarGrid2(Session["ListaFavoritosxIdUsuario"], dgvFavoritos2);

                if (!IsPostBack)
                {
                    if (Request.QueryString["IdArticulo"] != null)
                    {

                        Favoritos nuevo = new Favoritos();
                        nuevo.IdUser = ((User)Session["usuario"]).Id;
                        nuevo.IdArticulo = int.Parse(Request.QueryString["IdArticulo"]);

                        negocio.agregar(nuevo);
                    }
                }

                // grid view de prueba
                //dgvFavoritos.DataSource = negocio.ListarFavoritos();
                //dgvFavoritos.DataBind();

                //Configuracion grid3
                ArticuloFavoritoNegocio negocio3 = new ArticuloFavoritoNegocio();
                List<ArticuloFavorito> listaAF = negocio3.listarArticulosFavoritos();
                dgvFavoritos3.DataSource = listaAF;
                dgvFavoritos3.DataBind();
                 

            }
            catch(System.Threading.ThreadAbortException ex) { }
            catch (Exception ex)
            {

                throw ex;
            }
            

        }

        // Este metodo se ejecuta cuando seleccionamos la accion
        //protected void dgvFavoritos_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    int id = int.Parse(dgvFavoritos.SelectedDataKey.Value.ToString());
        //}

        protected void dgvFavoritos2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idArticulo = int.Parse(dgvFavoritos2.SelectedDataKey.Value.ToString());
            FavoritosNegocio negocio = new FavoritosNegocio();
            int idUsuario = ((User)Session["usuario"]).Id;
            negocio.eliminar2(idUsuario, idArticulo);
            cargarGrid2(Session["ListaFavoritosxIdUsuario"], dgvFavoritos2);
            
        }

        protected void dgvFavoritos3_SelectedIndexChanged(object sender, EventArgs e)
        {
            var idFavorito = dgvFavoritos3.SelectedDataKey.Value.ToString();
        }

        //Para eliminar favoritos.
        //    Obtengo el Id articulo ya tengo en sesion el id del usuario
        //    Recorro la lista de favoritos, hago una lista con los que coincidan id y idarticulo.
        //    REcorro la lista en cada vuelta elimino
        // o con el id de articulo y el id de usuario voy recorriendo la lista de favoritos y en cada coincidencia borro.
        // al finalizar recargar en la sesion la lista de favoritos.
    }
}