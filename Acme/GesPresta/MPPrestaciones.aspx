<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="MPPrestaciones.aspx.cs" Inherits="GesPresta.MPPrestaciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="tablaForm">
    <div class="filaForm">
        DATOS DE LAS PRESTACIONES</div>
    <div class="casilla">
        <div class="filaForm">
            Codigo Prestación</div>
        <div class="celda">
            <asp:TextBox ID="txtCodPre" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="casilla">
        <div class="filaForm">
            Descripcion</div>
        <div class="celda">
            <asp:TextBox ID="txtDesPre" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="casilla">
        <div class="filaForm">
            Importe Fijo</div>
        <div class="celda">
            <asp:TextBox ID="txtImpPre" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="casilla">
        <div class="filaForm">
            Porcentaje del Importe</div>
        <div class="celda">
            <asp:TextBox ID="txtPorPre" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="casilla">
        <div class="filaForm">
            Tipo de Prestación</div>
        <div class="celda">
            <asp:DropDownList ID="ddlTipPre" runat="server">
                <asp:ListItem Selected="True">Ocular</asp:ListItem>
                <asp:ListItem>Dentaria</asp:ListItem>
                <asp:ListItem>Familiar</asp:ListItem>
                <asp:ListItem>Otras</asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>
    <div class="filaForm">
        <asp:Button ID="cmdEnviar" runat="server" Text="Enviar" />
    </div>
</div>
</asp:Content>
