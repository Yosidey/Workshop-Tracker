using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Automotriz
{
    public partial class Empleados : Form
    {
        private const int EM_SETCUEBANNER = 0x1501;
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);
        Cache cache = new Cache();
        int Fila = 0;
        public Empleados()
        {
            InitializeComponent();
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }
        private void Empleados_Load(object sender, EventArgs e)
        {
            CN_Empleados empleado = new CN_Empleados();
            cache.Tables.Add(empleado.MostrarEmpleado());
            // MessageBox.Show("Numero de Tablas:"+cache.Tables.Count);

            dvgEmpleados.DataSource = cache.Tables[0];
            dvgEmpleados.Columns[0].HeaderText = "Id";
            dvgEmpleados.Columns[1].HeaderText = "Nombre";
            dvgEmpleados.Columns[2].HeaderText = "Apellidos";
            dvgEmpleados.Columns[3].HeaderText = "Telefono";
            dvgEmpleados.Columns[4].HeaderText = "Correo";
            dvgEmpleados.Columns[5].HeaderText = "Direccion";
            dvgEmpleados.Columns[6].HeaderText = "Estatus";

            dvgEmpleados.Columns[0].Width = 45;
            dvgEmpleados.Columns[3].Width = 110;
            dvgEmpleados.Columns[6].Width = 110;
            rbIdEmpleado.Checked = true;
            SendMessage(txtBusqueda.Handle, EM_SETCUEBANNER, 0, "Buscar Empleado");

        }

        private void dvgEmpleados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Fila = dvgEmpleados.CurrentCell.RowIndex;
            btnEditarEmpleado.Enabled = true;
        }

        private void btnEditarEmpleado_Click(object sender, EventArgs e)
        {
            btnEditarEmpleado.Enabled = false;
            ChangeEmpleado editar = new ChangeEmpleado(Convert.ToInt32(dvgEmpleados[0, Fila].Value.ToString()));
            editar.lblId.Text = "ID:" + dvgEmpleados[0, Fila].Value.ToString();
            editar.txtNombre.Text = dvgEmpleados[1, Fila].Value.ToString();
            editar.txtApellidos.Text = dvgEmpleados[2, Fila].Value.ToString();
            editar.txtTelefono.Text = dvgEmpleados[3, Fila].Value.ToString();
            editar.txtEmail.Text = dvgEmpleados[4, Fila].Value.ToString();
            editar.txtDomicilio.Text = dvgEmpleados[5, Fila].Value.ToString();
            editar.txtFecha.Text = dvgEmpleados[6, Fila].Value.ToString() + "";
            editar.accion = "2";
            editar.lblTitulo.Text = "Editar Empleado";
            DialogResult result = editar.ShowDialog();
            if (result == DialogResult.OK)
            {
                cache.Tables.RemoveAt(0);
                Empleados_Load(sender, e);
            }

        }

        private void btnNuevoEmpleado_Click(object sender, EventArgs e)
        {
            ChangeEmpleado nuevo = new ChangeEmpleado(0);
            nuevo.accion = "1";
            nuevo.lblTitulo.Text = "Nuevo Emepleado";
            DialogResult result = nuevo.ShowDialog();
            if (result == DialogResult.OK)
            {
                btnEditarEmpleado.Enabled = false;
                cache.Tables.RemoveAt(0);
                Empleados_Load(sender, e);
            }
        }

        private void Empleados_Click(object sender, EventArgs e)
        {
            btnEditarEmpleado.Enabled = false;
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            String colname = "";
            if (rbIdEmpleado.Checked == true)
            {
                colname = "EmpleadoId";
            }
            if (rbNombre.Checked == true)
            {
                colname = "ENombre";
            }
            cache.Tables[0].DefaultView.RowFilter = "CONVERT(" + colname + ", System.String) like '" + txtBusqueda.Text + "%'";
            dvgEmpleados.DataSource = cache.Tables[0].DefaultView;
        }

        private void rbIdEmpleado_CheckedChanged(object sender, EventArgs e)
        {
            txtBusqueda_TextChanged(sender, e);
        }
    }
}
