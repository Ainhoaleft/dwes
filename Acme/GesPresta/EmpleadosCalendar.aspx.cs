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
            "<br/> Departamento: " + ddlDepEmp.Text;
           
        }
        
        DateTime dtHoy = System.DateTime.Now;
        //string fechaActual = dtHoy.Year.ToString();
        //DateTime moment = new System.DateTime.Now;
        //int ano = dtHoy.Year;

        public static Boolean bisiesto(int ano) {
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
        }
        protected void Ingreso_SelectionChanged(object sender, EventArgs e)
        {
            DateTime ing = Ingreso.SelectedDate;
            DateTime nac = Nacimiento.SelectedDate;
            string ingCalendar = Ingreso.SelectedDate.ToShortDateString();
            txtFinEmp.Text = ingCalendar;



            TimeSpan diferencia = dtHoy - Ingreso.SelectedDate;
            DateTime fechamin = new DateTime(1, 1, 1);

            txtAños.Text = ((fechamin + diferencia).Year - 1).ToString();
            txtMeses.Text = ((fechamin + diferencia).Month - 1).ToString();
            txtDias.Text = ((fechamin + diferencia).Day).ToString();

            if (ing < nac)
            {
                lblError1.Visible = true;
                lblError1.Text = "Introduce la fecha de nacimiento valida";
            }
            if (ing > dtHoy)
            {
                lblError2.Visible = true;
                lblError2.Text = "Introduce la fecha de ingreso valida";
            }

        }

        protected void Nacimiento_SelectionChanged(object sender, EventArgs e)
        {
            //string fecha_nac = CalendarNacEmp.SelectedDate.ToShortDateString();
            DateTime nac = Nacimiento.SelectedDate;
            string nacCalendar = Nacimiento.SelectedDate.ToShortDateString();
            txtFnaEmp.Text = nacCalendar;

            

            if (nac > dtHoy)
            {
                lblError3.Visible = true;
                lblError3.Text = "Introduce la fecha valida";
            }
        }

        protected void txtFnaEmp_TextChanged(object sender, EventArgs e)
        {
            Nacimiento.SelectedDate = Convert.ToDateTime(txtFnaEmp.Text);
            Nacimiento.VisibleDate = Convert.ToDateTime(txtFnaEmp.Text);
        }

        protected void txtFinEmp_TextChanged(object sender, EventArgs e)
        {
            Ingreso.SelectedDate = Convert.ToDateTime(txtFinEmp.Text);
            Ingreso.VisibleDate = Convert.ToDateTime(txtFinEmp.Text);

            DateTime dtHoy = System.DateTime.Now;
            TimeSpan diferencia = dtHoy - Ingreso.SelectedDate;
            DateTime fechamin = new DateTime(1, 1, 1);

            txtAños.Text = ((fechamin + diferencia).Year - 1).ToString();
            txtMeses.Text = ((fechamin + diferencia).Month - 1).ToString();
            txtDias.Text = ((fechamin + diferencia).Day).ToString();
        }
    }
}