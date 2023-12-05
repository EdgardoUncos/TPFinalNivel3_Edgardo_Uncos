<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default3.aspx.cs" Inherits="presentacion.Default3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style>
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

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


     <%--Filtrar Por marca Categoria y Precio--%>
    <div class="row mt-3">

        <div class="col-12 col-sm-4 col-lg-3 pe-3">

            <h5>Filtros</h5>
            <hr />

            <div class="mb-3">
                <label class="form-label" for="ddlMarca">Marca</label>
                <asp:DropDownList runat="server" ID="ddlMarca" AppendDataBoundItems="true" CssClass="form-control">
                    <asp:ListItem Value="Filtrar Marca"></asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="mb-3">
                <label class="form-label" for="ddlCategoria">Categoria</label>
                <asp:DropDownList runat="server" ID="ddlCategoria" AppendDataBoundItems="true" CssClass="form-control">
                    <asp:ListItem Value="Filtrar Categoria"></asp:ListItem>
                </asp:DropDownList>
            </div>
            <div>
                <hr />
            </div>


            <h5>Precio</h5>
            <div class="row gx-1">
                
                <div class="col-6">
                    <label class="mb-1">Minimo</label>
                    <asp:TextBox runat="server" ID="txtMinimo" CssClass="form-control mb-2" />
                    <asp:Button Text="Filtrar" runat="server" ID="btnFiltrar" OnClick="btnFiltrar_Click" CssClass="btn btn-primary" />
                </div>
                <div class="col-6">
                    <label class="mb-1">Máximo</label>
                    <asp:TextBox runat="server" ID="txtMaximo" CssClass="form-control mb-2" />
                    <asp:Button Text="Reiciciar" runat="server" ID="btnReiniciar" OnClick="btnReiniciar_Click" CssClass="btn btn-light" />
                </div>
               
            </div>


        </div>

       


        <%-- ----Seccion Listado de Articulos -------------------------------------%>    

        <div class="col-12 col-sm-8 col-lg-9">
            <div class="row row-cols-1 row-cols-md-3 g-4 mb-5">
                <%ListaArticulos = (List<dominio.Articulo>)Session["ListaArticulos"]; %>
                <asp:Repeater ID="repRepedidor" runat="server">
                    <ItemTemplate>

                        <div class="col">
                            <div class="card text-center">
                                <div style="height:60%;">
                                    <img src="<%#Eval("UrlImagen") %>" class="card-img-top rounded-start" onerror="this.src='Images/placeholder.jpg'" style="max-width: 300px; max-height: 250px; margin: auto; object-fit: contain;" alt="..." />
                                </div>

                                <div class="card-body">
                                    <h5 class="card-title"><%#Eval("Nombre")%></h5>
                                    <p class="card-text"><%#Eval("Descripcion") %></p>
                                    <a href="LosFavotitos.aspx?IdProducto=<%#Eval("Id") %>" class="btn btn-danger">🤍</a>
                                    <%--<asp:Button Text="Agregar a Favoritos" CssClass="btn btn-danger" ID="btnFavoritos" runat="server" CommandName="Id" CommandArgument='<%#Eval("Id") %>' OnClick="btnFavoritos_Click" />--%>
                                    <a href="Detalle.aspx?IdProducto=<%#Eval("Id") %>" class="btn btn-light">Ver detalle</a>
                                    <p class="lead">$ <%#Eval("Precio", "{0:F2}") %></p>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>

                




            </div>
        </div>


    </div>

</asp:Content>
