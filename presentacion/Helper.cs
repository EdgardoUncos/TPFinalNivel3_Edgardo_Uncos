using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using dominio;
using negocio;

namespace presentacion
{
    public static class Helper
    {
        public static List<Articulo>ListaFavUser(int idUser, List<Articulo>ListaArticulos, List<Favoritos>ListaFavoritos)
        {
            List<Articulo> ListaAP = new List<Articulo>();
            

            foreach (var item in ListaFavoritos)
            {
                if (idUser == item.IdUser)
                    ListaAP.Add(ListaArticulos.Find(x => x.Id == item.IdArticulo));
            }

            return ListaAP;
                                    
        }


        //public static List<ArticuloFavorito> ListarAF(int idUser, List<Articulo> ListaArticulos, List<Favoritos> ListaFavoritos)
        //{
        //    List<ArticuloFavorito> ListaAF = new List<ArticuloFavorito>();


        //    foreach (var item in ListaFavoritos)
        //    {
        //        if (idUser == item.IdUser)
        //            ListaAF.Add(ListaArticulos.Find(x => x.Id == item.IdArticulo));
        //    }

        //    return ListaAP;

        //}
    }
}