<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Prestaciones1Respuesta.aspx.cs" Inherits="GesPresta.Prestaciones1Respuesta" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="HojaEstilos.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="cabeceraRes">
            VALORES RECIBIDOS DESDE EL FORMULARIO PRESTACIONES1.ASPX
        </div>

         <div class="tabla">
             <asp:Label ID="lblValores" runat="server" BackColor="#C0FFFF" Text="" Width="70%"></asp:Label>            
          </div>
    </form>
</body>
</html>
