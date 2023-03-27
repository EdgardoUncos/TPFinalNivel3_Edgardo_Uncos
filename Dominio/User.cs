using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public enum TipoUsuario
    {
        NORMAL = 0,
        ADMIN = 1
    }
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Pass { get; set; }
        public TipoUsuario TipoUsuario { get; set; }

        public User(string email, string pass, bool admin)
        {
            Email = email;
            Pass = pass;
            TipoUsuario = admin ? TipoUsuario.ADMIN : TipoUsuario.NORMAL;
        }
    }
}
