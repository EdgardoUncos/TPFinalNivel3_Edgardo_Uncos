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
        public PaginacionRespuesta PaginacionRespuesta { get; set; }

        public PaginacionViewModel PaginacionViewModel { get; set; }

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

                    //ListaArticulos = negocio.listarConSP();
                    if (PaginacionViewModel == null)
                        PaginacionViewModel = new PaginacionViewModel();

                    if (Request.QueryString["pagina"] != null && Request.QueryString["recordsPorPagina"] != null)
                    {
                        PaginacionViewModel.Pagina = int.Parse(Request.QueryString["pagina"].ToString());
                        PaginacionViewModel.RecordsPorPagina = int.Parse(Request.QueryString["recordsPorPagina"].ToString());
                    }

                    OpcionesFiltro opcionesFiltro;

                    if (Session["opcionesFiltro"] != null)
                    {
                        opcionesFiltro = (OpcionesFiltro)Session["opcionesFiltro"];
                        txtMinimo.Text = opcionesFiltro.precioMinimo.ToString();
                        txtMaximo.Text = opcionesFiltro.precioMaximo.ToString();
                        ddlCategoria.SelectedValue = opcionesFiltro.CategoriaValor.ToString();
                        ddlMarca.SelectedValue = opcionesFiltro.MarcaValor.ToString();
                    }
                    else
                        opcionesFiltro = new OpcionesFiltro();

                    ListaArticulos = negocio.FiltrarAvanzado(opcionesFiltro, PaginacionViewModel);

                    // El la clase que usamos en el Front
                    PaginacionRespuesta = new PaginacionRespuesta()
                    {
                        Pagina = PaginacionViewModel.Pagina,
                        RecordsPorPagina = PaginacionViewModel.RecordsPorPagina,
                        CantidadTotalRecords = PaginacionViewModel.CantidadTotalRegistros
                    };

                    Session.Add("ListaArticulos", ListaArticulos);

                    //if (Session["ListaArticulos"] == null)
                    //    Session.Add("ListaArticulos", ListaArticulos);
                    //CargarRepeater(Session["ListaArticulos"]);
                    CargarRepeater(ListaArticulos);

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
            ArticuloNegocio negocio = new ArticuloNegocio();

            try
            {
                if (PaginacionViewModel == null)
                    PaginacionViewModel = new PaginacionViewModel();

                OpcionesFiltro opcionesFiltro = new OpcionesFiltro()
                {
                    precioMinimo = txtMinimo.Text,
                    precioMaximo = txtMaximo.Text,
                    MarcaValor = ddlMarca.SelectedValue.ToString(),
                    CategoriaValor = ddlCategoria.SelectedValue.ToString()
                };
                // Trae la primera pagina segun los criterios de los controles
                ListaArticulos = negocio.FiltrarAvanzado(opcionesFiltro, PaginacionViewModel);

                if (Session["opcionesFiltro"] == null)
                {
                    Session.Add("opcionesFiltro", opcionesFiltro);
                }
                else
                {
                    Session["opcionesFiltro"] = opcionesFiltro;
                }

                PaginacionRespuesta = new PaginacionRespuesta()
                {
                    Pagina = PaginacionViewModel.Pagina,
                    RecordsPorPagina = PaginacionViewModel.RecordsPorPagina,
                    CantidadTotalRecords = PaginacionViewModel.CantidadTotalRegistros
                };
                CargarRepeater(ListaArticulos);
            }
            catch (Exception ex)
            {
                Response.Redirect("Error.aspx", false);

            }

        }

        protected void btnReiniciar_Click(object sender, EventArgs e)
        {
            //ArticuloNegocio negocio = new ArticuloNegocio();
            //ListaArticulos = negocio.listarConSP();
            //Session.Add("ListaArticulos", ListaArticulos);
            //CargarRepeater(Session["ListaArticulos"]);

            ddlMarca.SelectedIndex = 0;
            ddlCategoria.SelectedIndex = 0;
            ArticuloNegocio negocio = new ArticuloNegocio();

            PaginacionViewModel = new PaginacionViewModel();
            ListaArticulos = negocio.FiltrarAvanzado(new OpcionesFiltro(), PaginacionViewModel);

            PaginacionRespuesta = new PaginacionRespuesta()
            {
                Pagina = PaginacionViewModel.Pagina,
                RecordsPorPagina = PaginacionViewModel.RecordsPorPagina,
                CantidadTotalRecords = PaginacionViewModel.CantidadTotalRegistros
            };

            Session["opcionesFiltro"] = null;

            CargarRepeater(ListaArticulos);
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