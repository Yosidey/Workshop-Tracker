using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Automotriz
{
    public partial class ChangeCliente : Form
    {
        private const int EM_SETCUEBANNER = 0x1501;
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);
        Cache cache = new Cache();
        public String accion = "";
        CN_Clientes clientes = new CN_Clientes();
        Datos datos = new Datos();
        public ChangeCliente(int idCliente)
        {
            InitializeComponent();
            datos.ClienteId = idCliente;

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

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void cargarDatos()
        {
            datos.accion = accion;
            datos.CNombre = txtNombre.Text;
            datos.CApellidos = txtApellidos.Text;
            datos.CTelefono = txtTelefono.Text;
            datos.CEmail = txtEmail.Text;
            datos.CDomicilio = txtDomicilio.Text;
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text != "" && txtApellidos.Text != "" && txtTelefono.Text != "" && txtEmail.Text != "" && txtDomicilio.Text != "")
            {
                MensajeOK mensajeOK = new MensajeOK("Confirmacion", "¿Estas seguro de Guardar?");

                DialogResult opcion = mensajeOK.ShowDialog();
                if (opcion == DialogResult.OK)
                {
                    Operaciones();

                }
            }
            else
            {
                MensajeOK mensajeDatos = new MensajeOK("Datos Invalidos", "Campos Vacios");
                mensajeDatos.ShowDialog();
                return;
            }
        }

        private void Operaciones()
        {

            cargarDatos();
            Validaciones validaciones = new Validaciones();
            if (!validaciones.ValidarCorreo(datos.CEmail))
            {
                MensajeOK mensajeCorreo = new MensajeOK("Datos Invalidos", "Correo Invalido");
                mensajeCorreo.ShowDialog();
                return;
            }

            if (!validaciones.ValidarTelefono(datos.CTelefono))
            {
                MensajeOK mensajeTelefono = new MensajeOK("Datos Invalidos", "Telefono Invalido");
                mensajeTelefono.ShowDialog();
                return;
            }

            clientes.CN_Operaciones(datos);
            MensajeOK mensajeOperacion = new MensajeOK("Operacion exitosa", "Se guardo Correctamente");
            mensajeOperacion.ShowDialog();
            this.DialogResult = DialogResult.OK;
        }

        private void ChangeCliente_Load(object sender, EventArgs e)
        {
            SendMessage(txtNombre.Handle, EM_SETCUEBANNER, 0, "Ej. Juan Francisco");
            SendMessage(txtApellidos.Handle, EM_SETCUEBANNER, 0, "Ej. Valle Salas");
            SendMessage(txtTelefono.Handle, EM_SETCUEBANNER, 0, "Ej. 3112320011");
            SendMessage(txtEmail.Handle, EM_SETCUEBANNER, 0, "Ej. email@example.com");
            SendMessage(txtDomicilio.Handle, EM_SETCUEBANNER, 0, "Ej. Tecuala, Av. Colosio. #31, CP: 123456, Nayarit, Mexico");
        }
    }
}
