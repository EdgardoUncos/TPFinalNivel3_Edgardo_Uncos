<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="MisFavoritos.aspx.cs" Inherits="presentacion.MisFavoritos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 class="text-center display-4 mb-3">Mis Favoritos</h2>
    <div class="text-center mb-3">
        <asp:Label Text="" ID="lblMensaje" runat="server" CssClass="text-center mt-2 mt-3" />
    </div>


    <%--Grivview de prueba, levantaba todos los datos de toda la tabla Favoritos--%>
    <%--Objetivo Probar otras cosa de la grid como footer entre otras propiedades.--%>

    <%--<div class="row">
        <div class="col-12">
            <asp:GridView runat="server" ID="dgvFavoritos" AutoGenerateColumns="false" CssClass="table table-dark"
                OnSelectedIndexChanged="dgvFavoritos_SelectedIndexChanged" DataKeyNames="Id">
                <Columns>
                    <asp:BoundField HeaderText="Id" DataField="Id" />
                    <asp:BoundField HeaderText="Usuario" DataField="IdUser" />
                    <asp:BoundField HeaderText="Articulo" DataField="IdArticulo" />
                    <asp:CommandField HeaderText="Accion" SelectText="Eliminar" />
                </Columns>
            </asp:GridView>
        </div>--%>

    <%--Gridview Final para favoritos--%>

        <div class="col-12">
            <asp:GridView runat="server" ID="dgvFavoritos2" AutoGenerateColumns="false" CssClass="table table-dark"
                OnSelectedIndexChanged="dgvFavoritos2_SelectedIndexChanged" DataKeyNames="Id" ShowFooter="true">
                <Columns>
                    <asp:BoundField HeaderText="Codigo" DataField="Codigo" />
                    <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                    <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
                    <asp:BoundField HeaderText="Marca" DataField="Marca.Descripcion" />
                    <asp:BoundField HeaderText="Categoria" DataField="Categoria.Descripcion" />
                    <asp:BoundField HeaderText="Precio" DataField="Precio" ItemStyle-Width="60" DataFormatString="{0:N2}" ItemStyle-HorizontalAlign="Right" />
                    <asp:CommandField ShowSelectButton="true" HeaderText="Accion" SelectText="Eliminar" />
                </Columns>
            </asp:GridView>
            
        </div>

    <%--Objetivo del boton era actualizar la pantalla con idea de colocar un checkbox. Lo dejo porque no hace falta--%>
        
    <%--<asp:Button Text="Actualizar" ID="btnActualizar" OnClick="btnActualizar_Click" runat="server" />--%>

    <%--Gridview de prueva, objetivo probar otras cosar, sin romper el anterior--%>

        <%--<div class="col-12">
            <asp:GridView runat="server" ID="dgvFavoritos3" AutoGenerateColumns="false" CssClass="table table-dark"
                OnSelectedIndexChanged="dgvFavoritos3_SelectedIndexChanged" DataKeyNames="IdFavorito">
                <Columns>
                    <asp:BoundField HeaderText="Codigo" DataField="Codigo" />
                    <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                    <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
                    <asp:BoundField HeaderText="Marca" DataField="Marca.Descripcion" />
                    <asp:BoundField HeaderText="Categoria" DataField="Categoria.Descripcion" />
                    <asp:BoundField HeaderText="Precio" DataField="Precio" />
                    <asp:CommandField ShowSelectButton="true" HeaderText="Accion" SelectText="Eliminar" />
                </Columns>
            </asp:GridView>
        </div>--%>

    
</asp:Content>
