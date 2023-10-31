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
    public partial class Default : System.Web.UI.Page
    {
        public List<Articulo> ListaArticulos { get; set; }

        private void CargarRepeater(object lista)
        {
            List<Articulo> listado = (List<Articulo>)lista;
            repRepedidor.DataSource = listado;
            repRepedidor.DataBind();
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    ArticuloNegocio negocio = new ArticuloNegocio();
                    ListaArticulos = negocio.listarConSP();
                    if (Session["ListaArticulos"] == null)
                        Session.Add("ListaArticulos", ListaArticulos);
                    CargarRepeater(Session["ListaArticulos"]);

                    TipoNegocio tipoNegocio = new TipoNegocio();
                    ddlCategoria.DataSource = tipoNegocio.listarCategoria();
                    ddlCategoria.SelectedIndex = -1;
                    ddlCategoria.DataTextField = "Descripcion";
                    ddlCategoria.DataValueField = "Id";
                    ddlCategoria.DataBind();

                    ddlMarca.DataSource = tipoNegocio.listarMarcas();
                    ddlMarca.SelectedIndex = -1;
                    ddlMarca.DataTextField = "Descripcion";
                    ddlMarca.DataValueField = "Id";
                    ddlMarca.DataBind();
                }




            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            List<Articulo> ListaFiltrada = (List<Articulo>)Session["ListaArticulos"];
            List<Articulo> ListaArticulos = (List<Articulo>)Session["ListaArticulos"];
            try
            {
                
                ListaFiltrada = Filtrar(ListaArticulos, txtMinimo.Text, txtMaximo.Text, ddlMarca.SelectedItem.ToString(), ddlCategoria.SelectedItem.ToString());
                ListaArticulos = ListaFiltrada;


                CargarRepeater(ListaFiltrada);
            }
            catch (Exception ex)
            {
                Response.Redirect("Error.aspx", false);

            }

        }

        protected void btnReiniciar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            ListaArticulos = negocio.listarConSP();
            Session.Add("ListaArticulos", ListaArticulos);
            CargarRepeater(Session["ListaArticulos"]);

            ddlMarca.SelectedIndex = 0;
            ddlCategoria.SelectedIndex = 0;
        }

        protected void btnFavoritos_Click(object sender, EventArgs e)
        {
            string id = ((Button)sender).CommandArgument;
        }

        // Metodo que filtra segun los parametros, devuelve una lista de articulos
        private List<Articulo> Filtrar(List<Articulo> lista, string precioMinimo, string precioMaximo, string marca, string categoria)
        {
            List<Articulo> ListaFiltrada = lista;

            if (!string.IsNullOrEmpty(precioMinimo))
                if (!string.IsNullOrEmpty(precioMaximo))
                    ListaFiltrada = lista.FindAll(x => x.Precio >= Decimal.Parse(precioMinimo.ToString()) && x.Precio <= Decimal.Parse(precioMaximo.ToString()));
                else
                    ListaFiltrada = lista.FindAll(x => x.Precio >= Decimal.Parse(precioMinimo.ToString()));

            else
                if (!string.IsNullOrEmpty(precioMaximo))
                ListaFiltrada = lista.FindAll(x => x.Precio <= Decimal.Parse(precioMaximo.ToString()));

            string opcion = marca;
            if (opcion != "Filtrar Marca")
                ListaFiltrada = ListaFiltrada.FindAll(x => x.Marca.Descripcion == opcion);

            opcion = categoria;
            if (opcion != "Filtrar Categoria")
                ListaFiltrada = ListaFiltrada.FindAll(x => x.Categoria.Descripcion == opcion);

            return ListaFiltrada;
        }
    }
}