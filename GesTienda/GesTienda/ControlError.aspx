<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ControlError.aspx.cs" Inherits="GesTienda.ControlError" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        <div class="titulo">
            <h1>Aplicacion Web GesTienda</h1>
        </div>
        <div class="subtitulo">
            <h2>Error en tiempo de ejecución</h2>
        </div>
        <div class="errores">
            <p>Error ASP.NET</p> 
            <asp:Label ID="lblErrorASP" runat="server" Text="lblErrorASP" ForeColor="Red"></asp:Label>
        </div>
       
        <div class="errores">
            <p>Error en ADO.NET</p>
            <asp:Label ID="lblErrorADO" runat="server" Text="lblErrorADO" ForeColor="Red"></asp:Label>
        </div>
      </div>
    </form>
</body>
</html>
