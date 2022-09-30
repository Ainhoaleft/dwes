using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GesPresta
{
    public partial class EmpleadosCalendar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtCodEmp.Focus(); // Sitúa el foco en el elemento Código Empleado
        }

        protected void cmdEnviar_Click(object sender, EventArgs e)
        {
            DateTime dtHoy = System.DateTime.Now;
            string nacCalendar = Nacimiento.SelectedDate.ToShortDateString();
            string ingCalendar = Ingreso.SelectedDate.ToShortDateString();

            if (ValidarFecha(nacCalendar, ingCalendar))
            {
                //string fecha_nac = CalendarNacEmp.SelectedDate.ToShortDateString();
                lblValores.Visible = true;
                lblValores.Text = "VALORES DEL FORMULARIO" +
                "<br/> Código Empleado: " + txtCodEmp.Text +
                "<br/> NIF: " + txtNifEmp.Text +
                "<br/> Apellidos y Nombre: " + txtNomEmp.Text +
                "<br/> Dirección: " + txtDirEmp.Text +
                "<br/> Ciudad: " + txtCiuEmp.Text +
                "<br/> Teléfonos: " + txtTelEmp.Text +
                "<br/> Fecha de Nacimiento: " + txtFnaEmp.Text +
                "<br/> Fecha de Incorporación: " + txtFinEmp.Text +
                "<br/> Sexo: " + rblSexEmp.SelectedItem.Value +
                "<br/> Departamento: " + ddlDepEmp.Text +
                "<br/> Antiguedad " +
                "<br/> Años " + txtAños.Text +
                "<br/> Meses " + txtMeses.Text +
                "<br/> Dias " + txtDias.Text;
            }
        } 
       /* public static Boolean bisiesto(int ano) {
            Boolean bisiesto = false;
            if ((ano % 4 == 0 && ano % 100 != 0) || (ano % 100 == 0 && ano % 400 == 0))
            {
                bisiesto = true;
            }
            return bisiesto;
        }
        public static Boolean boldia(int dia, int mes, int ano)
        {
            Boolean boldia = false;
            if ((mes == 1 && mes == 3 && mes == 5 || mes == 7 && mes == 8 && mes == 10 && mes == 12) && dia <= 31)
            {
                boldia = true;
                Console.WriteLine("Month introduced is incorrect: it isn´t between 1 and 12");
            }
            else if ((mes == 4 && mes == 6 || mes == 9 && mes == 11) && dia <= 30)
            {
                boldia = true;
                Console.WriteLine("Month introduced is incorrect: it isn´t between 1 and 12");
            }
            if (mes == 2)
            {
                if (bisiesto(ano))
                {
                    if (dia > 29)
                        boldia = false;
                }
                else
                {
                    if (dia > 28)
                        boldia = false;
                }
            }
            else
            {
                Console.WriteLine("You have introduces a VALID date! " + dia + "/" + mes
                        + "/" + ano);
            }
            return boldia;
        }*/
        public bool ValidarFecha(string nacCalendar, string ingCalendar)
        {
            bool fechaing1_valida, fechaing2_valida, fechas_valida = false;

            DateTime dtHoy = System.DateTime.Now;
            DateTime fecha_ing = Convert.ToDateTime(ingCalendar).Date;
            DateTime fecha_nac = Convert.ToDateTime(nacCalendar).Date;

            if (fecha_ing < fecha_nac)
            {
                lblError1.Visible = true;
                lblError1.Text = "Introduce la fecha de nacimiento valida";
                fechaing1_valida = false;
            }
            else 
            {
                lblError1.Visible = false;
                fechaing1_valida = true;
            }
            if (fecha_ing > dtHoy)
            {
                lblError2.Visible = true;
                lblError2.Text = "Introduce la fecha de ingreso valida";
                fechaing2_valida = false;
            }
            else
            {
                lblError2.Visible = false;
                fechaing2_valida = true;
            }
            if (fecha_nac > dtHoy)
            {
                lblError3.Visible = true;
                lblError3.Text = "Introduce la fecha valida";
                fechas_valida = false;
            }
            else 
            {
                lblError3.Visible = false;
                fechas_valida = true;
            }
            if (fechaing1_valida && fechaing2_valida && fechas_valida)
            {
                return true;
            } 
            else return false;   
        }
        protected void Ingreso_SelectionChanged(object sender, EventArgs e)
        {
            DateTime dtHoy = System.DateTime.Now;
            string ingCalendar = Ingreso.SelectedDate.ToShortDateString();
            string nacCalendar = Nacimiento.SelectedDate.ToShortDateString();
          
            if (ValidarFecha(nacCalendar, ingCalendar))
            {
             txtFinEmp.Text = ingCalendar;
              TimeSpan diferencia = dtHoy - Ingreso.SelectedDate;
              DateTime fechamin = new DateTime(1, 1, 1);
              txtAños.Text = ((fechamin + diferencia).Year - 1).ToString();
              txtMeses.Text = ((fechamin + diferencia).Month - 1).ToString();
              txtDias.Text = ((fechamin + diferencia).Day).ToString();
            }
        }
        protected void Nacimiento_SelectionChanged(object sender, EventArgs e)
        {
            DateTime dtHoy = System.DateTime.Now; 
            string nacCalendar = Nacimiento.SelectedDate.ToShortDateString();
            string ingCalendar = Ingreso.SelectedDate.ToShortDateString();

            if (ValidarFecha(nacCalendar, ingCalendar))
            { 
                txtFnaEmp.Text = nacCalendar;
            }
        }
        protected void txtFnaEmp_TextChanged(object sender, EventArgs e)
        {
           
            

            string ingCalendar = Ingreso.SelectedDate.ToShortDateString();
            string nacCalendar = Nacimiento.SelectedDate.ToShortDateString();

            if (txtFnaEmp.Text != "") 
            {
                ValidarFecha(nacCalendar, ingCalendar); 
                Nacimiento.SelectedDate = Convert.ToDateTime(txtFnaEmp.Text);
                Nacimiento.VisibleDate = Convert.ToDateTime(txtFnaEmp.Text);

            }
        }
        protected void txtFinEmp_TextChanged(object sender, EventArgs e)
        {
            DateTime dtHoy = System.DateTime.Now; 
            
            Ingreso.SelectedDate = Convert.ToDateTime(txtFinEmp.Text);
            Ingreso.VisibleDate = Convert.ToDateTime(txtFinEmp.Text);

            string ingCalendar = Ingreso.SelectedDate.ToShortDateString();
            string nacCalendar = Nacimiento.SelectedDate.ToShortDateString();

            if (txtFinEmp.Text != "")
            {
                Ingreso.SelectedDate = Convert.ToDateTime(txtFinEmp.Text);
                Ingreso.VisibleDate = Convert.ToDateTime(txtFinEmp.Text);

            }

            if (ValidarFecha(nacCalendar, ingCalendar))
            {
                TimeSpan diferencia = dtHoy - Ingreso.SelectedDate;
                DateTime fechamin = new DateTime(1, 1, 1);
                txtAños.Text = ((fechamin + diferencia).Year - 1).ToString();
                txtMeses.Text = ((fechamin + diferencia).Month - 1).ToString();
                txtDias.Text = ((fechamin + diferencia).Day).ToString();
            }
        }
    }
}