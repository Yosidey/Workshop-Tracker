using System;
using System.Data;
using System.Data.SqlClient;

namespace Automotriz
{
    class CD_Empleados
    {
        public DataTable Mostrar()
        {
            CD_Conexion conexion = new CD_Conexion();
            SqlDataReader leer;
            DataTable tabla = new DataTable();
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "sp_listar_empleado";
            comando.CommandType = CommandType.StoredProcedure;
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
            comando.CommandText = "sp_operaciones_empleado";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@EmpleadoId", datos.EmpleadoId);
            comando.Parameters.AddWithValue("@ENombre", datos.ENombre);
            comando.Parameters.AddWithValue("@EApellidos", datos.EApellidos);
            comando.Parameters.AddWithValue("@ETelefono", datos.ETelefono);
            comando.Parameters.AddWithValue("@EEmail", datos.EEmail);
            comando.Parameters.AddWithValue("@EDireccion", datos.EDomicilio);
            comando.Parameters.AddWithValue("@accion", datos.accion);
            comando.ExecuteNonQuery();
            conexion.CerrarConexion();
        }
        public void Desactivar(Datos datos)
        {
            CD_Conexion conexion = new CD_Conexion();
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "sp_fecha_desactivar_empleado";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@EmpleadoId", datos.EmpleadoId);
            comando.ExecuteNonQuery();
            conexion.CerrarConexion();
        }
        public void Activar(Datos datos)
        {
            CD_Conexion conexion = new CD_Conexion();
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "sp_fecha_activar_empleado";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@EmpleadoId", datos.EmpleadoId);
            comando.ExecuteNonQuery();
            conexion.CerrarConexion();
        }
        public int ConsultarServicioActivo(int EmpleadoId)
        {
            CD_Conexion conexion = new CD_Conexion();
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "sp_ValidarEmpleado";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@EmpleadoId", EmpleadoId);
            return Convert.ToInt32(comando.ExecuteScalar().ToString());
        }
    }
}
