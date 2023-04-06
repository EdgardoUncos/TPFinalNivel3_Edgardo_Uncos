using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    // Clase Articlo va a ser instanciada con los valores de la tabla de la BD ARTICULOS
    public class Articulo
    {
        // Va a contener el valor del id de
        // la tabla para poder modificar en la bd si es que lo precisamos
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string UrlImagen { get; set; }
        public Tipo Marca { get; set; }
        public Tipo Categoria { get; set; }

        public decimal Precio { get; set; }

    }
}
