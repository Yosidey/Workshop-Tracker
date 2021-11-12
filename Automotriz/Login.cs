using Automotriz.Properties;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Automotriz
{
    public partial class Login : Form
    {
        private const int EM_SETCUEBANNER = 0x1501;
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);
        public Login()
        {
            InitializeComponent();
            panelContenedor.BackColor = Color.FromArgb(125, Color.Black);
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
            Application.Exit();
        }
        private String password = Settings.Default.password;
        private void btnIngresar_Click(object sender, EventArgs e)
        {

            if (txtPassword.Text == password)
            {
                Principal principal = new Principal();
                this.Dispose();
                GC.Collect();
                principal.ShowDialog();
            }
            else
            {
                txtPassword.Clear();
                MensajeOK mensaje = new MensajeOK("Aviso", "Contraseña Incorrecta");
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

        private void Login_Load(object sender, EventArgs e)
        {
            btnMostrar.BringToFront();
            SendMessage(txtPassword.Handle, EM_SETCUEBANNER, 0, "Password");
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
