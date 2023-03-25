using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace presentacion
{
    public partial class ArticulosLista : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Creamos el Objeto listador y cargamos la gridview, luego usaremos Session y comentaremos como objetivo de repaso
            ArticuloNegocio negocio = new ArticuloNegocio();
            //dgvPokemonsLista.DataSource = negocio.listarConSP();
            Session.Add("ListaArticulos", negocio.listarConSP());
            dgvArticulosLista.DataSource = Session["ListaArticulos"];
            dgvArticulosLista.DataBind();
        }

        // SelectedIndexChanged evento cuando hacemos clic en modificar
        protected void dgvArticulosLista_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = dgvArticulosLista.SelectedDataKey.Value.ToString();
            Response.Redirect("FormularioArticulo.aspx?Id=" + id, false);
        }
        
        // PageIndexChanging evento que se dispara cuando hacemos clic en el boton de pagina siguiente
        protected void dgvArticulosLista_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvArticulosLista.PageIndex = e.NewPageIndex;
            dgvArticulosLista.DataBind();
        }

        


        

    }
}