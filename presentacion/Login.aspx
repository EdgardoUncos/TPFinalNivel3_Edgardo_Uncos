<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="presentacion.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-4">
            <h2>Login</h2>
            <div class="mb-3">
                <label class="form-label">Email</label>
                <asp:textbox runat="server" Id="txtEmail" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label class="form-label">Password</label>
                <asp:TextBox runat="server" ID="txtPassWord" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <asp:button text="Ingresar" ID="btnLogin" CssClass="btn btn-primary" runat="server" OnClick="btnLogin_Click" />
            </div>
        </div>
    </div>
</asp:Content>
