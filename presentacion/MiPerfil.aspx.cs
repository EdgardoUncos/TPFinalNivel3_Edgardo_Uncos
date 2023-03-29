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
    public partial class MiPerfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Validamos en el page load, para no validar en todas las paginas habria que validar en la master
            User usuario = Session["usuario"] != null ? (User)Session["usuario"] : null;
            if(!(usuario != null && usuario.Id != 0) )
                    Response.Redirect("Login.aspx", false);

            if(!IsPostBack)
            {
                txtEmail.Text = usuario.Email;
                txtNombre.Text = usuario.Nombre;
                txtApellido.Text = usuario.Apellido;
                imgNuevoPerfil.ImageUrl = usuario.UrlImagenPerfil != null ? "~/Images/" + usuario.UrlImagenPerfil : "";
            }
            
            
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                //Capturamos el usuario de la session y lo casteamos

                User usuario = (User)Session["usuario"];
                UsuarioNegocio negocio = new UsuarioNegocio();

                //escribir la imagen
                if(txtImagen.PostedFile.FileName != "")
                {
                    string ruta = Server.MapPath("./Images/");
                    txtImagen.PostedFile.SaveAs(ruta + "perfil-" + usuario.Id + ".jpg");
                    usuario.UrlImagenPerfil = "perfil-" + usuario.Id + ".jpg";
                }

                // Guardar los datos de las cajas de texto
                usuario.Nombre = txtNombre.Text;
                usuario.Apellido = txtApellido.Text;
                usuario.FechaNacimiento = DateTime.Parse(txtFechaNacimiento.Text);

                negocio.actualizar(usuario);

                //leer la imagen
                Image img = (Image) Master.FindControl("imgAvatar");
                img.ImageUrl = "~/Images/" + usuario.UrlImagenPerfil;
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }


        }
    }
}