<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="presentacion.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <%--Estilos css--%>
    <style type="text/css">
        /* Coloca tus reglas de estilo personalizado aquí */
        @import url('https://fonts.googleapis.com/css2?family=Poppins&display=swap');

        * {
            font-family: 'Poppins', sans-serif;
        }

        .card:hover {
            transform: scale(1.1);
            transition: all 0.5s ease-in-out;
            cursor: pointer;
        }

        .btn:hover {
            box-shadow: black;
            transform: scale(1.1);
            transition: all 0.5s ease-in-out;
            cursor: pointer;
        }

        img {
            width: 192px;
            height: 132px;
            object-fit: contain;
        }
    </style>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.9.1/font/bootstrap-icons.css">
    <link href="Css/style.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    
    <%
        var activarBotonAnterior = PaginacionRespuesta.Pagina > 1;
        var activarBotonSiguente = PaginacionRespuesta.Pagina < PaginacionRespuesta.CantidadTotalPaginas;
    %>

    <%--Filtrar Por marca Categoria y Precio--%>
    <div class="row mt-3">

        <div class="col-12 col-sm-4 col-lg-3 pe-3 mb-1 mb-sm-0">

            <h5>Filtros</h5>
            <hr />

            <div class="mb-3">
                <label class="form-label" for="ddlMarca">Marca</label>
                <asp:DropDownList runat="server" ID="ddlMarca" AppendDataBoundItems="true" CssClass="form-control">
                    <asp:ListItem Value=""></asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="mb-3">
                <label class="form-label" for="ddlCategoria">Categoria</label>
                <asp:DropDownList runat="server" ID="ddlCategoria" AppendDataBoundItems="true" CssClass="form-control">
                    <asp:ListItem Value=""></asp:ListItem>
                </asp:DropDownList>
            </div>
            <div>
                <hr />
            </div>


            <h5>Precio</h5>
            <div class="row gx-1">

                <div class="col-6">
                    <asp:TextBox runat="server" ID="txtMinimo" CssClass="form-control mb-2" placeholder="Minimo" />
                    <asp:Button Text="Filtrar" runat="server" ID="btnFiltrar" OnClick="btnFiltrar_Click" CssClass="btn btn-danger" />
                </div>
                <div class="col-6">
                    <asp:TextBox runat="server" ID="txtMaximo" CssClass="form-control mb-2" placeholder="Máximo" />
                    <asp:Button Text="Reiciciar" runat="server" ID="btnReiniciar" OnClick="btnReiniciar_Click" CssClass="btn btn-light" />
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


        <%-- ----Seccion Listado de Articulos -------------------------------------%>

        <div class="col-12 col-sm-8 col-lg-9">
            <div class="row row-cols-1 row-cols-md-3 g-4 mb-5">
                <%ListaArticulos = (List<dominio.Articulo>)Session["ListaArticulos"]; %>
                <asp:Repeater ID="repRepedidor" runat="server">
                    <ItemTemplate>

                        <div class="col">
                            <div class="card text-center">
                                <div style="height: 60%;">
                                    <img src="<%#Eval("UrlImagen") %>" class="card-img-top py-2 rounded-start" onerror="this.onerror=null; this.src='Images/placeholder.jpg'" alt="..." />
                                </div>

                                <div class="card-body">
                                    <h5 class="card-title"><%#Eval("Nombre")%></h5>
                                    <p class="card-text"><%#Eval("Descripcion") %></p>
                                    <a href="LosFavotitos.aspx?IdProducto=<%#Eval("Id") %>" class="btn btn-danger">🤍</a>
                                    <%--<asp:Button Text="Agregar a Favoritos" CssClass="btn btn-danger" ID="btnFavoritos" runat="server" CommandName="Id" CommandArgument='<%#Eval("Id") %>' OnClick="btnFavoritos_Click" />--%>
                                    <a href="Detalle.aspx?IdProducto=<%#Eval("Id") %>" class="btn btn-light">Ver detalle</a>
                                    <p class="lead"><%#Eval("Precio", "{0:F2}") %></p>
                                </div>

                            </div>
                        </div>
                    </ItemTemplate>

                </asp:Repeater>
            </div>

            <% if (PaginacionRespuesta.CantidadTotalRecords > 0)
                { %>
            <nav>
                <ul class="pagination">

                    <%--Boton Anterior--%>
                    <li class="page-item <%:(activarBotonAnterior ? null : "disabled") %>">
                        <%if (activarBotonAnterior)
                            {%>

                        <a class="page-link"
                            href="Default.aspx?pagina=<%:PaginacionRespuesta.Pagina - 1 %>&recordsPorPagina=<%:PaginacionRespuesta.RecordsPorPagina %>">Anterior
                        </a>

                        <%} %>
                        <%
                            else
                            {
                        %>
                        <span class="page-link">Anterior</span>
                        <% }%>

                    </li>

                    <%--Creamos n botones por n pagina--%>
                    <%for (int pagina = 1; pagina <= PaginacionRespuesta.CantidadTotalPaginas; pagina++)
                        {

                    %>
                    <li class="page-item <%:(pagina == PaginacionRespuesta.Pagina ? "active" : null) %>">

                        <a class="page-link" href="Default.aspx?pagina=<%:pagina %>&recordsPorPagina=<%:PaginacionRespuesta.RecordsPorPagina %>"><%:pagina %></a>
                    </li>

                    <%    } %>

                    <%--Boton Siguente--%>
                    <li class="page-item <%:(activarBotonSiguente ? null : "disabled") %>">
                        <%if (activarBotonSiguente)
                            { %>
                        <a class="page-link"
                            href="Default.aspx?pagina=<%:PaginacionRespuesta.Pagina + 1 %>&recordsPorPagina=<%:PaginacionRespuesta.RecordsPorPagina %>">Siguiente
                        </a>
                        <%} %>
                        <%
                            else
                            {
                        %>
                        <span class="page-link">Siguiente</span>
                        <% }%>
                    </li>
                </ul>
            </nav>

            <%} %>
        </div>

        <a class="h5 text-decoration-none text-color-danger" href="Default2.aspx">Segunda Version Listado</a>




    </div>

</asp:Content>
