using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;
using negocio;

namespace negocio
{
    public class ArticuloFavoritoNegocio
    {
        public List<ArticuloFavorito> listarArticulosFavoritos()
        {
            List<ArticuloFavorito> Lista = new List<ArticuloFavorito>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select A.Id as IdArticulo, A.Codigo, A.Nombre, A.Descripcion, IdMarca, M.Descripcion Marca, IdCategoria, C.Descripcion AS Categoria, ImagenUrl, Precio, U.Id As IdUser, F.Id as IdFavorito from ARTICULOS A, MARCAS M, CATEGORIAS C, FAVORITOS F, USERS U Where A.IdMarca = M.Id and A.IdCategoria = C.Id and A.Id = F.IdArticulo And U.Id = F.IdUser");
                datos.ejecutarLectura();
                while(datos.Lector.Read())
                {
                    ArticuloFavorito aux = new ArticuloFavorito();
                    aux.IdArticulo = (int)datos.Lector["IdArticulo"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Marca = new Tipo();
                    aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                    aux.Categoria = new Tipo();
                    aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                    aux.UrlImagen = (string)datos.Lector["ImagenUrl"];
                    aux.Precio = decimal.Parse(datos.Lector["Precio"].ToString());
                    aux.IdUser = (int)datos.Lector["IdUser"];
                    aux.IdFavorito = (int)datos.Lector["IdFavorito"];

                    Lista.Add(aux);
                }
                return Lista;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
