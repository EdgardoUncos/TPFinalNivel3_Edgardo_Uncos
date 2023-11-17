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
    public partial class ArticulosLista : System.Web.UI.Page
    {
        public bool FiltroAvanzado { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            //Validamos el ingreso a la pagina - Para que sea mas optimo habria que validar en la master
            if (!((User)Session["usuario"] != null && ((User)Session["usuario"]).Id != 0))
                Response.Redirect("Login.aspx", false);

            FiltroAvanzado = chkFiltroAvanzado.Checked;

            if(!IsPostBack)
            {
            }
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

        protected void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtFiltro.Text;
            List<Articulo> ListaArticulos = (List<Articulo>)Session["ListaArticulos"];

            List<Articulo> Filtrada = ListaArticulos.FindAll(x => x.Codigo.ToUpper().Contains(filtro.ToUpper()) 
            || x.Nombre.ToUpper().Contains(filtro.ToUpper()) || x.Descripcion.ToUpper().Contains(filtro.ToUpper()));
            // cargamos en la grid la nueva lista, luego se podria hacer en una funcion
            dgvArticulosLista.DataSource = Filtrada;
            dgvArticulosLista.DataBind();
        }

        protected void chkFiltroAvanzado_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFiltroAvanzado.Checked)
            {
                txtFiltro.Enabled = false;
                FiltroAvanzado = true;
            }
            else
            {
                txtFiltro.Enabled = true;
                FiltroAvanzado = false;
            }
        }

        protected void ddlCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCriterio.Items.Clear();
            if(ddlCampo.SelectedItem.Value.ToString() == "Codigo")
            {
                ddlCriterio.Items.Add("Comienza con");
                ddlCriterio.Items.Add("Termina con");
                ddlCriterio.Items.Add("Contiene");
            }
            else
            {
                ddlCriterio.Items.Add("Comienza con");
                ddlCriterio.Items.Add("Termina con");
                ddlCriterio.Items.Add("Contiene");
            }

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string campo = ddlCampo.SelectedItem.Value.ToString();
                string criterio = ddlCriterio.SelectedItem.Value.ToString();
                string filtro = txtFiltroAvanzado.Text;
                ArticuloNegocio negocio = new ArticuloNegocio();
                dgvArticulosLista.DataSource = negocio.filtrar(campo, criterio, filtro);
                dgvArticulosLista.DataBind();
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
            }
        }

        protected void btnReiniciar_Click(object sender, EventArgs e)
        {
            ddlCampo.SelectedIndex = 0;
            ddlCriterio.SelectedIndex = 0;
            txtFiltroAvanzado.Text = string.Empty;

            if(Session["ListaArticulos"] != null)
            {
                dgvArticulosLista.DataSource = Session["ListaArticulos"];
                dgvArticulosLista.DataBind();
            }
        }
    }
}