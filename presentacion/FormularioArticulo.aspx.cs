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
    public partial class FormularioArticulo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtId.Enabled = false;
            try
            {
                if (!IsPostBack)
                {
                    TipoNegocio tiponegocio = new TipoNegocio();
                    List<Tipo> ListaMarcas = tiponegocio.listarMarcas();
                    List<Tipo> ListaCategorias = tiponegocio.listarCategoria();

                    // configuro los desplegables esde bd con id y descripcion
                    ddlMarca.DataSource = ListaMarcas;
                    ddlMarca.DataTextField = "Descripcion";
                    ddlMarca.DataValueField = "Id";
                    ddlMarca.DataBind();

                    // Configuro los desplegable desde bd con id y descripcion
                    ddlCategoria.DataSource = ListaCategorias;
                    ddlCategoria.DataTextField = "Descripcion";
                    ddlCategoria.DataValueField = "Id";
                    ddlCategoria.DataBind();

                    if (Request.QueryString["Id"] != null)
                    {
                        int id = int.Parse(Request.QueryString["Id"].ToString());
                        List<Articulo> temporal = (List<Articulo>)Session["ListaArticulos"];
                        Articulo seleccionado = temporal.Find(x => x.Id == id);

                        //Carga de los controles
                        
                        txtId.Text = seleccionado.Id.ToString();
                        txtCodigo.Text = seleccionado.Codigo.ToString();
                        txtNombre.Text = seleccionado.Nombre;
                        txtDescripcion.Text = seleccionado.Descripcion;
                        txtImagenUrl.Text = seleccionado.UrlImagen;
                        imgArticulo.ImageUrl = seleccionado.UrlImagen;

                        // Selecciono los desplegables
                        ddlMarca.SelectedValue = seleccionado.Marca.Id.ToString();
                        ddlCategoria.SelectedValue = seleccionado.Categoria.Id.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                
            }
            
        }

        protected void txtImagenUrl_TextChanged(object sender, EventArgs e)
        {
            imgArticulo.ImageUrl = txtImagenUrl.Text;
        }
    }
}