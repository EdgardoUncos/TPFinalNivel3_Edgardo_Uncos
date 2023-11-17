<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="MisFavoritos.aspx.cs" Inherits="presentacion.MisFavoritos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 class="text-center display-4 mb-3">Mis Favoritos</h2>
    <div class="text-center mb-3">
        <asp:Label Text="" ID="lblMensaje" runat="server" CssClass="text-center mt-2 mt-3" />
    </div>

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

</asp:Content>

   

    
