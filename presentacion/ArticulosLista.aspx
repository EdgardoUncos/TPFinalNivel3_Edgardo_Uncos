<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ArticulosLista.aspx.cs" Inherits="presentacion.ArticulosLista" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Lista de Articulos</h1>
    <asp:gridview runat="server" ID="dgvArticulosLista" CssClass="table table-dark" AutoGenerateColumns="false" 
        OnSelectedIndexChanged="dgvArticulosLista_SelectedIndexChanged" DataKeyNames="Id" AllowPaging="true" PageSize="5" OnPageIndexChanging="dgvArticulosLista_PageIndexChanging" >
        <Columns>
            <asp:BoundField HeaderText="Codigo" DataField="Codigo" />
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
            <asp:BoundField HeaderText="Marca" DataField="Marca.Descripcion" />
            <asp:BoundField HeaderText="Categoria" DataField="Categoria.Descripcion" />
            <asp:BoundField HeaderText="Precio" DataField="Precio" />
            <asp:CommandField ShowSelectButton="true" HeaderText="Accion" SelectText="Modificar" />
        </Columns>
    </asp:gridview>
    <div class="mt-3">
        <a class="btn btn-primary" href="FormularioArticulo.aspx">Agregar</a>
    </div>

</asp:Content>
