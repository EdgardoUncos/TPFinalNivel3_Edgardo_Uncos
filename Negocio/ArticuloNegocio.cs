using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using dominio;



namespace negocio
{
    public class ArticuloNegocio
    {

        public List<Articulo> listar()
        {
            List<Articulo> lista = new List<Articulo>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=CATALOGO_WEB_DB; integrated security=true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "select A.Id, A.Codigo, Nombre, A.Descripcion, IdMarca, M.Descripcion Marca, IdCategoria, C.Descripcion AS Categoria, ImagenUrl, Precio from ARTICULOS A, MARCAS M, CATEGORIAS C Where A.IdMarca = M.Id and A.IdCategoria = C.Id";
                comando.Connection = conexion;
                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = lector.GetInt32(0);
                    aux.Codigo = lector.GetString(1);
                    aux.Nombre = (string)lector["Nombre"];
                    aux.Descripcion = (string)lector["Descripcion"];

                    aux.Marca = new Tipo();
                    aux.Marca.Id = (int)lector["IdMarca"];
                    aux.Marca.Descripcion = (string)lector["Marca"];

                    aux.Categoria = new Tipo();
                    aux.Categoria.Id = (int)lector["IdCategoria"];
                    aux.Categoria.Descripcion = (string)lector["Categoria"];

                    aux.UrlImagen = (string)lector["ImagenUrl"];
                    aux.Precio = (decimal)lector["Precio"];

                    lista.Add(aux);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return lista;
        }

