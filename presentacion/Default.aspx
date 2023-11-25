<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="presentacion.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <%--Estilos css--%> 
     <style type="text/css">
        /* Coloca tus reglas de estilo personalizado aquí */
         .card {
             min-height: 400px;
         } 
           
        .card-img-top{
            max-width: 250px; 
            max-height: 200px; 
            margin: auto; 
            object-fit: contain;
        }      
            

      </style>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.9.1/font/bootstrap-icons.css">
     <link href="Css/style.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
      

    <%--Filtrar Por marca Categoria y Precio--%>
    <div class="row mt-3">

        <div class="col-3">

            <h5>Filtros</h5>
            <hr />

            <div>
                <label class="form-label" for="ddlMarca">Marca</label>
                <asp:DropDownList runat="server" ID="ddlMarca" AppendDataBoundItems="true" Width="150px" CssClass="form-control">
                    <asp:ListItem Value="Filtrar Marca"></asp:ListItem>
                </asp:DropDownList>
            </div>
            <div>
                <label class="form-label" for="ddlCategoria">Categoria</label>
                <asp:DropDownList runat="server" ID="ddlCategoria" AppendDataBoundItems="true" Width="150px" CssClass="form-control">
                    <asp:ListItem Value="Filtrar Categoria"></asp:ListItem>
                </asp:DropDownList>
            </div>
            <div>
                <hr />
            </div>


            <h4>Precio</h4>
            <div class="row">
                <div class="col-12">
                    <asp:RadioButton ID="rbt1" runat="server" />
                    <label>Menos de 50</label>
                </div>
                <div class="col-12">
                    <asp:RadioButton ID="rbt2" runat="server" />
                    <label>$50 y $500</label>
                </div>
                <div class="col-12">
                    <asp:RadioButton ID="RadioButton4" runat="server" />
                    <label>$500 y $1000</label>
                </div>
                <div class="col-12">
                    <asp:RadioButton ID="rbt4" runat="server" />
                    <label>$1000 y mas</label>
                </div>
                <hr />
                <div class="col-6">
                    <label>Minimo</label>
                    <asp:TextBox runat="server" ID="txtMinimo" CssClass="form-control" Width="120px" />
                </div>
                <div class="col-6">
                    <label>Máximo</label>
                    <asp:TextBox runat="server" ID="txtMaximo" CssClass="form-control" Width="120px" />
                </div>
                <div class="col-12 d-flex justify-content-around mt-3">
                    <asp:Button Text="Filtrar" runat="server" ID="btnFiltrar" OnClick="btnFiltrar_Click" CssClass="btn btn-light" />
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

        <div class="col-9">
            <div class="row row-cols-1 row-cols-md-3 g-4 mb-5">
                <%ListaArticulos = (List<dominio.Articulo>)Session["ListaArticulos"]; %>
                <asp:Repeater ID="repRepedidor" runat="server">
                    <ItemTemplate>

                        <div class="col">
                            <div class="card text-center">
                                <div style="height:60%;">
                                    <img src="<%#Eval("UrlImagen") %>" class="card-img-top rounded-start" onerror="this.src='Images/placeholder.jpg'"  alt="..." />
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
        </div>






    </div>

</asp:Content>
