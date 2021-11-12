using Automotriz.Properties;
using System;
using System.Net;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace Automotriz
{
    public partial class SettingsConnection : Form
    {
        private const int EM_SETCUEBANNER = 0x1501;
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);


        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }

        public SettingsConnection()
        {
            InitializeComponent();
        }


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cmbCadenaConexion.SelectedIndex == 0)
            {
                Handle();
                CargarDatos();
                Limpiar();
                MensajeOK mensaje = new MensajeOK("Aviso", "Seleccionar una Conexión");
                mensaje.ShowDialog();
                SettingsConnection_Load(sender, e);
                return;
            }
            if (cmbCadenaConexion.SelectedIndex == 1)
            {
                txtServer.Text = "localhost";
                txtServer.Enabled = false;
                Settings.Default.Tipo = 1;
                Settings.Default.Servidor = txtServer.Text;
                Settings.Default.Usuario = txtUser.Text;
                Settings.Default.Contraseña = txtPassword.Text;
                Settings.Default.BaseDatos = txtBaseDatos.Text;
                MensajeOK mensaje = new MensajeOK("Exito", "Información Actualizada");
                mensaje.ShowDialog();
                Settings.Default.Save();
                SettingsConnection_Load(sender, e);
            }
            if (cmbCadenaConexion.SelectedIndex == 2)
            {
                if (ValidaVacio(txtServer.Text))
                {
                    txtServer.Enabled = true;
                    Settings.Default.Tipo = 2;
                    Settings.Default.Servidor = txtServer.Text;
                    Settings.Default.Usuario = txtUser.Text;
                    Settings.Default.Contraseña = txtPassword.Text;
                    Settings.Default.BaseDatos = txtBaseDatos.Text;
                    Settings.Default.Save();
                    MensajeOK mensaje = new MensajeOK("Exito", "Información Actualizada");
                    mensaje.ShowDialog();
                    SettingsConnection_Load(sender, e);
                }
            }
            if (cmbCadenaConexion.SelectedIndex == 3)
            {
                if (ValidaIP(txtServer.Text))
                {
                    txtServer.Enabled = true;
                    txtPassword.Enabled = true;
                    txtUser.Enabled = true;
                    Settings.Default.Tipo = 3;
                    Settings.Default.Servidor = txtServer.Text;
                    Settings.Default.Usuario = txtUser.Text;
                    Settings.Default.Contraseña = txtPassword.Text;
                    Settings.Default.BaseDatos = txtBaseDatos.Text;
                    Settings.Default.Save();
                    MensajeOK mensaje = new MensajeOK("Exito", "Información Actualizada");
                    mensaje.ShowDialog();
                    SettingsConnection_Load(sender, e);
                }
            }
            if (cmbCadenaConexion.SelectedIndex == 4)
            {
                if (IsValidURL(txtServer.Text))
                {
                    txtServer.Enabled = true;
                    txtPassword.Enabled = true;
                    txtUser.Enabled = true;
                    Settings.Default.Tipo = 4;
                    Settings.Default.Servidor = txtServer.Text;
                    Settings.Default.Usuario = txtUser.Text;
                    Settings.Default.Contraseña = txtPassword.Text;
                    Settings.Default.BaseDatos = txtBaseDatos.Text;
                    Settings.Default.Save();
                    MensajeOK mensaje = new MensajeOK("Exito", "Información Actualizada");
                    mensaje.ShowDialog();
                    SettingsConnection_Load(sender, e);
                }
                else
                {
                    MensajeOK mensaje = new MensajeOK("Aviso", "URL Inválida");
                    mensaje.ShowDialog();
                }
            }
        }
        public void CargarDatos()
        {
            cmbCadenaConexion.SelectedIndex = Tipo;
            txtServer.Text = Servidor;
            txtUser.Text = Usuario;
            txtPassword.Text = Contraseña;
            txtBaseDatos.Text = BaseDatos;
        }
        public int Tipo = 0;
        public String Servidor = "";
        private String Usuario = "";
        private String Contraseña = "";
        private static String BaseDatos = "";
        private void SettingsConnection_Load(object sender, EventArgs e)
        {
            Tipo = Settings.Default.Tipo;
            Servidor = Settings.Default.Servidor;
            Usuario = Settings.Default.Usuario;
            Contraseña = Settings.Default.Contraseña;
            BaseDatos = Settings.Default.BaseDatos;
            cmbCadenaConexion.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCadenaConexion.Focus();
            Handle();
            CargarDatos();
            btnMostrar.BringToFront();


        }
        public void Limpiar()
        {
            txtServer.Text = "";
            txtBaseDatos.Text = "";
            txtUser.Text = "";
            txtPassword.Text = "";
        }
        public void Habilitar()
        {
            txtServer.Enabled = true;
            txtPassword.Enabled = true;
            txtUser.Enabled = true;
        }
        public void Inhabilitar()
        {
            txtServer.Enabled = false;
            txtUser.Enabled = false;
            txtPassword.Enabled = false;
        }
        public void Handle()
        {
            SendMessage(txtServer.Handle, EM_SETCUEBANNER, 0, "Server");
            SendMessage(txtUser.Handle, EM_SETCUEBANNER, 0, "User");
            SendMessage(txtBaseDatos.Handle, EM_SETCUEBANNER, 0, "DataBase");
            SendMessage(txtPassword.Handle, EM_SETCUEBANNER, 0, "Password");
        }
        bool IsValidURL(string URL)
        {
            string Pattern = @"^(?:http(s)?:\/\/)?[\w.-]+(?:\.[\w\.-]+)+[\w\-\._~:/?#[\]@!\$&'\(\)\*\+,;=.]+$";
            Regex Rgx = new Regex(Pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            return Rgx.IsMatch(URL);
        }
        private void cmbCadenaConexion_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cmbCadenaConexion.SelectedIndex == 0)
            {
                Limpiar();
                Inhabilitar();
                Handle();
            }
            if (cmbCadenaConexion.SelectedIndex == 1)
            {
                Limpiar();
                txtServer.Text = "localhost";
                Habilitar();
                txtServer.Enabled = false;
            }
            if (cmbCadenaConexion.SelectedIndex == 2)
            {
                Limpiar();
                SendMessage(txtServer.Handle, EM_SETCUEBANNER, 0, "DESKTOP-81FIMPA");
                Habilitar();
            }
            if (cmbCadenaConexion.SelectedIndex == 3)
            {
                Limpiar();
                SendMessage(txtServer.Handle, EM_SETCUEBANNER, 0, "192.168.24.10");
                Habilitar();
            }
            if (cmbCadenaConexion.SelectedIndex == 4)
            {
                Limpiar();
                SendMessage(txtServer.Handle, EM_SETCUEBANNER, 0, "Url Hosting");
                Habilitar();
            }
        }
        private Boolean ValidaIP(string sIP)
        {
            try
            {
                IPAddress ip = IPAddress.Parse(sIP);
            }
            catch
            {
                MensajeOK mensaje = new MensajeOK("Aviso", "Ip Inválida");
                mensaje.ShowDialog();
                return false;
            }
            return true;
        }
        private Boolean ValidaVacio(String texto)
        {
            if (texto != "")
            {
                return true;
            }
            else
            {
                MensajeOK mensaje = new MensajeOK("Aviso", "Server Inválido");
                mensaje.ShowDialog();
                return false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {


            CD_Conexion conexion = new CD_Conexion();
            try
            {
                if (conexion.IsConnection())
                {
                    MensajeOK mensaje = new MensajeOK("Aviso", "Conexion Exitosa");
                    mensaje.ShowDialog();
                }
                else
                {
                    MensajeOK mensaje = new MensajeOK("Aviso", "Fallo Conexion");
                    mensaje.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MensajeOK mensaje = new MensajeOK(ex.Message, "Fallo Conexion");
                mensaje.ShowDialog();
            }

        }

        private void btnOcultar_Click(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar == '\0')
            {
                btnMostrar.BringToFront();
                txtPassword.PasswordChar = '*';
            }
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar == '*')
            {
                btnOcultar.BringToFront();
                txtPassword.PasswordChar = '\0';
            }
        }

        private void SettingsConnection_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            SettingsConnection_Load(sender, e);
        }
    }
}
