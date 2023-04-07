<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="presentacion.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Hola!</h2>
    <p>Muesta de Articulos Listados</p>

    <div class="row row-cols-1 row-cols-md-4 g-4 mb-5">

        <%foreach (dominio.Articulo item in ListaArticulos)
            {%>
        <div class="col">
            <div class="card text-center">
                <img src="<%:item.UrlImagen %>" class="card-img-top rounded-start" onerror="this.src='Images/placeholder.jpg'" style="max-width: 300px; max-height: 300px; margin: auto; object-fit: contain;" alt="..." />
                <div class="card-body">
                    <h5 class="card-title"><%:item.Nombre %></h5>
                    <p class="card-text"><%:item.Descripcion %></p>
                    <a href="LosFavotitos.aspx?IdProducto=<%:item.Id %>" class="btn btn-danger">Agregar a Favoritos</a>
                    <a href="Detalle.aspx?IdProducto=<%:item.Id %>" class="btn btn-light" style="max-height: 300px;">Ver detalle</a>
                </div>
            </div>
        </div>
        <%} %>
    </div>
</asp:Content>
