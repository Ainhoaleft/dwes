﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Cabecera.ascx.cs" Inherits="GesPresta.Cabecera" %>

    <div class="container">
        <div class="tabla">
            <div class="fila">
                <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/Default.aspx" CausesValidation="False">Inicio</asp:LinkButton>&nbsp;
                <asp:LinkButton ID="LinkButton2" runat="server" PostBackUrl="~/Empleados.aspx" CausesValidation="False">Empleados</asp:LinkButton>&nbsp;
                <asp:LinkButton ID="LinkButton3" runat="server" PostBackUrl="~/Prestaciones1.aspx" CausesValidation="False">Prestaciones</asp:LinkButton>
            </div>
            <div class="fila">
                <div class="titulo">ACME INNOVACIÓN, S.FIG.</div>
            </div>
            <div class="fila">
                <div class="subtitulo">Gestión de prestaciones Sodales</div>
            </div>
        </div>
    </div>



