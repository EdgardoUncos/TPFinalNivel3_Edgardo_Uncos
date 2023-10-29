<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="presentacion.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        function validar() {
            const txtEmail = document.getElementById("txtEmail");
            if (txtEmail.value == "") {
                txtEmail.classList.add("is-invalid");
                
                return false;
            }
            txtEmail.classList.remove("is-invalid");
            txtEmail.classList.add("is-valid");
            return true;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row" style="width: 80%;">
        <div class="col-2"></div>
        <div class="col">
            <div class="border border-dark rounded rounded-3 p-4 mt-3">
                <h2 class="display-4 mt-5 text-center">Login</h2>
                <div class="mb-3">
                    <label class="form-label">Email</label>
                    <asp:TextBox ClientIDMode="Static" runat="server" ID="txtEmail" CssClass="form-control" />
                </div>
                <div class="mb-3">
                    <label class="form-label">Password</label>
                    <asp:TextBox runat="server" ID="txtPassWord" CssClass="form-control" />
                </div>
                <div class="mb-3 d-flex justify-content-center align-items-center">
                    <asp:Button Text="Ingresar" ID="btnLogin" CssClass="btn btn-primary" runat="server" OnClick="btnLogin_Click" OnClientClick="return validar()" />
                </div>
            </div>

            <div class="text-center m-3">
                <p class="form-label">No tenes cuenta</p>
                <a class="btn btn-outline-primary" href="Registro.aspx">Registrate</a>
            </div>
        </div>
        <div class="col-2"></div>




    </div>
</asp:Content>
