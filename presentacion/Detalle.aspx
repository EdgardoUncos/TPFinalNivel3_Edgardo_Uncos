<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="presentacion.Detalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-6">

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

                <div style="max-height: 300px;">
                    <asp:Image ImageUrl="https://grupoact.com.ar/wp-content/uploads/2020/04/placeholder.png" ID="imgArticulo" Height="300px" runat="server" />
                </div>
            </div>

    </div>
    <div class="row">
        <div class="col-12 text-center">
            <a href="Default.aspx" class="btn btn-secondary">Regresar</a>
        </div>

    </div>            
</asp:Content>
                    


        
