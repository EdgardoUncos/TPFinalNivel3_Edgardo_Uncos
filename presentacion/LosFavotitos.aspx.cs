﻿using System;
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

        //Evento de Carga Page Load
        // Creamos los obejtos Negocios necesarios, Si no es POstback, Si hay un IdProducto en la Url como Parametro, verificamos si esta logueado,  entonces agregamos el Art favorito.
        //Si no estoy logueado y Si hay IdProducto en la Url. Entonces lo dejamos agregar favoritos en session como invitado, no guarda en BD
        protected void Page_Load(object sender, EventArgs e)
        {
            

            FavoritosNegocio negocioF = new FavoritosNegocio();
            ArticuloNegocio negocioA = new ArticuloNegocio();

            ListaFavoritos = negocioF.ListarFavoritos(); 
            ListaArticulos = negocioA.listar2();

            

            if (!IsPostBack)
            {
                
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
                            negocioF.agregarFav(aux);
                            //ListaFavoritosUsuario.Add(ListaArticulos.Find(x => x.Id == IdProducto));   
                            ListaFavoritosUsuario = negocioA.ListarFavoritos(usuario.Id);
                        }    

                       
                    }
                    else //Si no estoy logueado y Si hay IdProducto en la Url. Entonces lo dejamos agregar favoritos en session como invitado, no guarda en BD
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
                                      
                    }
                }
                else
                    //Si No hay Id de producto en la url, verificamos si hay usuario logueado, entonces cargamos la lista de favoritos
                {
                    if (Seguridad.SessionActiva(Session["usuario"]))
                    {
                        User usuario;
                        usuario = (User)Session["usuario"];

                        ListaFavoritosUsuario = negocioA.ListarFavoritos(usuario.Id);
                       
                    }
                    else
                    {
                        ListaFavoritosUsuario = (List<Articulo>)Session["ListaFavoritosUsuario"];
                    }


                }

                // Finalmente cargamos la grid con la lista de favoritos y calculamos la suma

                dgvFavoritos.DataSource = ListaFavoritosUsuario;
                dgvFavoritos.DataBind();
                this.calcularSumaGrid();

            }

        }

        // Evento al hacer clic en eliminar
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

        // Metodo auxiliar obetivo verificar que en la lista de favoritos este el id de producto, True si esta el articulo, false caso contrario
        protected bool hayProducto(int IdProducto, object lista)
        {
            List<Articulo> ListaFavoritos = (List<Articulo>)lista;

            if (ListaFavoritos == null ||  ListaFavoritos.Find(x => x.Id == IdProducto) == null)
                return false;

            return true;
        }

        // Metodo que calcula la suma de todos los favoritos.
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

       
    }
}