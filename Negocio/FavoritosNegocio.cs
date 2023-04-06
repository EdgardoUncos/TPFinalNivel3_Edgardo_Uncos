using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class FavoritosNegocio
    {
        
        public List<Favoritos> ListarFavoritos()
        {
            List<Favoritos> lista = new List<Favoritos>();

            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Select Id, IdUser, IdArticulo From Favoritos");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Favoritos aux = new Favoritos();
                    if (!(datos.Lector["Id"] is DBNull))
                        aux.Id = (int)datos.Lector["Id"];
                    if (!(datos.Lector["IdUser"] is DBNull))
                        aux.IdUser = (int)datos.Lector["IdUser"];

                    if (!(datos.Lector["IdArticulo"] is DBNull))
                        aux.IdArticulo = (int)datos.Lector["IdArticulo"];


                    lista.Add(aux);

                }
                datos.cerrarConexion();
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        public void agregar(Favoritos fav)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Insert Into Favoritos (IdUser, IdArticulo) values (@idUser, @idArticulo)");
                datos.setearParametro("@idUser", fav.IdUser);
                datos.setearParametro("@idArticulo", fav.IdArticulo);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void eliminar(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Delete From FAVORITOS Where Id = @id");
                datos.setearParametro("@id", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void eliminar2(int idUsuario, int idArticulo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Delete From FAVORITOS Where IdUser = @idUsuario AND IdArticulo = @idArticulo");
                datos.setearParametro("@idUsuario", idUsuario);
                datos.setearParametro("@idArticulo", idArticulo);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex; 
            }
        }

        public List<Favoritos> listaFavUsuario(int idUsuaro)
        {
            List<Favoritos> lista = new List<Favoritos>();

            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Select Id, IdUser, IdArticulo From Favoritos Where IdUser = @idUsuario");
                datos.setearParametro("idUsuario", idUsuaro);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Favoritos aux = new Favoritos();
                    if (!(datos.Lector["Id"] is DBNull))
                        aux.Id = (int)datos.Lector["Id"];
                    if (!(datos.Lector["IdUser"] is DBNull))
                        aux.IdUser = (int)datos.Lector["IdUser"];

                    if (!(datos.Lector["IdArticulo"] is DBNull))
                        aux.IdArticulo = (int)datos.Lector["IdArticulo"];


                    lista.Add(aux);

                }
                datos.cerrarConexion();
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
