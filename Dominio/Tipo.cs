using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    //Esta clase se va a utilizar para cargar registro de la tabla MARCAS y CATEGORIAS, ya que tiene solo dos campos y mismo tipo de datos
    public class Tipo
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        
        // Sobreescribimos el metodo ToString para que retorne la descipción
        public override string ToString()
        {
            return Descripcion;
        }
    }
}
