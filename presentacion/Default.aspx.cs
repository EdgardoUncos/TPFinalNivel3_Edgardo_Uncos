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
        private ArticuloNegocio negocio = new ArticuloNegocio();
        public List<Articulo> ListaArticulos { get; set; }
        public PaginacionViewModel PaginacionViewModel { get; set; } = new PaginacionViewModel();

        public List<Articulo> ListaArticuloPagina { get; set; }
        public PaginacionRespuesta<Articulo> PaginacionRespuesta { get; set; }

        // metodo que filtra una lista con un parametro de paginacion. Retorna una lista
        private List<Articulo> PaginarConParametro(List<Articulo> lista, PaginacionViewModel parametro)
        {
            List<Articulo>  filtrada  = (from l in lista select l).Skip(parametro.RecordsASaltar).Take(parametro.RecordsPorPagina).ToList();

            return filtrada;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                
                if (!IsPostBack)
                {
                    PaginacionViewModel PaginacionViewModel = new PaginacionViewModel();

                    ListaArticulos = negocio.listar();
                    if (Session["ListaArticulos"] == null)
                    {
                        Session.Add("ListaArticulos", ListaArticulos);
                    }
                    //ListaArticuloPagina = negocio.listarPaginacionViewModel(PaginacionViewModel);
                    ListaArticuloPagina = PaginarConParametro(ListaArticulos, PaginacionViewModel);

                    PaginacionRespuesta = new PaginacionRespuesta<Articulo>()
                    {
                        Elementos = ListaArticuloPagina,
                        Pagina = 1,
                        RecordsPorPagina = 5,
                        CantidadTotalRecords = ListaArticulos.Count
                    };

                    
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

                    if (Request.QueryString["pagina"] != null && Request.QueryString["recordsPorPagina"]!= null)
                    {
                        // Parametros de paginacion
                        PaginacionViewModel.Pagina = int.Parse(Request.QueryString["pagina"].ToString());
                        PaginacionViewModel.RecordsPorPagina = int.Parse(Request.QueryString["recordsPorPagina"].ToString());

                        ListaArticulos = Session["ListaArticulos"] != null ? (List<Articulo>)Session["ListaArticulos"] : negocio.listar();
                        //ListaArticuloPagina = negocio.listarPaginacionViewModel(PaginacionViewModel);
                        ListaArticuloPagina = PaginarConParametro(ListaArticulos, PaginacionViewModel);
                        

                        PaginacionRespuesta = new PaginacionRespuesta<Articulo>()
                        {
                            Elementos = ListaArticuloPagina,
                            Pagina = PaginacionViewModel.Pagina,
                            RecordsPorPagina = PaginacionViewModel.RecordsPorPagina,
                            CantidadTotalRecords = ListaArticulos.Count
                        };
                    }



                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            // Lista que resulta de filtrar segun precio o minimo o categoria
            List<Articulo> ListaFiltrada;
            List<Articulo> Pagina;

            // Lista de todos los articulo, de aca se filtrara.
            List<Articulo> Lista = negocio.listar();

            try
            {
                // Filtramos segun parametros y asignamos la lista a -- PaginacionRespuesta.Elementos --
                
                ListaFiltrada = Filtrar(Lista, txtMinimo.Text, txtMaximo.Text, ddlMarca.SelectedItem.ToString(), ddlCategoria.SelectedItem.ToString());
                Pagina = PaginarConParametro(ListaFiltrada, PaginacionViewModel);
                ListaArticulos = ListaFiltrada;

                Session["ListaArticulos"] = ListaFiltrada;

                PaginacionRespuesta = new PaginacionRespuesta<Articulo>()
                {
                    Elementos = Pagina,
                    Pagina = 1,
                    RecordsPorPagina = 5,
                    CantidadTotalRecords = ListaFiltrada.Count
                };

                              
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

            ListaArticuloPagina = PaginarConParametro(ListaArticulos, PaginacionViewModel);

            PaginacionRespuesta = new PaginacionRespuesta<Articulo>()
            {
                Elementos = ListaArticuloPagina,
                Pagina = 1,
                RecordsPorPagina = 5,
                CantidadTotalRecords = ListaArticulos.Count
            };
            
            
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