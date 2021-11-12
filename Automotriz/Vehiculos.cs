using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Automotriz
{
    public partial class Vehiculos : Form
    {
        private const int EM_SETCUEBANNER = 0x1501;
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);
        Cache cache = new Cache();
        int Fila = 0;
        public Vehiculos()
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

        private void Vehiculos_Load(object sender, EventArgs e)
        {
            btnEditarVehiculo.Enabled = false;
            CN_Vehiculos empleado = new CN_Vehiculos();
            cache.Tables.Add(empleado.MostrarVehiculo());

            dvgVehiculo.DataSource = cache.Tables[0];
            dvgVehiculo.Columns[0].HeaderText = ("Id Vehiculo");
            dvgVehiculo.Columns[1].HeaderText = ("Id Cliente");
            dvgVehiculo.Columns[2].HeaderText = ("Cliente");
            dvgVehiculo.Columns[3].HeaderText = ("Placa");
            dvgVehiculo.Columns[4].HeaderText = ("Marca");
            dvgVehiculo.Columns[5].HeaderText = ("Modelo");
            dvgVehiculo.Columns[6].HeaderText = ("Año");
            dvgVehiculo.Columns[7].HeaderText = ("Color");
            dvgVehiculo.Columns[0].Width = 98;
            dvgVehiculo.Columns[1].Width = 98;
            dvgVehiculo.Columns[2].Width = 168;
            dvgVehiculo.Columns[2].Width = 108;
            dvgVehiculo.Columns[4].Width = 128;
            dvgVehiculo.Columns[6].Width = 50;
            dvgVehiculo.Columns[7].Width = 108;
            rbIdVehiculo.Checked = true;

            SendMessage(txtBusquedad.Handle, EM_SETCUEBANNER, 0, "Buscar Vehiculo");
        }


        private void btnNuevo_Click(object sender, EventArgs e)
        {


            ChangeVehiculo nuevo = new ChangeVehiculo();
            nuevo.accion = "1";
            nuevo.idCliente = 0;
            nuevo.idVehiculo = 0;
            nuevo.lblTitulo.Text = "Nuevo Vehiculo";
            nuevo.ShowDialog();
            cache.Tables.RemoveAt(0);
            Vehiculos_Load(sender, e);
        }

        private void dvgVehiculo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Fila = dvgVehiculo.CurrentCell.RowIndex;
            btnEditarVehiculo.Enabled = true;
        }

        private void btnEditarVehiculo_Click(object sender, EventArgs e)
        {
            ChangeVehiculo editar = new ChangeVehiculo();
            editar.lblTitulo.Text = "Editar Vehiculo";
            editar.idVehiculo = Convert.ToInt32(dvgVehiculo[0, Fila].Value.ToString());
            editar.idCliente = Convert.ToInt32(dvgVehiculo[1, Fila].Value.ToString());
            //editar.cmbCliente.SelectedValue = Convert.ToInt32(dvgVehiculo[1, Fila].Value.ToString());
            editar.lbId.Text = "ID:" + dvgVehiculo[0, Fila].Value.ToString();

            editar.txtPlaca.Text = dvgVehiculo[3, Fila].Value.ToString();
            editar.txtMarca.Text = dvgVehiculo[4, Fila].Value.ToString();
            editar.txtModelo.Text = dvgVehiculo[5, Fila].Value.ToString();
            editar.txtAño.Text = dvgVehiculo[6, Fila].Value.ToString();
            editar.txtColor.Text = dvgVehiculo[7, Fila].Value.ToString();
            editar.accion = "2";
            editar.ShowDialog();
            btnEditarVehiculo.Enabled = false;
            cache.Tables.RemoveAt(0);
            Vehiculos_Load(sender, e);
        }

        private void Vehiculos_Click(object sender, EventArgs e)
        {
            btnEditarVehiculo.Enabled = false;
        }

        private void txtBusquedad_TextChanged(object sender, EventArgs e)
        {
            String colname = "";
            if (rbIdVehiculo.Checked == true)
            {
                colname = "VehiculoId";
            }
            if (rbIdCliente.Checked == true)
            {
                colname = "ClienteId";
            }
            if (rbNombreCliente.Checked == true)
            {
                colname = "CNombre";
            }
            if (rbPlaca.Checked == true)
            {
                colname = "VPlaca";
            }
            if (rbMarca.Checked == true)
            {
                colname = "VMarca";
            }
            if (rbModelo.Checked == true)
            {
                colname = "VModelo";
            }
            cache.Tables[0].DefaultView.RowFilter = "CONVERT(" + colname + ", System.String) like '" + txtBusquedad.Text + "%'";
            dvgVehiculo.DataSource = cache.Tables[0].DefaultView;
        }

        private void rbIdVehiculo_CheckedChanged(object sender, EventArgs e)
        {
            txtBusquedad_TextChanged(sender, e);
        }
    }
}
