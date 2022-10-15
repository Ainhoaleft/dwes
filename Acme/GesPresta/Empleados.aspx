<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Empleados.aspx.cs" Inherits="GesPresta.Empleados" %>

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
                <div class="filaForm">DATOS DE LOS EMPLEADOS</div>
                    <div class="casilla"> 
                        <div class="filaForm">Codigo Empleado</div>  
                             <div class="celda"> 
                                    <asp:TextBox ID="txtCodEmp" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rqdTxtCodEmp" runat="server" ControlToValidate="txtCodEmp" ErrorMessage="El Código es obligatorio" ForeColor="Red">*</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="regtxtCodEmp" runat="server" ControlToValidate="txtCodEmp" ErrorMessage="El formato de los datos a introducir debe ser una letra y 5 dígitos" ForeColor="Green" ValidationExpression="\w\d{5}">*</asp:RegularExpressionValidator>
                            </div>
                        </div>  
                   <div class="casilla"> 
                        <div class="filaForm">NIF</div>
                            <div class="celda"> 
                                <asp:TextBox ID="txtNifEmp" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rqdtxtNifEmp" runat="server" ControlToValidate="txtNifEmp" ErrorMessage="El NIF es obligatorio" ForeColor="Red">*</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="regtxtNifEmp" runat="server" ControlToValidate="txtNifEmp" ErrorMessage="El formato de los datos a introducir debe ser una letra y 8 dígitos, un guion y una letra." ForeColor="Green" ValidationExpression="\d{8}-\w">*</asp:RegularExpressionValidator>
                            </div>
                   </div>
                   <div class="casilla"> 
                        <div class="filaForm">Apellidos y Nombre</div>
                             <div class="celda">
                                 <asp:TextBox ID="txtNomEmp" runat="server"></asp:TextBox>
                                 <asp:RequiredFieldValidator ID="rqdtxtNomEmp" runat="server" ControlToValidate="txtNomEmp" ErrorMessage="El Nombre y apellidos es obligatorio" ForeColor="Red">*</asp:RequiredFieldValidator>
                            </div>
                   </div>
                 <div class="casilla"> 
                         <div class="filaForm">Direccion</div>
                            <div class="celda">
                                <asp:TextBox ID="txtDirEmp" runat="server"></asp:TextBox>
                            </div>
                    </div>
                    <div class="casilla"> 
                         <div class="filaForm">Ciudad</div>
                            <div class="celda">
                                <asp:TextBox ID="txtCiuEmp" runat="server"></asp:TextBox>
                            </div>
                    </div>
                    <div class="casilla"> 
                        <div class="filaForm">Telefonos</div>
                            <div class="celda">
                                <asp:TextBox ID="txtTelEmp" runat="server" ></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rqdtxtTelEmp" runat="server" ControlToValidate="txtTelEmp" ErrorMessage="El telefono es obligatorio" ForeColor="Red">*</asp:RequiredFieldValidator>
                            </div>
                    </div>
                    <div class="casilla"> 
                        <div class="filaForm">Fecha de Nacimiento</div> 
                            <div class="celda">
                                <asp:TextBox ID="txtFnaEmp" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rqdtxtFnaEmp" runat="server" ControlToValidate="txtFnaEmp" ErrorMessage="La fecha de nacimiento es obligatorio" ForeColor="Red">*</asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="cmptxtFnaEmp" runat="server" ControlToCompare="txtFinEmp" ControlToValidate="txtFnaEmp" ErrorMessage="La Fecha de Ingreso del Empleado debe ser mayor que la Fecha de Nacimiento" ForeColor="Maroon" Operator="LessThan" Type="Date">*</asp:CompareValidator>
                                <asp:RegularExpressionValidator ID="regtxtFnaEmp" runat="server" ControlToValidate="txtFnaEmp" ErrorMessage="El formato de los datos a introducir debe ser una letra y Formato de fecha dd/mm/aaaa." ForeColor="Green" ValidationExpression="\d\d\/\d\d\/\d\d\d\d">*</asp:RegularExpressionValidator>
                            </div>
                    </div>
                    <div class="casilla"> 
                        <div class="filaForm">Fecha de Ingreso</div>
                            <div class="celda">
                                <asp:TextBox ID="txtFinEmp" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rqdtxtFinEmp" runat="server" ControlToValidate="txtFinEmp" ErrorMessage="La fecha de ingreso es obligatorio" ForeColor="Red">*</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="regtxtFinEmp" runat="server" ControlToValidate="txtFinEmp" ErrorMessage="El formato de los datos a introducir debe ser una letra y Formato de fecha dd/mm/aaaa" ForeColor="Green" ValidationExpression="\d\d\/\d\d\/\d\d\d\d">*</asp:RegularExpressionValidator>
                            </div>
                    </div>
                    <div class="casilla"> 
                        <div class="filaForm">Sexo</div>
                            <div class="celda">      
                                <asp:RadioButtonList ID="rblSexEmp" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Selected="True" Value="H">Hombre</asp:ListItem>
                                <asp:ListItem Value="M">Mujer</asp:ListItem>
                                </asp:RadioButtonList>  
                             </div>
                    </div>
                    <div class="casilla"> 
                        <div class="filaForm">Departamento</div>
                        <div class="celda"> 
                            <asp:DropDownList ID="ddlDepEmp" runat="server">
                            <asp:ListItem Selected="True">Investigacion</asp:ListItem>
                            <asp:ListItem>Desarrollo</asp:ListItem>
                            <asp:ListItem>Innovacion</asp:ListItem>
                            <asp:ListItem>Administracion</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                        <div class="filaForm">  
                            <asp:Button ID="cmdEnviar" runat="server" Text="Enviar" />  
                        </div>
                </div>
        <div class ="validar"> <asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="List" /></div>
       
    </form>
</body>
</html>
