using System;
using System.Windows.Forms;

namespace Automotriz
{
    public partial class MensajeOkCancel : Form
    {
        public MensajeOkCancel(String Titulo, String Mensaje)
        {
            InitializeComponent();
            this.Text = Titulo;
            txtMensaje.Text = Mensaje;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
