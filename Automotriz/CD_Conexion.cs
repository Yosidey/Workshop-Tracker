using Automotriz.Properties;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Automotriz
{
    class CD_Conexion
    {
        private static String Servidor = "";
        private static String Usuario = "";
        private static String Contraseña = "";
        private static String BaseDatos = "";
        public SqlConnection Conexion = null;

        public SqlConnection AbrirConexion()
        {
            Refresh();
            try
            {
                if (Conexion.State == ConnectionState.Closed)
                    Conexion.Open();
                //MessageBox.Show("Inicio la Conexion establecida con el servidor");
                return Conexion;
            }
            catch (SqlException ex)
            {
                MensajeOK mensaje = new MensajeOK(ex.Message, "Error al conectar con el servidor");
               mensaje.ShowDialog();
                return null;
            }

        }
        public SqlConnection CerrarConexion()
        {
            if (Conexion.State == ConnectionState.Open)
            {
                Conexion.Close();
                ///MessageBox.Show("Finalizo la Conexion establecida con el servidor");
                return Conexion;
            }
            else
            {
                MessageBox.Show("No se encontro una conexion con el servidor ");
                return null;
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
        public Boolean IsConnection()
        {
            Refresh();
            {
                try
                {
                    if (Conexion.State == ConnectionState.Closed)
                    {
                        Conexion.Open();
                        Conexion.Close();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    return false;
                }


            }
        }
    }
}
