using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Automotriz
{
    public partial class ChangeServicio : Form
    {
        private const int EM_SETCUEBANNER = 0x1501;
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);
        Cache cache = new Cache();
        Datos datos = new Datos();
        public int ServicioId = 0;
        public int ClienteId = 0;
        public int EmpleadoId = 0;
        public int VehiculoId = 0;
        public String accion = "";
        CN_Vehiculos vehiculos = new CN_Vehiculos();
        public ChangeServicio()
        {
            InitializeComponent();
            cmbCliente.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEmpleado.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbVehiculos.DropDownStyle = ComboBoxStyle.DropDownList;

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

        private void ChangeServicio_Load(object sender, EventArgs e)
        {
            cmbCliente.DataSource = vehiculos.MostrarClienteCB();
            cmbCliente.DisplayMember = "nombreCompleto";
            cmbCliente.ValueMember = "ClienteId";

            cmbEmpleado.DataSource = vehiculos.MostrarEmpleadoCB();
            cmbEmpleado.DisplayMember = "nombreCompleto";
            cmbEmpleado.ValueMember = "EmpleadoId";
            if (ServicioId != 0)
            {
                cmbCliente.SelectedValue = ClienteId;
                cmbVehiculos.DataSource = vehiculos.MostrarVehciculosClienteCB(ClienteId);
                cmbVehiculos.DisplayMember = "VehiculoCliente";
                cmbVehiculos.ValueMember = "VehiculoId";
                cmbVehiculos.SelectedValue = VehiculoId;
            }
            else
            {
                cmbCliente.SelectedValue = 0;
                cmbEmpleado.SelectedValue = 0;
                cmbVehiculos.SelectedValue = 0;
            }
            SendMessage(txtDescripcion.Handle, EM_SETCUEBANNER, 0, "Descripcion del Servicio. Ej. Cambio de Aceite");
            SendMessage(txtComentario.Handle, EM_SETCUEBANNER, 0, "Informacion Adiccional. Ej. Ruido Extraño en el Motor");
            SendMessage(txtPrecio.Handle, EM_SETCUEBANNER, 0, "$ 0.00 MXN");
        }

        private void cmbCliente_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cmbVehiculos.DataSource = vehiculos.MostrarVehciculosClienteCB(Convert.ToInt32(cmbCliente.SelectedValue));
            cmbVehiculos.DisplayMember = "VehiculoCliente";
            cmbVehiculos.ValueMember = "VehiculoId";

        }

        public void cargarDatos()
        {
            datos.accion = accion;
            datos.ServicioId = ServicioId;
            datos.ClienteId = Convert.ToInt32(cmbCliente.SelectedValue);
            datos.VehiculoId = Convert.ToInt32(cmbVehiculos.SelectedValue);
            datos.EmpleadoId = Convert.ToInt32(cmbEmpleado.SelectedValue);
            datos.SDescripcion = txtDescripcion.Text;
            datos.SComentario = txtComentario.Text;
            datos.SPrecio = Convert.ToSingle(txtPrecio.Text);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtComentario.Text != "" && txtDescripcion.Text != "" && txtPrecio.Text != "" && cmbCliente.SelectedValue != "0" && cmbVehiculos.SelectedValue != "0")
            {
                Operaciones();
            }
        }

        private void Operaciones()
        {
            cargarDatos();
            CN_Servicios servicios = new CN_Servicios();
            servicios.CN_Operaciones(datos);

            MensajeOK mensaje = new MensajeOK("Aviso", "Operacion exitosa ");
            mensaje.ShowDialog();
            this.DialogResult = DialogResult.OK;
        }
    }
}
