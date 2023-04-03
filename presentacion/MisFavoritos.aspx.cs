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
        private List<Articulo> ListaArticulos;
        private List<Favoritos> ListaFavoritos;

        public bool hayFavorito(int idArticulo, object lista)
        {
            List<Articulo> listaArticulos = (List<Articulo>)lista;

            foreach (Articulo articulo in listaArticulos)
            {
                if (articulo.Id == idArticulo)
                    return true;

            }
            return false; 
        }
            
        public void cargarGrid2(object data, object control)
        {
            ((GridView)control).DataSource = (List<Articulo>)data;
            ((GridView)control).DataBind();
            calcularSumaGrid();
        }
        public void calcularSumaGrid()
        {
            List<Articulo> lista = (List<Articulo>) Session["ListaFavoritosxIdUsuario"];
            decimal total=0;

            if (lista.Count != 0)
            {
                foreach (var item in lista)
                    total += item.Precio;

                dgvFavoritos2.FooterRow.Cells[4].Text = "Total";
                dgvFavoritos2.FooterRow.Cells[4].HorizontalAlign = HorizontalAlign.Right;
                dgvFavoritos2.FooterRow.Cells[5].Text = total.ToString("N2");

            }

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                /***        VALIDACION                    */
                //Validamos en el page load, Porque la validacin de la master falla en esta pagina
                User usuario = Session["usuario"] != null ? (User)Session["usuario"] : null;
                if (!(usuario != null))
                    Response.Redirect("Login.aspx");

                //------------------------------------------------------------------------------------

                FavoritosNegocio negocio = new FavoritosNegocio();
                ArticuloNegocio negocio2 = new ArticuloNegocio();
                
                

                
                //ListaFavoritos = negocio.ListarFavoritos();

                if(!IsPostBack)
                {
                    

                    //Lo Primero que hacemos es preguntar si vino un IdArticulo para Agregar en la lista de favoritos
                    if (Request.QueryString["IdArticulo"] != null)
                    {

                        Favoritos nuevo = new Favoritos();
                        nuevo.IdUser = ((User)Session["usuario"]).Id;
                        nuevo.IdArticulo = int.Parse(Request.QueryString["IdArticulo"]);

                        if (!hayFavorito(nuevo.IdArticulo, Helper.ListaFavUser(usuario.Id, negocio2.listar2(), negocio.ListarFavoritos())))
                            negocio.agregar(nuevo);
                        else
                            lblMensaje.Text = "Solo se puede agregar un favorito por tipo de producto -- Aun no es un Eccommerce ";
                    }
                    
                    
                    // si al ingresar al login viene directo a Mis Favoritos no existe aun en session la ListaArticulo
                    // Esta es la lista de todos los articulos favoritos de todos los usuarios
                    // luego encontraremos la lista de productos favoritos segun el usuario.

                    //Preguntamos Si hay en Session ListaArticulos de todos los usuarios
                    if (Session["ListaArticulos"] == null)
                    {
                        ListaArticulos = negocio2.listar2();
                        Session.Add("ListaArticulos", ListaArticulos);
                    }
                    else
                        ListaArticulos = (List<Articulo>)Session["ListaArticulos"];


                    // Hacemos una lista todos los productos para una determinado Id de usuario, Usando Las Lista levantadas en sesion
                    Session.Add("ListaFavoritosxIdUsuario", Helper.ListaFavUser(usuario.Id, negocio2.listar2(), negocio.ListarFavoritos()));
                    dgvFavoritos2.DataSource = Session["ListaFavoritosxIdUsuario"];
                    dgvFavoritos2.DataBind();
                    this.calcularSumaGrid();
                }


                                                                                        

                //dgvFavoritos2.DataSource = Session["ListaFavoritosxIdUsuario"];
                //dgvFavoritos2.DataBind();
                //cargarGrid2(Session["ListaFavoritosxIdUsuario"], dgvFavoritos2);

               
                // grid view de prueba
                //dgvFavoritos.DataSource = negocio.ListarFavoritos();
                //dgvFavoritos.DataBind();

                //Configuracion grid3
                //ArticuloFavoritoNegocio negocio3 = new ArticuloFavoritoNegocio();
                //List<ArticuloFavorito> listaAF = negocio3.listarArticulosFavoritos();
                //dgvFavoritos3.DataSource = listaAF;
                //dgvFavoritos3.DataBind();
                 

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
            FavoritosNegocio negocio = new FavoritosNegocio();
            ArticuloNegocio negocio2 = new ArticuloNegocio();

            lblMensaje.Text = "";

            int idArticulo = int.Parse(dgvFavoritos2.SelectedDataKey.Value.ToString());
            int idUsuario = ((User)Session["usuario"]).Id;
            negocio.eliminar2(idUsuario, idArticulo);
            ListaArticulos = negocio2.listar2();
            Session.Add("ListaFavoritosxIdUsuario", Helper.ListaFavUser(idUsuario, negocio2.listar2(), negocio.ListarFavoritos()));
            cargarGrid2(Session["ListaFavoritosxIdUsuario"], dgvFavoritos2);

            
        }

        //protected void dgvFavoritos3_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    var idFavorito = dgvFavoritos3.SelectedDataKey.Value.ToString();
        //    FavoritosNegocio negocio = new FavoritosNegocio();
        //    negocio.eliminar(((User)Session["usuario"]).Id);
        //}

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            dgvFavoritos2.DataBind();
        }

        //Para eliminar favoritos.
        //    Obtengo el Id articulo ya tengo en sesion el id del usuario
        //    Recorro la lista de favoritos, hago una lista con los que coincidan id y idarticulo.
        //    REcorro la lista en cada vuelta elimino
        // o con el id de articulo y el id de usuario voy recorriendo la lista de favoritos y en cada coincidencia borro.
        // al finalizar recargar en la sesion la lista de favoritos.
    }
}