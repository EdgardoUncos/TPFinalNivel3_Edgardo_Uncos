<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ArticulosLista.aspx.cs" Inherits="presentacion.ArticulosLista" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Lista de Articulos</h1>

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-md-6">
                    <div class="mb-3">
                        <asp:Label Text="Filtrar" runat="server" CssClass="form-label" />
                        <asp:TextBox runat="server" ID="txtFiltro" CssClass="form-control" OnTextChanged="txtFiltro_TextChanged" AutoPostBack="true" />
                    </div>
                </div>
                <div class="col-md-6" style="display : flex; flex-direction: column; justify-content: flex-end;">
                    <div class="mb-3">
                        <asp:CheckBox Text="Filtro Avanzado" ID="chkFiltroAvanzado" OnCheckedChanged="chkFiltroAvanzado_CheckedChanged" AutoPostBack="true" runat="server" />
                    </div>
                </div>
            </div>

            <%if (FiltroAvanzado)
                { %>
            <div class="row">
                <div class="col-3">
                    <div class="mb-3">
                        <asp:Label Text="Campo" ID="lblCampo" runat="server" CssClass="form-label" />
                        <asp:DropDownList ID="ddlCampo" CssClass="form-control" runat="server" OnSelectedIndexChanged="ddlCampo_SelectedIndexChanged" AutoPostBack="true">
                            <asp:ListItem Text="Codigo" />
                            <asp:ListItem Text="Nombre" />
                            <asp:ListItem Text="Descripcion" />
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-3">
                    <div class="mb-3">
                        <asp:Label Text="Criterio" runat="server" ID="lblCriterio" CssClass="form-label" />
                        <asp:DropDownList runat="server" ID="ddlCriterio" CssClass="form-control">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-3">
                    <div class="mb-3">
                        <asp:Label Text="Filtro" runat="server" />
                        <asp:TextBox runat="server" ID="txtFiltroAvanzado" CssClass="form-control" />
                    </div>
                </div>

                <div class="col-3" style="display: flex; flex-direction: column; justify-content: flex-end;" >
                    <div class="mb-3">
                        <asp:Button Text="Buscar" ID="btnBuscar" CssClass="btn btn-primary" OnClick="btnBuscar_Click" runat="server" />
                    </div>
                </div>
            </div>
            <%} %>
            <div class="row">
                <div class="col-12">
                    <asp:GridView runat="server" ID="dgvArticulosLista" CssClass="table table-dark" AutoGenerateColumns="false"
                        OnSelectedIndexChanged="dgvArticulosLista_SelectedIndexChanged" DataKeyNames="Id" AllowPaging="true" PageSize="5" OnPageIndexChanging="dgvArticulosLista_PageIndexChanging">
                        <Columns>
                            <asp:BoundField HeaderText="Codigo" DataField="Codigo" />
                            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                            <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
                            <asp:BoundField HeaderText="Marca" DataField="Marca.Descripcion" />
                            <asp:BoundField HeaderText="Categoria" DataField="Categoria.Descripcion" />
                            <asp:BoundField HeaderText="Precio" DataField="Precio" />
                            <asp:CommandField ShowSelectButton="true" HeaderText="Accion" SelectText="Modificar" />
                        </Columns>
                    </asp:GridView>
                    <div class="mt-3">
                        <a class="btn btn-primary" href="FormularioArticulo.aspx">Agregar</a>
                    </div>
                </div>
            </div>
        </ContentTemplate>

    </asp:UpdatePanel>





</asp:Content>
