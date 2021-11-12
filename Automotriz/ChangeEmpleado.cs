using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Automotriz
{
    public partial class ChangeEmpleado : Form
    {
        private const int EM_SETCUEBANNER = 0x1501;
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);
        Cache cache = new Cache();
        public String accion = "";
        CN_Empleados empleados = new CN_Empleados();
        Datos datos = new Datos();
        public String Fecha = "";
        public ChangeEmpleado(int IDP)
        {
            InitializeComponent();
            datos.EmpleadoId = IDP;
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
            datos.ENombre = txtNombre.Text;
            datos.EApellidos = txtApellidos.Text;
            datos.ETelefono = txtTelefono.Text;
            datos.EEmail = txtEmail.Text;
            datos.EDomicilio = txtDomicilio.Text;
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
            if (!validaciones.ValidarCorreo(datos.EEmail))
            {
                MensajeOK mensajeError = new MensajeOK("Advertencia", "Correo Invalido");
                mensajeError.ShowDialog();
                return;
            }

            if (!validaciones.ValidarTelefono(datos.ETelefono))
            {
                MensajeOK mensajeError = new MensajeOK("Advertencia", "Telefono Invalido");
                mensajeError.ShowDialog();
                return;
            }
            empleados.CN_Operaciones(datos);
            if (datos.EmpleadoId != 0)
            {
                if (cbStatus.Checked != false)
                {
                    empleados.CN_Activar_Empleo(datos);
                }
                if (cbStatus.Checked != true)
                {
                    if (empleados.ConsultarServicio(datos.EmpleadoId) > 0)
                    {
                        MensajeOK mensajeActivo = new MensajeOK("Advertencia", "Empleado tiene servicio activo´s, modificar servicio para desactivar");
                        mensajeActivo.ShowDialog();
                    }
                    else
                    {
                        empleados.CN_Desactivar_Empleo(datos);
                    }
                }
            }
            MensajeOK mensajeDatos = new MensajeOK("Exito", "Operacion Realizada");
            mensajeDatos.ShowDialog();
            this.DialogResult = DialogResult.OK;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ChangeEmpleado_Load(object sender, EventArgs e)
        {
            if (datos.EmpleadoId == 0)
            {
                txtFecha.Text = "Activado";
                txtFecha.Enabled = false;
                cbStatus.Checked = true;
            }
            else
            {
                if (txtFecha.Text == "")
                {
                    cbStatus.Checked = true;
                    cbStatus.Text = "Activado";
                }
                else
                {
                    cbStatus.Checked = false;
                    cbStatus.Text = "Desactivado";
                }
            }
            SendMessage(txtNombre.Handle, EM_SETCUEBANNER, 0, "Ej. Juan Francisco");
            SendMessage(txtApellidos.Handle, EM_SETCUEBANNER, 0, "Ej. Valle Salas");
            SendMessage(txtTelefono.Handle, EM_SETCUEBANNER, 0, "Ej. 3112320011");
            SendMessage(txtEmail.Handle, EM_SETCUEBANNER, 0, "Ej. email@example.com");
            SendMessage(txtDomicilio.Handle, EM_SETCUEBANNER, 0, "Ej. Tecuala, Av. Colosio. #31, CP: 123456, Nayarit, Mexico");
        }

        private void cbStatus_CheckedChanged(object sender, EventArgs e)
        {
            if (cbStatus.Checked == false)
            {
                txtFecha.Text = DateTime.Now.ToString("dd-MM-yyyy");
                cbStatus.Text = "Desactivado";
            }
            if (cbStatus.Checked == true)
            {
                txtFecha.Text = "";
                cbStatus.Text = "Activado";
            }
        }

    }
}
