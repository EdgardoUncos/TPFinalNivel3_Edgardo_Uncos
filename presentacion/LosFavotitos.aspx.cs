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
        private List<Articulo> ListaFavoritosUsuario; // Lista que obtendremos de un procesamiento
        
        protected void Page_Load(object sender, EventArgs e)
        {
            

            FavoritosNegocio negocioF = new FavoritosNegocio();
            ArticuloNegocio negocioA = new ArticuloNegocio();

            ListaFavoritos = negocioF.ListarFavoritos(); 
            ListaArticulos = negocioA.listar2();

            

            if (!IsPostBack)
            {
                //    //Preguntamos Si hay en Session ListaArticulos de todos los usuarios
                //    if (Session["ListaArticulos"] == null)
                //    {
                //        ListaArticulos = negocioA.listar2();
                //        Session.Add("ListaArticulos", ListaArticulos);
                //    }

                //    if (Request.QueryString["IdProducto"] != null)
                //    {
                //        int IdProducto = int.Parse(Request.QueryString["IdProducto"].ToString());

                //        // Preguntamos si hay un usuario logeado.
                //        if (Seguridad.SessionActiva(Session["usuario"]))
                //        {
                //            int IdUser = ((User)Session["Usuario"]).Id;
                //            if(!Helper.hayFavorito(IdProducto, Session["listaArticulo"]))
                //            {
                //                Favoritos nuevo = new Favoritos();
                //                nuevo.IdArticulo = IdProducto;
                //                nuevo.IdUser = IdUser;
                //                negocioF.agregar(nuevo);
                //                listaFavoritosUsuario = Helper.ListaFavUser(IdUser, ListaArticulos, ListaFavoritos);
                //                dgvFavoritos.DataSource = listaFavoritosUsuario;
                //                dgvFavoritos.DataBind();

                //            }
                //        }
                //    }
                //    else
                //    {
                //        Session.Add("error", "No puede no haber favorito");
                //        //Response.Redirect("Error.aspx");
                //    }

                // Probamos cargar la grig con los valores del usuario logueado
                if(Request.QueryString["IdProducto"] != null)
                {
                    int IdProducto = int.Parse(Request.QueryString["IdProducto"].ToString());

                    // Si estoy logueado
                    if (Seguridad.SessionActiva(Session["usuario"]))
                    {
                        User usuario;
                        usuario = (User)Session["usuario"];
                        //ListaFavoritosUsuario = Helper.ListaFavUser(usuario.Id, ListaArticulos, ListaFavoritos);
                        ListaFavoritosUsuario = negocioA.ListarFavoritos(usuario.Id);
                        
                        if(!hayProducto(IdProducto, ListaFavoritosUsuario))
                        {
                            Favoritos aux = new Favoritos();
                            aux.IdUser = usuario.Id;
                            aux.IdArticulo = IdProducto;
                            negocioF.agregar(aux);
                            //ListaFavoritosUsuario.Add(ListaArticulos.Find(x => x.Id == IdProducto));   
                            ListaFavoritosUsuario = negocioA.ListarFavoritos(usuario.Id);
                        }    

                        // falta agregar favorito.

                        //dgvFavoritos.DataSource = ListaFavoritosUsuario;
                        //dgvFavoritos.DataBind();
                    }
                    else //Si no estoy logueado y Si hay IdProducto en la Url
                    {
                        User invitado = new User("", "", false);
                        Articulo nuevo = new Articulo();

                        if (ListaFavoritosUsuario == null)
                            ListaFavoritosUsuario = new List<Articulo>();

                        if (Session["ListaFavoritosUsuario"] == null)
                        {
                            Session.Add("ListaFavoritosUsuario", ListaFavoritosUsuario);
                        }
                        ListaFavoritosUsuario = (List<Articulo>)Session["ListaFavoritosUsuario"];
                        if(!hayProducto(IdProducto, ListaFavoritosUsuario))
                            ListaFavoritosUsuario.Add( ListaArticulos.Find(x => x.Id== IdProducto));
                    

                        //dgvFavoritos.DataSource = ListaFavoritosUsuario;
                        //dgvFavoritos.DataBind();
                    
                    }
                }
                else
                    //Si No hay Id en la url
                {
                    if (Seguridad.SessionActiva(Session["usuario"]))
                    {
                        User usuario;
                        usuario = (User)Session["usuario"];

                        ListaFavoritosUsuario = negocioA.ListarFavoritos(usuario.Id);
                        //dgvFavoritos.DataSource = ListaFavoritosUsuario;
                        //dgvFavoritos.DataBind();
                        //this.calcularSumaGrid();
                    }
                    else
                    {
                        ListaFavoritosUsuario = (List<Articulo>)Session["ListaFavoritosUsuario"];
                    }


                }

                dgvFavoritos.DataSource = ListaFavoritosUsuario;
                dgvFavoritos.DataBind();
                this.calcularSumaGrid();

            }

        }

        protected void dgvFavoritos_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idProducto = int.Parse(dgvFavoritos.SelectedDataKey.Value.ToString());

            if (Seguridad.SessionActiva(Session["usuario"]))
            {
                int idUsuario = ((User)Session["usuario"]).Id;
                ArticuloNegocio negocioA = new ArticuloNegocio();
                negocioA.EliminarArticuloFav(idUsuario, idProducto);

                ListaFavoritosUsuario = negocioA.ListarFavoritos(idUsuario);

            }
            else
            {
                ListaFavoritosUsuario = (List<Articulo>)Session["ListaFavoritosUsuario"];
                ListaFavoritosUsuario.Remove(ListaFavoritosUsuario.Find(x => x.Id == idProducto));
            }

            dgvFavoritos.DataSource = ListaFavoritosUsuario;
            dgvFavoritos.DataBind();
            calcularSumaGrid();

        }

        protected bool hayProducto(int IdProducto, object lista)
        {
            List<Articulo> ListaFavoritos = (List<Articulo>)lista;

            if (ListaFavoritos.Find(x => x.Id == IdProducto) == null)
                return false;

            return true;
        }

        public void calcularSumaGrid()
        {
            
            decimal total = 0;

            if (ListaFavoritosUsuario!=null && ListaFavoritosUsuario.Count != 0)
            {
                foreach (var item in ListaFavoritosUsuario)
                    total += item.Precio;

                dgvFavoritos.FooterRow.Cells[4].Text = "Total";
                dgvFavoritos.FooterRow.Cells[4].HorizontalAlign = HorizontalAlign.Right;
                dgvFavoritos.FooterRow.Cells[5].Text = total.ToString("N2");

            }

        }

        //public void calcularSumaGrid()
        //{
        //    List<Articulo> lista = (List<Articulo>)Session["ListaFavoritosxIdUsuario"];
        //    decimal total = 0;

        //    if (lista.Count != 0)
        //    {
        //        foreach (var item in lista)
        //            total += item.Precio;

        //        dgvFavoritos2.FooterRow.Cells[4].Text = "Total";
        //        dgvFavoritos2.FooterRow.Cells[4].HorizontalAlign = HorizontalAlign.Right;
        //        dgvFavoritos2.FooterRow.Cells[5].Text = total.ToString("N2");

        //    }

        //}
    }
}