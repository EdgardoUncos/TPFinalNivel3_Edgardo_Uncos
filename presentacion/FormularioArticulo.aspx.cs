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
    public partial class FormularioArticulo : System.Web.UI.Page
    {
        public bool ConfirmaEliminacion { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ConfirmaEliminacion = false;
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

                    // Si hay un Id en la Url entonces tengo un Articulo para mostrar en el formulario
                    if (Request.QueryString["Id"] != null)
                    {
                        //Seleccciono el Id y los busco desde la Session o Podria buscarlo desde la BD
                        int id = int.Parse(Request.QueryString["Id"].ToString());
                        List<Articulo> ListaArticulos = (List<Articulo>)Session["ListaArticulos"];
                        Articulo seleccionado = ListaArticulos.Find(x => x.Id == id);
                        Session.Add("seleccionado", seleccionado);

                        //Carga de los controles

                        btnAceptar.Text = "Modificar";
                        txtId.Text = seleccionado.Id.ToString();
                        txtCodigo.Text = seleccionado.Codigo.ToString();
                        txtNombre.Text = seleccionado.Nombre;
                        txtDescripcion.Text = seleccionado.Descripcion;
                        txtPrecio.Text = seleccionado.Precio.ToString();
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

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            Articulo nuevo = new Articulo();
            ArticuloNegocio negocio = new ArticuloNegocio();

            try
            {
                
                nuevo.Nombre = txtNombre.Text;
                nuevo.Codigo = txtCodigo.Text;
                nuevo.Descripcion = txtDescripcion.Text;
                nuevo.UrlImagen = txtImagenUrl.Text;
                nuevo.Precio = Decimal.Parse(txtPrecio.Text);
                nuevo.Marca = new Tipo();
                nuevo.Marca.Id = int.Parse(ddlMarca.SelectedValue);
                nuevo.Categoria = new Tipo();
                nuevo.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);

                if (string.IsNullOrEmpty(txtId.Text))
                {//negocio.agregar(nuevo);
                    negocio.agregarConSP(nuevo);
                }
                else
                {
                    nuevo.Id = int.Parse(txtId.Text);
                    negocio.modificarConSP(nuevo);
                }

                Response.Redirect("ArticulosLista.aspx", false);
            }

            
            catch (Exception ex)
            {

                Session.Add("error", ex);
            }
        }

        protected void bntEliminar_Click(object sender, EventArgs e)
        {
            ConfirmaEliminacion = true;
        }

        
        protected void chkConfirmaEliminacion_CheckedChanged(object sender, EventArgs e)
        {
            ConfirmaEliminacion = chkConfirmaEliminacion.Checked;
        }

        protected void btnConfirmaEliminacion_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();

            if (chkConfirmaEliminacion.Checked)
            {
                //negocio.eliminar(int.Parse(Request.QueryString["Id"]));
                //negocio.eliminar(((Articulo)Session["seleccionado"]).Id);
                negocio.eliminar(int.Parse(txtId.Text));
                Response.Redirect("ArticulosLista.aspx", false);
            }
        }
    }
}