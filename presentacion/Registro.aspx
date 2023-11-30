<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="presentacion.Registro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row justify-content-center">

        <div class="col-12 col-md-8 col-xl-6 mb-5">
            <div class="card p-4 mt-3">

                <h2 class="display-4 mt-5 text-center">Crea tu perfil</h2>
                <div class="d-flex justify-content-center align-items-center mt-2">
                    <asp:ValidationSummary runat="server" CssClass="text-danger" Font-Size="Small" />
                </div>

                <div class="mb-3">
                    <label class="form-label">Email</label>
                    <asp:TextBox runat="server" ID="txtEmail" ClientIDMode="Static" CssClass="form-control" />
                    <asp:RequiredFieldValidator ErrorMessage="Email Requerido" ControlToValidate="txtEmail" runat="server" Font-Size="Small" CssClass="text-danger" />
                </div>
                <div class="mb-3">
                    <label class="form-label">Password</label>
                    <asp:TextBox runat="server" ID="txtPassWord" ClientIDMode="Static" CssClass="form-control" />
                    <asp:RequiredFieldValidator ErrorMessage="Password Requerido" ControlToValidate="txtPassWord" runat="server" Font-Size="Small" CssClass="text-danger" />
                </div>
                <div class="mb-3 text-center mt-3">
                    <asp:Button Text="Registrarse" ID="btnRegistrarse" CssClass="btn btn-primary" OnClick="btnRegistrarse_Click" runat="server" />
                </div>

            </div>
        </div>
    </div>
</asp:Content>
