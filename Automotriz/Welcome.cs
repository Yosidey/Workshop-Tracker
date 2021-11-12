using Automotriz.Properties;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Automotriz
{
    public partial class Welcome : Form
    {
        private static String Servidor = "";
        private static String Usuario = "";
        private static String Contraseña = "";
        private static String BaseDatos = "";
        private SqlConnection Conexion=null;
        //CD_Conexion Conexion = new CD_Conexion();
        private Boolean sql = false;
      
        public Welcome()
        {
            InitializeComponent();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.Opacity < 1)
            {
                this.Opacity += 0.05;
            }
            if (circularProgressBar1.Value < 100 && circularProgressBar1.Value % 2 == 0)
            {
                circularProgressBar1.Value += 2;
                circularProgressBar1.Text = circularProgressBar1.Value.ToString();
            }

            if (circularProgressBar1.Value == 30)
            {
                try
                {
                    Refresh();
                    Conexion.Open();
                    Conexion.Close();
                    Conexion = null;
                    sql = true;
                }
                catch (SqlException ex)
                {

                    MensajeOKRetry mensaje = new MensajeOKRetry("Cerrando aplicación", "Error al conectar con el servidor");
                    DialogResult dialogResult = mensaje.ShowDialog();
                    Console.WriteLine(ex.Message);
                    if (dialogResult == DialogResult.OK)
                    {
                        Application.Exit();
                    }
                    if (dialogResult == DialogResult.Retry)
                    {
                        timer1.Start();
                        circularProgressBar1.Value = 0;
                        circularProgressBar1.Minimum = 0;
                        circularProgressBar1.Maximum = 100;
                        timer1.Start();
                    }
                    if (dialogResult == DialogResult.Yes)
                    {
                        SettingsConnection settings = new SettingsConnection();
                        settings.ShowDialog();
                        timer1.Start();
                        circularProgressBar1.Value = 0;
                        circularProgressBar1.Minimum = 0;
                        circularProgressBar1.Maximum = 100;
                        timer1.Start();
                    }
                    sql = false;

                }
            }
            if (circularProgressBar1.Value == 100 && sql)
            {
                timer1.Stop();
                timer2.Start();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            this.Opacity -= 0.1;
            if (this.Opacity == 0)
            {
                timer2.Stop();
                this.Hide();
                Login login = new Login();
                GC.Collect();
                login.Show();
            }
        }
        public void Refresh()
        {
            Servidor = Settings.Default.Servidor;
            Usuario = Settings.Default.Usuario;
            Contraseña = Settings.Default.Contraseña;
            BaseDatos = Settings.Default.BaseDatos;
            Conexion = new SqlConnection($"Data Source={Servidor}; Initial Catalog={BaseDatos};User ID={Usuario};Password={Contraseña};Integrated Security=True;Connection Timeout=10");
        }

        private void Welcome_Load(object sender, EventArgs e)
        {
            this.Opacity = 0.0;
            circularProgressBar1.Value = 0;
            circularProgressBar1.Minimum = 0;
            circularProgressBar1.Maximum = 100;
            timer1.Start();
        }
    }
}
