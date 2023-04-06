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
    public partial class Detalle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
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
                if (Request.QueryString["IdArticulo"] != null)
                {
                    //Seleccciono el Id y los busco desde la Session o Podria buscarlo desde la BD
                    int id = int.Parse(Request.QueryString["IdArticulo"].ToString());

                    // Preguntamos si la ListaArticulos en session fue creada
                    if (Session["ListaArticulos"]== null)
                    {
                        ArticuloNegocio negocio = new ArticuloNegocio();
                        Session.Add("ListaArticulos", negocio.listarConSP());
                    }
                    
                    List<Articulo> ListaArticulos = (List<Articulo>)Session["ListaArticulos"];
                    Articulo seleccionado = ListaArticulos.Find(x => x.Id == id);
                    //Carga de los controles

                    
                   
                    txtCodigo.Text = seleccionado.Codigo.ToString();
                    txtNombre.Text = seleccionado.Nombre;
                    txtDescripcion.Text = seleccionado.Descripcion;
                    txtPrecio.Text = seleccionado.Precio.ToString();
                    imgArticulo.ImageUrl = seleccionado.UrlImagen;
                    

                    // Selecciono los desplegables
                    ddlMarca.SelectedValue = seleccionado.Marca.Id.ToString();
                    ddlCategoria.SelectedValue = seleccionado.Categoria.Id.ToString();

                    // Deshabilitar controles
                    txtCodigo.Enabled = false;
                    txtNombre.Enabled = false;
                    txtDescripcion.Enabled = false;
                    txtPrecio.Enabled = false;
                    ddlCategoria.Enabled = false;
                    ddlMarca.Enabled = false;
                }

            }    



        }
    }
}