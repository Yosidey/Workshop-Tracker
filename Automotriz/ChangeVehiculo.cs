using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Automotriz
{
    public partial class ChangeVehiculo : Form
    {
        private const int EM_SETCUEBANNER = 0x1501;
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);
        Cache cache = new Cache();
        Datos datos = new Datos();
        CN_Vehiculos vehiculos = new CN_Vehiculos();
        public String accion = "";
        public int idCliente = 0;
        public int idVehiculo = 0;
        public ChangeVehiculo()
        {
            InitializeComponent();
            cmbCliente.DropDownStyle = ComboBoxStyle.DropDownList;
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
        public void cargarDatos()
        {
            datos.accion = accion;
            datos.ClienteId = Convert.ToInt32(cmbCliente.SelectedValue);
            datos.VehiculoId = idVehiculo;
            datos.VMarca = txtMarca.Text;
            datos.VPlaca = txtPlaca.Text;
            datos.VModelo = txtModelo.Text;
            datos.Vaño = txtAño.Text;
            datos.VColor = txtColor.Text;
        }
        private void ChangeVehiculo_Load(object sender, EventArgs e)
        {
            CN_Vehiculos empleado = new CN_Vehiculos();
            cache.Tables.Add(empleado.MostrarClienteCB());
            cmbCliente.DataSource = empleado.MostrarClienteCB();
            cmbCliente.DisplayMember = "nombreCompleto";
            cmbCliente.ValueMember = "ClienteId";
            if (idVehiculo != 0 && idCliente != 0)
            {
                cmbCliente.SelectedValue = idCliente;
                cmbCliente.Enabled = false;
            }
            else
            {
                cmbCliente.Enabled = true;
                cbCliente.Visible = false;
            }
            SendMessage(txtPlaca.Handle, EM_SETCUEBANNER, 0, "Ej. AAA-BBB-CCC");
            SendMessage(txtMarca.Handle, EM_SETCUEBANNER, 0, "Ej. Ford");
            SendMessage(txtModelo.Handle, EM_SETCUEBANNER, 0, "Ej.  Fiesta");
            SendMessage(txtAño.Handle, EM_SETCUEBANNER, 0, "Ej. 2015");
            SendMessage(txtColor.Handle, EM_SETCUEBANNER, 0, "Ej. Azul");
        }
        private void Operaciones()
        {
            cargarDatos();
            vehiculos.CN_Operaciones(datos);
            MensajeOK mensajeOperacion = new MensajeOK("Operacion exitosa", "Se guardo Correctamente");
            mensajeOperacion.ShowDialog();
            this.DialogResult = DialogResult.OK;
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtMarca.Text != "" && txtPlaca.Text != "" && txtModelo.Text != "" && txtAño.Text != "" && txtColor.Text != "")
            {
                Operaciones();
            }
            else
            {
                MensajeOK mensajeDatos = new MensajeOK("Datos Invalidos", "Campos Vacios");
                mensajeDatos.ShowDialog();
                return;
            }
        }

        private void cbCliente_CheckedChanged(object sender, EventArgs e)
        {
            if (cbCliente.Checked == true)
            {
                cmbCliente.Enabled = true;
            }
            else
            {
                cmbCliente.Enabled = false;
                cmbCliente.SelectedValue = idCliente;
            }

        }
    }
}
