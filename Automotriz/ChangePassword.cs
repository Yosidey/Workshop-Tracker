using Automotriz.Properties;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Automotriz
{
    public partial class ChangePassword : Form
    {
        private const int EM_SETCUEBANNER = 0x1501;
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);
        public ChangePassword()
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
        private String password = Settings.Default.password;
        public void Equals()
        {
            if (txtNuevoPassword.Text == txtConfirmaPassword.Text && txtNuevoPassword.Text != "" && txtConfirmaPassword.Text != "")
            {
                btnConfirmar.Enabled = true;
                //MessageBox.Show("Se activo");
            }
            else
            {
                btnConfirmar.Enabled = false;
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text != password)
            {
                MensajeOK mensaje = new MensajeOK("Aviso", "Contraseña incorrecta");
                mensaje.ShowDialog();
            }
            else
            {
                Settings.Default.password = txtNuevoPassword.Text;
                Settings.Default.Save();
                MensajeOK mensaje = new MensajeOK("Exito", "Cambio de contraseña");
                mensaje.ShowDialog();
                this.Dispose();

            }

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Dispose();

        }

        private void txtNuevoPassword_TextChanged(object sender, EventArgs e)
        {
            Equals();
        }

        private void txtConfirmaPassword_TextChanged(object sender, EventArgs e)
        {
            Equals();
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

        private void ChangePassword_Load(object sender, EventArgs e)
        {
            btnMostrar.BringToFront();
            SendMessage(txtPassword.Handle, EM_SETCUEBANNER, 0, "Password");
            SendMessage(txtNuevoPassword.Handle, EM_SETCUEBANNER, 0, "Nuevo Password");
            SendMessage(txtConfirmaPassword.Handle, EM_SETCUEBANNER, 0, "Confirmar Password");
        }

        private void ChangePassword_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }
    }
}
