<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default2.aspx.cs" Inherits="presentacion.Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        @import url('https://fonts.googleapis.com/css2?family=Poppins&display=swap');

        * {
           /* margin: 0;
            padding: 0;
            box-sizing: border-box;*/
            font-family: 'Poppins', sans-serif;
        }

        .wrapper {
            /*padding: 30px;*/
            /*max-width: 1200px;*/
            margin: auto;
        }

        .h3 {
            font-weight: 900;
        }

        

        .btn {
            color: #666;
            font-size: 0.85rem;
        }

        .btn:hover {
                color: #61b15a;
            }

        #sidebar {
            width: 25%;
            float: left;
        }



        

        #products {
            width: 75%;
            padding-left: 30px;
            margin: 0;
            float: right;
        }

        .card:hover {
            transform: scale(1.1);
            transition: all 0.5s ease-in-out;
            cursor: pointer;
        }

        .card-body {
            padding: 0.5rem;
        }

        .card-body .description {
                font-size: 0.78rem;
                padding-bottom: 8px;
            }

        div.h6, h6 {
            margin: 0;
        }

       
        .btn.btn-primary {
            background-color: #48b83e;
            color: #fff;
            border: 1px solid #008000;
            border-radius: 10px;
            font-weight: 800;
        }

            .btn.btn-primary:hover {
                background-color: #48b83ee8;
            }

        img {
            width: 192px;
            height: 132px;
            object-fit: contain;
        }

        
        .btn.btn-success {
            visibility: hidden;
        }

       
        

        @media(min-width:576px) and (max-width:767px) {
            #sidebar {
                width: 35%;
            }

            #products {
                width: 65%;
            }

           .h3 + .ml-auto {
                margin: 0;
            }
        }

        @media(max-width:575px) {
            .wrapper {
                padding: 10px;
            }

            .h3 {
                font-size: 1.3rem;
            }

            #sidebar {
                display: none;
            }

            #products {
                width: 100%;
                float: none;
            }

            #products {
                padding: 0;
            }

           .btn.btn-success {
                visibility: visible;
                margin: 10px 0px;
                color: #fff;
                padding: 0.2rem 0.1rem;
                width: 20%;
            }

            .green-label {
                width: 50%;
            }

            .btn.text-success {
                padding: 0;
            }

           
        }
    </style>

    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.9.1/font/bootstrap-icons.css">
    <link href="Css/style.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="wrapper">
        <div class="content py-md-0 py-3">
        <section id="sidebar">
            <div class="py-3">
                <h5 class="font-weight-bold">Marca</h5>
                <div class="brand">
                    

                    <div>
                        <asp:DropDownList runat="server" ID="ddlMarca" AppendDataBoundItems="true" CssClass="form-control">
                            <asp:ListItem Value="Filtrar Marca"></asp:ListItem>
                        </asp:DropDownList>
                    </div>

                    <h5 class="font-weight-bold">Categoría</h5>
                    <asp:DropDownList runat="server" ID="ddlCategoria" AppendDataBoundItems="true" CssClass="form-control">
                        <asp:ListItem Value="Filtrar Categoria"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>

            <div class="d-flex justify-content-evenly align-items-center">
                <label class="form-label">Minimo</label>
                <label class="form-label">Máximo</label>
            </div>

            <div class="d-flex justify-content-evenly align-content-center">
                <asp:TextBox runat="server" ID="txtMinimo" CssClass="form-control"></asp:TextBox>
                <asp:TextBox runat="server" ID="txtMaximo" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="d-flex justify-content-evenly align-items-center">
                <asp:Button Text="Filtrar" runat="server" ID="btnFiltrar" OnClick="btnFiltrar_Click" CssClass="btn btn-light" />
                <asp:Button Text="Reiniciar" runat="server" ID="btnReiniciar" OnClick="btnReiniciar_Click" CssClass="btn btn-light" />
            </div>



        </section>
        <!-- Products Section -->
        <section id="products">
            <div class="container py-3">
                <div class="row">
                    <asp:Repeater ID="repRepetidor" runat="server">

                        <ItemTemplate>
                            <div class="col-lg-4 col-md-6 col-sm-10 offset-md-0 offset-sm-1 pt-lg-4 pt-4">
                                <div class="card">
                                    <img class="card-img-top" src="<%#Eval("UrlImagen") %>" onerror="this.src='https://www.mansor.com.uy/wp-content/uploads/2020/06/imagen-no-disponible2.jpg'">
                                    <div class="card-body">
                                        <h6 class="font-weight-bold pt-1"><%#Eval("Nombre") %></h6>
                                        <div class="text-muted description"><%#Eval("Descripcion") %></div>
                                        <div class="d-flex align-items-center product"><span class="fas fa-star"></span><span class="fas fa-star"></span><span class="fas fa-star"></span><span class="fas fa-star"></span><span class="far fa-star"></span></div>
                                        <div class="d-flex align-items-center justify-content-between pt-3">
                                            <div class="d-flex flex-column">
                                                <div class="h6 font-weight-bold"><%#Eval("Precio", "{0:F2}") %> USD</div>
                                                
                                            </div>
                                            <a class="btn btn-primary" href="LosFavotitos.aspx?IdProducto=<%#Eval("Id") %>">Fav</a>
                                            <div class="d-flex justify-content-center align-content-center">
                                                <a class="btn btn-light" href="Detalle.aspx?IdProducto=<%#Eval("Id") %>">Detalle</a>
                                            </div>
                                    </div>
                                </div>
                            </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>


                </div>


            </div>
        </section>
    </div>

    </div>        

</asp:Content>
