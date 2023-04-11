<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="presentacion.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Hola!</h2>
    <p>Muesta de Articulos Listados</p>

    <%--Filtrar Por marca Categoria y Precio--%>
    <div class="row">

        <div class="col-3 seccion-oscura">

            <h5>Filtros</h5>
            <div class="form-check">
                <input class="form-check-input" type="checkbox" value="" id="chkCheck" />
                <label class="form-check-label" for="chkCeck">Nombre</label>
            </div>
            <div class="form-check">
                <input class="form-check-input" type="checkbox" value="" id="checkbox" />
                <label class="form-check-label" for="checkbox">Categoria</label>
            </div>
            <div>
                <hr />
            </div>


            <h4>Precio</h4>
            <div class="row">
                <div class="col-6">
                    <label>Minimo</label>
                    <asp:TextBox runat="server" ID="txtMinimo" CssClass="form-control" />
                </div>
                <div class="col-6">
                    <label>Máximo</label>
                    <asp:TextBox runat="server" ID="txtMaximo" CssClass="form-control" />
                </div>
                <div class="col-12">
                    <asp:Button Text="Filtrar" runat="server" ID="btnFiltrar" OnClick="btnFiltrar_Click" />
                    <asp:Button Text="Reiciciar" runat="server" ID="btnReiniciar" OnClick="btnReiniciar_Click" />
                </div>
            </div>


        </div>

        <%--<div class="col-9">
            <div class="row row-cols-1 row-cols-md-4 g-4 mb-5">

                <%
                    ListaArticulos = (List<dominio.Articulo>)Session["ListaArticulos"];
                    foreach (dominio.Articulo item in ListaArticulos)
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
        </div>  --%>

        <div class="col-9">
            <div class="row row-cols-1 row-cols-md-4 g-4 mb-5">
                <%ListaArticulos = (List<dominio.Articulo>)Session["ListaArticulos"]; %>
                <asp:Repeater ID="repRepedidor" runat="server">
                    <ItemTemplate>

                        <div class="col">
                            <div class="card text-center">
                                <img src="<%#Eval("UrlImagen") %>" class="card-img-top rounded-start" onerror="this.src='Images/placeholder.jpg'" style="max-width: 300px; max-height: 300px; margin: auto; object-fit: contain;" alt="..." />
                                <div class="card-body">
                                    <h5 class="card-title"><%#Eval("Nombre")%></h5>
                                    <p class="card-text"><%#Eval("Descripcion") %></p>
                                    <a href="LosFavotitos.aspx?IdProducto=<%#Eval("Id") %>" class="btn btn-danger">Agregar a Favoritos</a>
                                    <%--<asp:Button Text="Agregar a Favoritos" CssClass="btn btn-danger" ID="btnFavoritos" runat="server" CommandName="Id" CommandArgument='<%#Eval("Id") %>' OnClick="btnFavoritos_Click" />--%>
                                    <a href="Detalle.aspx?IdProducto=<%#Eval("Id") %>" class="btn btn-light" style="max-height: 300px;">Ver detalle</a>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>


                </asp:Repeater>


            </div>
        </div>


    </div>

</asp:Content>
