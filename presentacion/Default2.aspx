<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default2.aspx.cs" Inherits="presentacion.Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        @import url('https://fonts.googleapis.com/css2?family=Poppins&display=swap');

        * {
            margin: 0;
            padding: 0;
            box-sizing: border-box;
            font-family: 'Poppins', sans-serif;
        }

        .wrapper {
            padding: 30px;
            max-width: 1200px;
            margin: auto;
        }

        .h3 {
            font-weight: 900;
        }

        .views {
            font-size: 0.85rem;
        }

        .btn {
            color: #666;
            font-size: 0.85rem;
        }

            .btn:hover {
                color: #61b15a;
            }

        

        .radio, .checkbox {
            padding: 6px 10px;
        }

        .border {
            border-radius: 12px;
        }

        .options {
            position: relative;
            padding-left: 25px;
        }

        .radio label,
        .checkbox label {
            display: block;
            font-size: 14px;
            cursor: pointer;
            margin: 0;
        }

        .options input {
            opacity: 0;
        }

        

        .options input:checked ~ .checkmark:after {
            display: block;
        }

        .options .checkmark:after {
            content: "";
            width: 9px;
            height: 9px;
            display: block;
            background: white;
            position: absolute;
            top: 52%;
            left: 51%;
            border-radius: 50%;
            transform: translate(-50%,-50%) scale(0);
            transition: 300ms ease-in-out 0s;
        }

        .options input[type="radio"]:checked ~ .checkmark {
            background: #61b15a;
            transition: 300ms ease-in-out 0s;
        }

            .options input[type="radio"]:checked ~ .checkmark:after {
                transform: translate(-50%,-50%) scale(1);
            }

        .count {
            font-size: 0.8rem;
        }

        label {
            cursor: pointer;
        }

        .tick {
            display: block;
            position: relative;
            padding-left: 23px;
            cursor: pointer;
            font-size: 0.8rem;
            margin: 0;
        }

            .tick input {
                position: absolute;
                opacity: 0;
                cursor: pointer;
                height: 0;
                width: 0;
            }

        .check {
            position: absolute;
            top: 1px;
            left: 0;
            height: 18px;
            width: 18px;
            background-color: #f8f8f8;
            border: 1px solid #ddd;
            border-radius: 3px;
        }

        .tick:hover input ~ .check {
            background-color: #f3f3f3;
        }

        .tick input:checked ~ .check {
            background-color: #61b15a;
        }

        .check:after {
            content: "";
            position: absolute;
            display: none;
        }

        .tick input:checked ~ .check:after {
            display: block;
            transform: rotate(45deg) scale(1);
        }

        .tick .check:after {
            left: 6px;
            top: 2px;
            width: 5px;
            height: 10px;
            border: solid white;
            border-width: 0 3px 3px 0;
            transform: rotate(45deg) scale(2);
        }

        #country {
            font-size: 0.8rem;
            border: none;
            border-left: 1px solid #ccc;
            padding: 0px 10px;
            outline: none;
            font-weight: 900;
        }

        .close {
            font-size: 1.2rem;
        }

        div.text-muted {
            font-size: 0.85rem;
        }

        #sidebar {
            width: 25%;
            float: left;
        }

        .category {
            font-size: 0.9rem;
            cursor: pointer;
        }

        .list-group-item {
            border: none;
            padding: 0.3rem 0.4rem 0.3rem 0rem;
        }

        .badge-primary {
            background-color: #defadb;
            color: #48b83e
        }

        .brand .check {
            background-color: #fff;
            top: 3px;
            border: 1px solid #666;
        }

        .brand .tick {
            font-size: 1rem;
            padding-left: 25px;
        }

        .rating .check {
            background-color: #fff;
            border: 1px solid #666;
            top: 0;
        }

        .rating .tick {
            font-size: 0.9rem;
            padding-left: 25px;
        }

        .rating .fas.fa-star {
            color: #ffbb00;
            padding: 0px 3px;
        }

        .brand .tick:hover input ~ .check,
        .rating .tick:hover input ~ .check {
            background-color: #f9f9f9;
        }

        .brand .tick input:checked ~ .check,
        .rating .tick input:checked ~ .check {
            background-color: #61b15a;
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

        .product .fa-star {
            font-size: 0.9rem;
        }

        .rebate {
            font-size: 0.9rem;
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

        .clear {
            clear: both;
        }

        .btn.btn-success {
            visibility: hidden;
        }

        @media(min-width:992px) {
            .filter, #mobile-filter {
                display: none;
            }
        }

        @media(min-width:768px) and (max-width:991px) {
            .radio, .checkbox {
                padding: 6px 10px;
                width: 49%;
                float: left;
                margin: 5px 5px 5px 0px;
            }

            .filter, #mobile-filter {
                display: none;
            }
        }

        @media(min-width:576px) and (max-width:767px) {
            #sidebar {
                width: 35%;
            }

            #products {
                width: 65%;
            }

            .filter, #mobile-filter {
                display: none;
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

            .clear {
                float: left;
                width: 80%;
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

            .content, #mobile-filter {
                clear: both;
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
