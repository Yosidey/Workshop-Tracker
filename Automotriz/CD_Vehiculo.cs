using System.Data;
using System.Data.SqlClient;

namespace Automotriz
{
    class CD_Vehiculo
    {
        public DataTable MostrarVehiculo()
        {
            CD_Conexion conexion = new CD_Conexion();
            SqlDataReader leer;
            DataTable tabla = new DataTable();
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "sp_listar_cliente_vehiculos";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            leer = null;
            return tabla;
        }

        public DataTable MostrarClienteCB()
        {
            CD_Conexion conexion = new CD_Conexion();
            SqlDataReader leer;
            DataTable tabla = new DataTable();
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "sp_combobox_clientes";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            leer = null;
            return tabla;
        }
        public DataTable MostrarEmpleadoCB()
        {
            CD_Conexion conexion = new CD_Conexion();
            SqlDataReader leer;
            DataTable tabla = new DataTable();
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "sp_combobox_empleados";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            leer = null;
            return tabla;
        }
        public DataTable MostrarVehciculosClienteCB(int IdCliente)
        {
            CD_Conexion conexion = new CD_Conexion();
            SqlDataReader leer;
            DataTable tabla = new DataTable();
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "sp_combobox_vehiculo_cliente";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@IdCliente", IdCliente);
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            leer = null;
            return tabla;
        }
        public void Operaciones(Datos datos)
        {
            CD_Conexion conexion = new CD_Conexion();
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "sp_operaciones_vehiculo";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@VehiculoId", datos.VehiculoId);
            comando.Parameters.AddWithValue("@ClienteId", datos.ClienteId);
            comando.Parameters.AddWithValue("@VMarca", datos.VMarca);
            comando.Parameters.AddWithValue("@VPlaca", datos.VPlaca);
            comando.Parameters.AddWithValue("@VModelo", datos.VModelo);
            comando.Parameters.AddWithValue("@VAño", datos.Vaño);
            comando.Parameters.AddWithValue("@VColor", datos.VColor);
            comando.Parameters.AddWithValue("@accion", datos.accion);
            comando.ExecuteNonQuery();
            conexion.CerrarConexion();
        }
    }
}
