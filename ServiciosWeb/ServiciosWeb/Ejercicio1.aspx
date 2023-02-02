<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ejercicio1.aspx.cs" Inherits="ServiciosWeb.Ejercicio1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>CONSUMIR UN SERVICIO WEB YA EXISTENTE</h1>
            <h1>Titulaciones Oficiales en la Universidad de Alicante</h1>

            <p>Curso academico (formato aaaa-aa)<asp:TextBox ID="txtCurso" runat="server"></asp:TextBox>
                <asp:Button ID="btnObtenerInformacion" runat="server" Text="Obtener información" OnClick="btnObtenerInformacion_Click" />
            </p>
            <asp:Label ID="lblResultado" runat="server"></asp:Label>
            <asp:GridView ID="GridView1" runat="server">
            </asp:GridView>
        </div>
    </form>
</body>
</html>
