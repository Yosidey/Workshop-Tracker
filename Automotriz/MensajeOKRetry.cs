using System;
using System.Windows.Forms;

namespace Automotriz
{
    public partial class MensajeOKRetry : Form
    {
        public MensajeOKRetry(String Titulo, String Mensaje)
        {
            InitializeComponent();
            this.Text = Titulo;
            txtMensaje.Text = Mensaje;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnRetry_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Retry;
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
        }
    }
}
