<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Favoritos.aspx.cs" Inherits="presentacion.Favoritos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Mis Favoritos</h2>
    <div class="row">
        <div class="col-12">
            <asp:GridView ID="dgvFavoritos" AutoGenerateColumns="false" runat="server">
                <Columns>
                    <asp:BoundField HeaderText="Articulo" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
