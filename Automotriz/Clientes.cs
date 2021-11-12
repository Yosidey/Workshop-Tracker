using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Automotriz
{
    public partial class Clientes : Form
    {
        private const int EM_SETCUEBANNER = 0x1501;
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);
        Cache cache = new Cache();
        int Fila = 0;
        public Clientes()
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
        private void Clientes_Load(object sender, EventArgs e)
        {
            CN_Clientes clientes = new CN_Clientes();

            cache.Tables.Add(clientes.MostrarCliente());
            dgvClientes.DataSource = cache.Tables[0];
            dgvClientes.Columns[0].HeaderText = "Id";
            dgvClientes.Columns[1].HeaderText = "Nombre";
            dgvClientes.Columns[2].HeaderText = "Apellidos";
            dgvClientes.Columns[3].HeaderText = "Telefono";
            dgvClientes.Columns[4].HeaderText = "Correo";
            dgvClientes.Columns[5].HeaderText = "Direccion";
            dgvClientes.Columns[0].Width = 45;
            dgvClientes.Columns[3].Width = 70;
            rbIdCliente.Checked = true;

            SendMessage(txtBusqueNuevo.Handle, EM_SETCUEBANNER, 0, "Buscar Cliente");
        }

        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Fila = dgvClientes.CurrentCell.RowIndex;
            btnEditarCliente.Enabled = true;

        }

        private void btnEditarCliente_Click(object sender, EventArgs e)
        {
            btnEditarCliente.Enabled = false;
            ChangeCliente editar = new ChangeCliente(Convert.ToInt32(dgvClientes[0, Fila].Value.ToString()));
            editar.lblId.Text = "ID:" + dgvClientes[0, Fila].Value.ToString();
            editar.txtNombre.Text = dgvClientes[1, Fila].Value.ToString();
            editar.txtApellidos.Text = dgvClientes[2, Fila].Value.ToString();
            editar.txtTelefono.Text = dgvClientes[3, Fila].Value.ToString();
            editar.txtEmail.Text = dgvClientes[4, Fila].Value.ToString();
            editar.txtDomicilio.Text = dgvClientes[5, Fila].Value.ToString();
            editar.accion = "2";
            editar.lblTitulo.Text = "Editar Cliente";
            editar.ShowDialog();
            cache.Tables.RemoveAt(0);
            Clientes_Load(sender, e);

        }

        private void Clientes_Click(object sender, EventArgs e)
        {
            btnEditarCliente.Enabled = false;
        }

        private void btnNuevoCliente_Click(object sender, EventArgs e)
        {
            ChangeCliente nuevo = new ChangeCliente(0);
            nuevo.accion = "1";
            nuevo.lblTitulo.Text = "Nuevo Cliente";
            nuevo.ShowDialog();
            btnEditarCliente.Enabled = false;
            cache.Tables.RemoveAt(0);
            Clientes_Load(sender, e);
        }

        private void txtBusqueNuevo_TextChanged(object sender, EventArgs e)
        {
            String colname = "";
            if (rbIdCliente.Checked == true)
            {
                colname = "ClienteId";
            }
            if (rbNombreCliente.Checked == true)
            {
                colname = "CNombre";
            }
            cache.Tables[0].DefaultView.RowFilter = "CONVERT(" + colname + ", System.String) like '" + txtBusqueNuevo.Text + "%'";
            dgvClientes.DataSource = cache.Tables[0].DefaultView;
        }

        private void rbIdCliente_CheckedChanged(object sender, EventArgs e)
        {
            txtBusqueNuevo_TextChanged(sender, e);
        }
    }
}
