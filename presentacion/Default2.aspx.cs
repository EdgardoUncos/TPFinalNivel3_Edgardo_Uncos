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
    public partial class Default2 : System.Web.UI.Page
    {
        public List<Articulo> ListaArticulos { get; set; }

        private void CargarRepeater(object lista)
        {
            List<Articulo> listado = (List<Articulo>)lista;
            repRepetidor.DataSource = listado;
            repRepetidor.DataBind();
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

                   
                }




            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}