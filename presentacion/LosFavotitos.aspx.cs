using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace presentacion
{
    public partial class LosFavotitos : System.Web.UI.Page
    {
        private List<Articulo> ListaArticulos; // Lista de articulos de la base de datos
        private List<Favoritos> ListaFavoritos;
        private List<Articulo> listaFavoritosUsuario; // Lista que obtendremos de un procesamiento
        
        protected void Page_Load(object sender, EventArgs e)
        {
            

            FavoritosNegocio negocioF = new FavoritosNegocio();
            ArticuloNegocio negocioA = new ArticuloNegocio();
            

            if (!IsPostBack)
            {
                //Preguntamos Si hay en Session ListaArticulos de todos los usuarios
                if (Session["ListaArticulos"] == null)
                {
                    ListaArticulos = negocioA.listar2();
                    Session.Add("ListaArticulos", ListaArticulos);
                }
                
                if (Request.QueryString["IdProducto"] != null)
                {
                    int IdProducto = int.Parse(Request.QueryString["IdProducto"].ToString());

                    // Preguntamos si hay un usuario logeado.
                    if (Seguridad.SessionActiva(Session["usuario"]))
                    {
                        int IdUser = ((User)Session["Usuario"]).Id;
                        if(!Helper.hayFavorito(IdProducto, Session["listaArticulo"]))
                        {
                            Favoritos nuevo = new Favoritos();
                            nuevo.IdArticulo = IdProducto;
                            nuevo.IdUser = IdUser;
                            negocioF.agregar(nuevo);
                            dgvFavoritos.DataSource = Helper.ListaFavUser(IdUser, ListaArticulos, ListaFavoritos);
                            dgvFavoritos.DataBind();
                            
                        }
                    }
                }
                else
                {
                    Session.Add("error", "No puede no haber favorito");
                    //Response.Redirect("Error.aspx");
                }

            }

        }

        protected void dgvFavoritos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}