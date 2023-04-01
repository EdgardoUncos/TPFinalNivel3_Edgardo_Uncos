using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using dominio;

namespace presentacion
{
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (!Page.IsValid)
                return;

            User usuario = new User(txtEmail.Text, txtPassWord.Text, false);
            UsuarioNegocio negocio = new UsuarioNegocio();
            EmailService email = new EmailService();
            email.armarCorreo(usuario.Email, "Registro Pagina", "Bienvenido fuiste registrado como usuario normal");
            
            try
            {
                usuario.Id = negocio.insertarNuevoUsuario(usuario);
                Session.Add("usuario", usuario);
                email.enviarCorreo();
                Response.Redirect("Default.aspx", false);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}