using System;
using System.Collections.Generic;
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


        protected void Ingreso_SelectionChanged(object sender, EventArgs e)
        {
            DateTime ing = Convert.ToDateTime(txtFinEmp.Text);
            DateTime nac = Convert.ToDateTime(txtFnaEmp.Text);

            if (ing < nac)
            {
                lblError1.Text = "Introduce la fecha de nacimiento valida";
            }
            if (ing > dtHoy)
            {
                lblError2.Text = "Introduce la fecha de ingreso valida";
            }

        }

        protected void Nacimiento_SelectionChanged(object sender, EventArgs e)
        {

            DateTime nac = Convert.ToDateTime(txtFnaEmp.Text);

            if (nac > dtHoy)
            {
                lblError3.Text = "Introduce la fecha valida";
            }
        }
    }
}