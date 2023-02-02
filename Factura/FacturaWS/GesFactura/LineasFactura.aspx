<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LineasFactura.aspx.cs" Inherits="GesFactura.LineasFactura" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div> 
            <div> <h1 style="margin-left: 300px">Uso de Servcio Web - Cálculos factura de un árticulo</h1></div>
            <div style="margin-left: 600px">

            <div> <asp:Label ID="lblCantidad" runat="server" Text="Cantidad"></asp:Label>
                <asp:TextBox ID="txtCantidad" runat="server"></asp:TextBox>
            </div>
            <div> <asp:Label ID="lblPrecio" runat="server" Text="Precio"></asp:Label>
                <asp:TextBox ID="txtPrecio" runat="server"></asp:TextBox>
            </div>
            <div> <asp:Label ID="lblDescuento1" runat="server" Text="Descuento (%)"> </asp:Label>
                <asp:TextBox ID="txtDescuento" runat="server"></asp:TextBox>
                 </div>
            <div> <asp:Label ID="lblTipoIVA" runat="server" Text="Tipo de IVA (%)"> </asp:Label>
                <asp:TextBox ID="txtTipoIVA" runat="server"></asp:TextBox>
                
            </div>

            <div style="margin-left: 150px"> <asp:Button ID="btnEnviar" runat="server" Text="Enviar" OnClick="btnEnviar_Click" /></div>
           </div>
          
            <div>
                <p style="margin-left: 600px">Resultados de los cálculos</p>
            </div>
            <div style="margin-left: 600px">            
                <div style="float: left">
                    &nbsp;
                    <asp:Label ID="lblBruto" runat="server" Text=""></asp:Label>
                </div>
                <div style="float: left">
                    <p>Descuento</p>
                    <asp:Label ID="lblDescuento" runat="server" Text=""></asp:Label>
                </div>
                <div style="float: left">
                    <p>Base imponible</p>
                    
                    <asp:Label ID="lblBaseImponible" runat="server" Text=""></asp:Label>
                </div>  
                <div style="float: left">
                    <p> IVA</p>
                    <asp:Label ID="lblIva" runat="server" Text=""></asp:Label> 
                </div>               
                <div style="float: left">
                    <p> Total</p>  
                    <asp:Label ID="lblTotal" runat="server" Text=""></asp:Label>
                </div>
            </div>
       
    </form>
</body>
</html>
