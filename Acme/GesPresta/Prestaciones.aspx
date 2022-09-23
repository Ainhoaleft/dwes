<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Prestaciones.aspx.cs" Inherits="GesPresta.Prestaciones" %>

<%@ Register src="Cabecera.ascx" tagname="Cabecera" tagprefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
   <link href="HojaEstilos.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <uc1:Cabecera ID="Cabecera1" runat="server" />
        </div> 
           <div class="tablaForm">
               <div class="filaForm">DATOS DE LAS PRESTACIONES</div>
                    <div class="casilla"> 
                         <div class="filaForm">Codigo Prestación</div>  
                            <div class="celda"> 
                                <asp:TextBox ID="txtCodPre" runat="server"></asp:TextBox> 
                            </div>
                    </div>    
                    <div class="casilla"> 
                        <div class="filaForm">Descripcion</div>
                            <div class="celda">
                                <asp:TextBox ID="txtDesPre" runat="server"></asp:TextBox>
                            </div>
                    </div>
                    <div class="casilla"> 
                        <div class="filaForm">Importe Fijo</div>
                             <div class="celda">
                                <asp:TextBox ID="txtImpPre" runat="server"></asp:TextBox>
                            </div>
                    </div>
                    <div class="casilla"> 
                        <div class="filaForm">Porcentaje del Importe</div>
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
    </form>
</body>
</html>
