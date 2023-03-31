<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="MisFavoritos.aspx.cs" Inherits="presentacion.MisFavoritos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Mis Favoritos</h2>
    <div class="row">
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
        </div>

        <div class="col-12">
            <asp:GridView runat="server" ID="dgvFavoritos2" AutoGenerateColumns="false" CssClass="table table-dark"
                OnSelectedIndexChanged="dgvFavoritos2_SelectedIndexChanged" DataKeyNames="Id">
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
        </div>

    </div>
</asp:Content>
