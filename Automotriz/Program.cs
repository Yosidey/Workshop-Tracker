using System;
using System.Windows.Forms;

namespace Automotriz
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Welcome welcome = new Welcome();
            Application.Run(new Welcome());
            //Application.Run(new Principal());
            //Application.Run(new SettingsConnection());
            //Application.Run(new Clientes());
            //Application.Run(new FromReporteServicio(255));

        }
    }
}