        // Listar2 es igual a listar, solo que hace uso de la clase AccesoDatos.
        public List<Articulo> listar2()
        {
            List<Articulo> lista = new List<Articulo>();

            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("select A.Id, A.Codigo, Nombre, A.Descripcion, IdMarca, M.Descripcion Marca, IdCategoria, C.Descripcion AS Categoria, ImagenUrl, Precio from ARTICULOS A, MARCAS M, CATEGORIAS C Where A.IdMarca = M.Id and A.IdCategoria = C.Id");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["Id"];
                    if (!(datos.Lector["Codigo"] is DBNull))
                        aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Marca = new Tipo();
                    aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                    aux.Categoria = new Tipo();
                    aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                        aux.UrlImagen = (string)datos.Lector["ImagenUrl"];
                    aux.Precio = (decimal)datos.Lector["Precio"];

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

        // Metodo con Stored Procedure, hace lo mismo que listar, reutilizamos casi todo el codigo.
        public List<Articulo> listarConSP()
        {
            //create procedure storedListar as
            //Select A.Id, A.Codigo, Nombre, A.Descripcion, IdMarca, M.Descripcion Marca, IdCategoria, C.Descripcion AS Categoria, 
            //    ImagenUrl, Precio from ARTICULOS A, MARCAS M, CATEGORIAS C Where A.IdMarca = M.Id and A.IdCategoria = C.Id

            List<Articulo> lista = new List<Articulo>();

            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("storedListar");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["Id"];
                    if (!(datos.Lector["Codigo"] is DBNull))
                        aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Marca = new Tipo();
                    aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                    aux.Categoria = new Tipo();
                    aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                        aux.UrlImagen = (string)datos.Lector["ImagenUrl"];
                    aux.Precio = (decimal)datos.Lector["Precio"];

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



        public void agregar(Articulo nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("insert into ARTICULOS (Nombre, Descripcion, Precio, IdMarca, IdCategoria, Codigo, ImagenUrl) values ('" + nuevo.Nombre + "','" + nuevo.Descripcion + "', " + nuevo.Precio + " , @idMarca, @idCategoria, @codigo, @urlimagen )");
                datos.setearParametro("@idMarca", nuevo.Marca.Id);
                datos.setearParametro("@idCategoria", nuevo.Categoria.Id);
                datos.setearParametro("@urlimagen", nuevo.UrlImagen);
                datos.setearParametro("@codigo", nuevo.Codigo);
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

//        create procedure StoredAltaArticulo
//        @codigo varchar(50),
//        @nombre varchar(50),
//        @desc varchar(50),
//        @idmarca int,
//        @idcategoria int,
//        @img varchar(300),
//        @precio money
//        as 
//        insert into ARTICULOS values(@codigo, @nombre, @desc, @idmarca, @idcategoria, @img, @precio)
        public void agregarConSP(Articulo nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("StoredAltaArticulo");
                datos.setearParametro("@codigo", nuevo.Codigo);
                datos.setearParametro("@nombre", nuevo.Nombre);
                datos.setearParametro("@desc", nuevo.Descripcion);
                datos.setearParametro("@idmarca", nuevo.Marca.Id);
                datos.setearParametro("@idcategoria", nuevo.Categoria.Id);
                datos.setearParametro("@img", nuevo.UrlImagen);
                datos.setearParametro("@precio", nuevo.Precio);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

              
        public void modificar(Articulo seleccionado)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("update ARTICULOS set Codigo = @codigo, Nombre = @nombre, Descripcion = @descripcion, IdMarca = @idMarca, IdCategoria = @idCategoria, ImagenUrl = @imagenUrl, Precio = @precio where Id = @id");
                datos.setearParametro("@codigo", seleccionado.Codigo);
                datos.setearParametro("@nombre", seleccionado.Nombre);
                datos.setearParametro("@descripcion", seleccionado.Descripcion);
                datos.setearParametro("@idMarca", seleccionado.Marca.Id);
                datos.setearParametro("idCategoria", seleccionado.Categoria.Id);
                datos.setearParametro("imagenUrl", seleccionado.UrlImagen);
                datos.setearParametro("@precio", seleccionado.Precio);
                datos.setearParametro("@id", seleccionado.Id);

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

        public void modificarConSP(Articulo seleccionado)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("storedModificarArticulo");
                datos.setearParametro("@codigo", seleccionado.Codigo);
                datos.setearParametro("@nombre", seleccionado.Nombre);
                datos.setearParametro("@desc", seleccionado.Descripcion);
                datos.setearParametro("@idmarca", seleccionado.Marca.Id);
                datos.setearParametro("@idcategoria", seleccionado.Categoria.Id);
                datos.setearParametro("@img", seleccionado.UrlImagen);
                datos.setearParametro("@precio", seleccionado.Precio);
                datos.setearParametro("@id", seleccionado.Id);

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

        public List<Articulo> filtrar (string campo, string criterio, string filtro)
        {
            List<Articulo> listaFiltrada = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            string consulta = "select A.Id, A.Codigo, Nombre, A.Descripcion, IdMarca, M.Descripcion Marca, IdCategoria, C.Descripcion AS Categoria, ImagenUrl, Precio from ARTICULOS A, MARCAS M, CATEGORIAS C Where A.IdMarca = M.Id and A.IdCategoria = C.Id And ";

            if (campo == "Codigo")
            {
                switch(criterio)
                {
                    case "Comineza con": 
                        consulta += "A.Codigo like '" + filtro + "%' ";
                        break;

                    case "Contiene":
                        consulta += "A.Codigo like '%" + filtro + "%' ";
                        break;

                    case "Termina con":
                        consulta += "A.Codigo like '%" + filtro + "'";
                        break;

                }
            }
            else if(campo == "Nombre")
            {
                switch(criterio)
                {
                    case "Comineza con":
                        consulta += "Nombre like '" + filtro + "%' ";
                        break;

                    case "Contiene":
                        consulta += "Nombre like '%" + filtro + "%' ";
                        break;

                    case "Termina con":
                        consulta += "Nombre like '%" + filtro + "'";
                        break;
                }
            }
            else
            {
                switch(criterio)
                {
                    case "Comineza":
                        consulta += "A.Descripcion like '" + filtro + "%'";
                        break;

                    case "Contiene":
                        consulta += "A.Descripcion like '%" + filtro + "%'";
                        break;

                    case "Termina":
                        consulta += "A.Descripcion like '%" + filtro + "'";
                        break;

                }
            }

            try
            {
                datos.setearConsulta(consulta);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();

                    aux.Id = int.Parse(datos.Lector["Id"].ToString());
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.UrlImagen = (string)datos.Lector["ImagenUrl"];
                    aux.Marca = new Tipo();
                    aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                    aux.Categoria = new Tipo();
                    aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];

                    listaFiltrada.Add(aux);
                }

                return listaFiltrada;

            }
            catch (Exception ex)
            {

                throw ex;
            }
           


            
        }

        public void eliminar(int id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("delete From ARTICULOS where id = @id");
                datos.setearParametro("@id", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }




    }

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

                if (datos.Lector.Read())
                {
                    Favoritos aux = new Favoritos();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.IdArticulo = (int)datos.Lector["IdArticulo"];
                    aux.IdUser = (int)datos.Lector["IdUser"];
                    lista.Add(aux);
                }
                return lista;

            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        public List<Favoritos> listar2()
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
                    if(!(datos.Lector["Id"] is DBNull))
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
