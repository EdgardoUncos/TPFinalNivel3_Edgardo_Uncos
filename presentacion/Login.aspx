<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="presentacion.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        function validar() {
            const txtEmail = document.getElementById("txtEmail");
            const txtPassWord = document.getElementById("txtPassWord");
            let errorNombre = document.getElementById('nameError')
            let bEmail = true, bPassword= true;

            //Validadr correo electronico
            
            let emailPattern = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
            if (!emailPattern.test(txtEmail.value)) {
                txtEmail.classList.add("is-invalid");
                errorNombre.textContent = 'Por favor, introduci un email valido';
                txtEmail.classList.remove("is-invalid");
                bEmail = false;
            }
            else {
                errorNombre.textContent = ''
                bEmail = true;
            }

            //Validar la contraseña
            let contrasenaError = document.getElementById('passwordError')
            
            if (txtPassWord.value == "") {
                txtPassWord.classList.add("is-invalid");
                contrasenaError.textContent = 'Por favor, introduci una contraseña'
                bPassword = false;
            }
            else {
                txtPassWord.classList.remove("is-invalid")
                contrasenaError.textContent = ''
                bPassword = true;
            }

            if (bEmail && bPassword)
                return true;
            else
                return false;
            
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row justify-content-center align-content-center mt-5" style="width: 100%;">
        
        <%--Formulario de contacto--%>
        <div class="col-12 col-md-8 col-xl-6 mb-5" style="width: 25rem;">
            <div class="border border-secondary rounded rounded-5 text-secondary shadow p-4 mt-3">
                <div class="d-flex justify-content-center mt-2">
                    <img src="/Images/login-icon.svg" alt="Login Icon" style="height: 5rem;" />
                </div>
                <h2 class="display-3 mt-2 text-center fw-semibold">Login</h2>
                <div class="mb-3">
                    <label class="form-label">Email</label>
                    <asp:TextBox ClientIDMode="Static" runat="server" ID="txtEmail" CssClass="form-control" />
                    <div class="error-message" id="nameError" style="color:red; font-size:12px; margin-top:5px;"></div>
                </div>
                <div class="mb-3">
                    <label class="form-label">Password</label>
                    <asp:TextBox runat="server" ClientIDMode="Static" ID="txtPassWord" CssClass="form-control" TextMode="Password" />
                    <div class="error-message" id="passwordError" style="color:red; font-size:12px; margin-top:5px;"></div>
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

        
    </div>
</asp:Content>
