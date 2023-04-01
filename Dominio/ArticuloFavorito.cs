using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class ArticuloFavorito
    {
        public int IdFavorito { get; set; }
        public int IdUser { get; set; }
        public int IdArticulo { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string UrlImagen { get; set; }
        public Tipo Marca { get; set; }
        public Tipo Categoria { get; set; }

        public decimal Precio { get; set; }
    }
}
