using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;


namespace negocio
{
    public static class Seguridad
    {
        public static bool esAdmin(object user)
        {
            User usuario = user != null ? (User)user : null;
            return usuario.Admin;
        }
        public static bool SessionActiva(object user)
        {
            User usuario = user != null ? (User)user : null;
            if (usuario != null && usuario.Id != 0)
                return true;
            else
                return false;
        }
    }
}
