using System;
using System.Windows.Forms;

namespace Automotriz
{
    public partial class MensajeOK : Form
    {

        public MensajeOK(String Titulo, String Mensaje)
        {
            InitializeComponent();
            this.Text = Titulo;
            txtMensaje.Text = Mensaje;

        }


        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
