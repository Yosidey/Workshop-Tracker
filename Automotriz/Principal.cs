using System;
using System.Windows.Forms;

namespace Automotriz
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }
        private void Principal_Load(object sender, EventArgs e)
        {
            //Cache cache1 = new Cache();

            Ejecutar(new txt());

        }



  


        private void btnInicio_Click(object sender, EventArgs e)
        {
            Ejecutar(new txt());
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            Ejecutar(new Clientes());
        }
        private void btnVehiculos_Click(object sender, EventArgs e)
        {
            Ejecutar(new Vehiculos());
        }
        private void btnRegistros_Click(object sender, EventArgs e)
        {
            Ejecutar(new Registros());
        }
        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            Ejecutar(new Empleados());
        }
        private void Ejecutar(Object from)
        {
            if (this.PanelContenedor.Controls.Count > 0)
                this.PanelContenedor.Controls.RemoveAt(0);
            Form f = from as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.PanelContenedor.Controls.Add(f);
            this.PanelContenedor.Tag = f;
            f.Show();

        }


        private void tmFechaHora_Tick(object sender, EventArgs e)
        {
            lbFecha.Text = DateTime.Now.ToString("dd-MM-yyyy");
            lblHora.Text = DateTime.Now.ToString("hh:mm:tt");
        }

        private void btnCerrarSeccion_Click(object sender, EventArgs e)
        {

            Login login = new Login();
            this.Dispose();
            login.ShowDialog();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {

            ChangePassword change = new ChangePassword();

            change.ShowDialog();

        }

        private void Principal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnSettingConnection_Click(object sender, EventArgs e)
        {
            SettingsConnection settings = new SettingsConnection();
            settings.ShowDialog();
        }
    }
}
