using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Automotriz
{
    public partial class Registros : Form
    {
        private const int EM_SETCUEBANNER = 0x1501;
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);
        Cache cache = new Cache();
        public Registros()
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
        private void Registros_Load(object sender, EventArgs e)
        {
            CN_Servicios servicios = new CN_Servicios();
            cache.Tables.Add(servicios.MostrarServicio());
            dgvServicios.DataSource = cache.Tables[0];
            dgvServicios.Columns[0].HeaderText = ("Id Servicio");
            dgvServicios.Columns[1].HeaderText = ("Placa");
            dgvServicios.Columns[2].HeaderText = ("Cliente");
            dgvServicios.Columns[3].HeaderText = ("Servicio");
            dgvServicios.Columns[4].HeaderText = ("Empleado");
            dgvServicios.Columns[5].HeaderText = ("Precio");
            dgvServicios.Columns[6].HeaderText = ("Registro");
            dgvServicios.Columns[7].HeaderText = ("Entregado");

            dgvServicios.Columns[0].Width = 94;
            dgvServicios.Columns[1].Width = 108;
            dgvServicios.Columns[2].Width = 128;
            dgvServicios.Columns[4].Width = 128;
            dgvServicios.Columns[6].Width = 90;
            dgvServicios.Columns[7].Width = 90;
            rbIdServicio.Checked = true;
            SendMessage(txtBusqueda.Handle, EM_SETCUEBANNER, 0, "Buscar Servicio");
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            String colname = "";
            if (rbIdServicio.Checked == true)
            {
                colname = "ServicioId";
            }
            if (rbPlaca.Checked == true)
            {
                colname = "VPlaca";
            }
            if (rbCliente.Checked == true)
            {
                colname = "CNombre";
            }
            if (rbEmpleado.Checked == true)
            {
                colname = "ENombre";
            }
            cache.Tables[0].DefaultView.RowFilter = "CONVERT(" + colname + ", System.String) like '" + txtBusqueda.Text + "%'";
            dgvServicios.DataSource = cache.Tables[0].DefaultView;
        }

        private void rbIdServicio_CheckedChanged(object sender, EventArgs e)
        {
            txtBusqueda_TextChanged(sender, e);
        }

        private void dgvServicios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int idServicio = Convert.ToInt32(dgvServicios[0, dgvServicios.CurrentCell.RowIndex].Value.ToString());
            MensajeOkCancel confirmacion = new MensajeOkCancel("Confirmacion", $"¿Deseas imprimir Garantia del servicio con el {idServicio}?");
            DialogResult result = confirmacion.ShowDialog();
            if (result == DialogResult.OK)
            {
                FromReporteServicio reporte = new FromReporteServicio(idServicio);
                reporte.ShowDialog();
            }
        }
    }
}
