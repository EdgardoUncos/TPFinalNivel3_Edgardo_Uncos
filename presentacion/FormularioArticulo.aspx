<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="FormularioArticulo.aspx.cs" Inherits="presentacion.FormularioArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <label class="form-label">Id</label>
                <asp:TextBox ID="txtId" runat="server" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label class="form-label">Codigo</label>
                <asp:TextBox runat="server" ID="txtCodigo" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label class="form-label">Nombre</label>
                <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" />
            </div>

            <div class="mb-3">
                <label class="form-label">Marca</label>
                <asp:DropDownList runat="server" ID="ddlMarca" CssClass="form-select">
                </asp:DropDownList>
            </div>
            <div class="mb-3">
                <label class="form-label">Categoria</label>
                <asp:DropDownList runat="server" ID="ddlCategoria" CssClass="form-select">
                </asp:DropDownList>
            </div>
            <div class="mb-3">
                <asp:Button Text="Aceptar" ID="btnAceptar" CssClass="btn btn-primary" OnClick="btnAceptar_Click" runat="server" />
                <a class="btn btn-primary">Cancelar</a>
            </div>

            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="mb-3">
                        <asp:Button Text="Eliminar" ID="bntEliminar" OnClick="bntEliminar_Click" CssClass="btn btn-danger" runat="server" />
                    </div>

                    <%if (ConfirmaEliminacion)
                        { %>
                    <div>
                        <asp:CheckBox Text="Confirma Eliminacion" ID="chkConfirmaEliminacion" AutoPostBack="true" OnCheckedChanged="chkConfirmaEliminacion_CheckedChanged" runat="server" />
                        <asp:Button Text="Eliminar" ID="btnConfirmaEliminacion" OnClick="btnConfirmaEliminacion_Click" CssClass="btn btn-outline-danger" runat="server" />
                    </div>
                    <%} %>
                </ContentTemplate>
            </asp:UpdatePanel>


        </div>

        <div class="col-6">
            <div class="mb-3">
                <label class="form-label">Descripcion</label>
                <asp:TextBox runat="server" ID="txtDescripcion" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label class="form-label">Precio</label>
                <asp:TextBox runat="server" ID="txtPrecio" CssClass="form-control" />
            </div>

            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="mb-3">
                        <label for="txtImagenUrl" class="form-label">Url Imagen</label>
                        <asp:TextBox runat="server" ID="txtImagenUrl" AutoPostBack="true" OnTextChanged="txtImagenUrl_TextChanged" CssClass="form-control" />
                    </div>
                    <div style="max-height:300px;">
                        <asp:Image ImageUrl="https://grupoact.com.ar/wp-content/uploads/2020/04/placeholder.png" ID="imgArticulo" runat="server" />
                    </div>

                </ContentTemplate>
            </asp:UpdatePanel>

        </div>


    </div>
</asp:Content>
