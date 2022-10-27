<%@ OutputCache Duration="1" VaryByParam="None" %><%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registrarse.aspx.cs" Inherits="GesTienda.Registrarse" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align: center">
            <h1>GesTienda</h1>
            <h3>Registro de usuario</h3>
            <div>
                <asp:Label ID="strCorCli" runat="server" Text="Correo electronico"></asp:Label>
                <asp:TextBox ID="txtCorCli" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="strPassword" runat="server" Text="Contraseña"></asp:Label>
                <asp:TextBox ID="txtPassword1" runat="server" TextMode="Password"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="Label3" runat="server" Text="Introduzca nuevamente la Contraseña"></asp:Label>
                <asp:TextBox ID="txtPassword2" runat="server" TextMode="Password"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="strIdCliente" runat="server" Text="NIF/NIE/CIF"></asp:Label>
                <asp:TextBox ID="txtIdCliente" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="strNomCli" runat="server" Text="Nombre/Razón social"></asp:Label>
                <asp:TextBox ID="txtNomCli" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="strDirCli" runat="server" Text="Dirección"></asp:Label>
                <asp:TextBox ID="txtDirCli" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="strPobCli" runat="server" Text="Población"></asp:Label>
                <asp:TextBox ID="txtPobCli" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="strCpoCli" runat="server" Text="Código Postal"></asp:Label>
                <asp:TextBox ID="txtCpoCli" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="strTelCli" runat="server" Text="Telefono"></asp:Label>
                <asp:TextBox ID="txtTelCli" runat="server"></asp:TextBox>
            </div>

            <div>
                <asp:Button ID="btnInsertar" runat="server" Text="Insertar" OnClick="btnInsertar_Click" />
            </div>
            <div>
                <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/Default.aspx">Ir al Inicio</asp:LinkButton>
                
            </div>
            <div><asp:Label ID="lblMensajes" runat="server"></asp:Label></div>

        </div>
    </form>
</body>
</html>
