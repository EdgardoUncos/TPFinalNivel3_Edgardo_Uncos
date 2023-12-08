<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="MiPerfil.aspx.cs" Inherits="presentacion.MiPerfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 class="text-center">Mi Perfil</h2>
    <div class="row">
        <div class="col"></div>
        <div class="col-12 col-md-4">
            <div class="mb-3">
                <label class="form-label">Email</label>
                <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label class="form-label">Nombre</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtNombre" />
            </div>
            <div class="mb-3">
                <label class="form-label">Apellido</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtApellido" />
            </div>
            <div class="mb-3">
                <label class="form-label">Fecha de Nacimiento</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtFechaNacimiento" TextMode="Date" />
            </div>
        </div>
        <div class="col-12 col-md-4">
            <div class="mb-3">
                <label class="form-label">Imagen de Perfil</label>
                <input type="file" class="form-control" runat="server" id="txtImagen" />    
            </div>
            <asp:Image ID="imgNuevoPerfil" ImageUrl="https://www.palomacornejo.com/wp-content/uploads/2021/08/no-image.jpg" runat="server" Height="250px" CssClass="img-fluid mb-3" />
        </div>
        <div class="col"></div>

        <div class="row mt-3">
            
            <div class="col-12 d-flex justify-content-center">
                <asp:Button Text="Guardar" ID="btnGuardar" CssClass="btn btn-primary m-3" OnClick="btnGuardar_Click" runat="server" />
                <a href="/" class="btn btn-secondary m-3">Regresar</a>
            </div>
            
        </div>
    </div>
</asp:Content>
