<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Prestaciones2.aspx.cs" Inherits="GesPresta.Prestaciones2" %>

<%@ Register src="Cabecera.ascx" tagname="Cabecera" tagprefix="uc1" %>

<%@ Register src="prestacionesBuscar.ascx" tagname="prestacionesBuscar" tagprefix="uc2" %>

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
                         <div class="filaForm">
                             <asp:Button ID="btnVerPrestaciones" runat="server" CausesValidation="False" OnClick="btnVerPrestaciones_Click" Text="Ver prestaciones" />
                             Codigo Prestación</div>  
                            <div class="celda"> 
                                <asp:TextBox ID="txtCodPre" runat="server"></asp:TextBox> 
                                <asp:RequiredFieldValidator ID="rqdCodPre" runat="server" ControlToValidate="txtCodPre" ErrorMessage="El Código de prestacion es obligatorio" ForeColor="Red"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="regtxtCodPre" runat="server" ControlToValidate="txtCodPre" ErrorMessage="El formato de los datos a introducir debe ser 3 dígitos, un guión, 3 dígitos, un guion y, 3 dígitos" ForeColor="Green" ValidationExpression="\d{3}-\d{3}-\d{3}"></asp:RegularExpressionValidator>
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
                                 <asp:RequiredFieldValidator ID="rqdImpPre" runat="server" ControlToValidate="txtImpPre" ErrorMessage="El porcentaje  es obligatorio" ForeColor="Red"></asp:RequiredFieldValidator>
                                 <asp:RangeValidator ID="rngtxtImpPre" runat="server" ControlToValidate="txtImpPre" ErrorMessage="El valor introducido debe estar comprendido entre el 0,00 y el 500,00" ForeColor="#CC3300" MaximumValue="500,00" MinimumValue="0,00" Type="Double"></asp:RangeValidator>
                            </div>
                    </div>
                <div class="casilla"> 
                        <div class="filaForm">Porcentaje del Importe</div>
                             <div class="celda">
                                <asp:TextBox ID="txtPorPre" runat="server"></asp:TextBox>
                                 <asp:RequiredFieldValidator ID="rqdPorPre" runat="server" ControlToValidate="txtPorPre" ErrorMessage="El tipo  es obligatorio" ForeColor="Red"></asp:RequiredFieldValidator>
                                 <asp:RangeValidator ID="rngtxtPorPre" runat="server" ControlToValidate="txtPorPre" ErrorMessage="El valor introducido debe estar comprendido entre el 0,00 y el 15,00%" ForeColor="#CC3300" MaximumValue="15" MinimumValue="0" Type="Double"></asp:RangeValidator>
                            </div>
                    </div>
                    <div class="casilla"> 
                        <div class="filaForm">Tipo de Prestación</div>
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
                            <uc2:prestacionesBuscar ID="prestacionesBuscar1" runat="server" Visible="False" />
                            <asp:Button ID="btnSeleccionar" runat="server" CausesValidation="False" OnClick="btnSeleccionar_Click" Text="Seleccionar" Visible="False" />

                        </div>
             </div>
    </form>
</body>
</html>
