<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Empleados1.aspx.cs" Inherits="GesPresta.Empleados1" %>

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
                            </div>
                        </div>  
                   <div class="casilla"> 
                        <div class="filaForm">NIF</div>
                            <div class="celda"> 
                                <asp:TextBox ID="txtNifEmp" runat="server"></asp:TextBox>
                            </div>
                   </div>
                   <div class="casilla"> 
                        <div class="filaForm">Apellidos y Nombre</div>
                             <div class="celda">
                                <asp:TextBox ID="txtNomEmp" runat="server"></asp:TextBox>
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
                                <asp:TextBox ID="txtTelEmp" runat="server"></asp:TextBox>
                            </div>
                    </div>
                    <div class="casilla"> 
                        <div class="filaForm">Fecha de Nacimiento</div> 
                            <div class="celda">
                                <asp:TextBox ID="txtFnaEmp" runat="server"></asp:TextBox>
                            </div>
                    </div>
                    <div class="casilla"> 
                        <div class="filaForm">Fecha de Ingreso</div>
                            <div class="celda">
                                <asp:TextBox ID="txtFinEmp" runat="server"></asp:TextBox>
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
                            <asp:Button ID="cmdEnviar" runat="server" Text="Enviar" OnClick="cmdEnviar_Click" />  
                        </div>
                </div>
                        <div class="container">
                            <asp:Label ID="lblValores" runat="server" BackColor="#66FFFF" Text="" Visible="False" Width="60%"></asp:Label>
                        </div>
    </form>
</body>
</html>
