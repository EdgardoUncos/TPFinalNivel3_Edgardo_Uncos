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

        private void CargarRepeater()
        {
            repRepedidor.DataSource = Session["ListaArticulos"];
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
                    CargarRepeater();
                }
                     
                
                

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            List<Articulo> ListaFiltrada;
            List<Articulo> ListaArticulos = (List<Articulo>)Session["ListaArticulos"];

            if (!string.IsNullOrEmpty(txtMinimo.Text))
                if (!string.IsNullOrEmpty(txtMaximo.Text))
                    ListaFiltrada = ListaArticulos.FindAll(x => x.Precio >= Decimal.Parse(txtMinimo.Text.ToString()) && x.Precio <= Decimal.Parse(txtMaximo.Text.ToString()));
                else
                    ListaFiltrada = ListaArticulos.FindAll(x => x.Precio >= Decimal.Parse(txtMinimo.Text.ToString()));

            else
                if (!string.IsNullOrEmpty(txtMaximo.Text))
                ListaFiltrada = ListaArticulos.FindAll(x => x.Precio >= Decimal.Parse(txtMinimo.Text.ToString()));
            else
                ListaFiltrada = ListaArticulos;

            Session.Add("ListaArticulos", ListaFiltrada);

            ListaArticulos = ListaFiltrada;

            CargarRepeater();
        }

        protected void btnReiniciar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            ListaArticulos = negocio.listarConSP();
            Session.Add("ListaArticulos", ListaArticulos);

        }

        protected void btnFavoritos_Click(object sender, EventArgs e)
        {
            string id = ((Button)sender).CommandArgument;
        }
    }
}