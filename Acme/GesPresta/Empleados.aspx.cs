﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GesPresta
{
    public partial class Empleados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtCodEmp.Focus(); // Sitúa el foco en el elemento Código Empleado
        }
    }
}