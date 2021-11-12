using System;
using System.Data;
using System.Data.SqlClient;

namespace Automotriz
{
    class CD_Servicios
    {
        public DataTable Mostrar()
        {
            CD_Conexion conexion = new CD_Conexion();
            SqlDataReader leer;
            DataTable tabla = new DataTable();
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "sp_listar_servicios_completado";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            leer = null;
            return tabla;
        }
        public DataTable MostrarNuevos()
        {
            CD_Conexion conexion = new CD_Conexion();
            SqlDataReader leer;
            DataTable tabla = new DataTable();
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "sp_listar_servicios_Nuevos";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            leer = null;
            return tabla;
        }
        public DataTable MostrarTerminados()
        {
            CD_Conexion conexion = new CD_Conexion();
            SqlDataReader leer;
            DataTable tabla = new DataTable();
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "sp_listar_servicios_Terminados";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            leer = null;
            return tabla;
        }
        public DataTable ReporteServicioId(int ServicioId)
        {
            CD_Conexion conexion = new CD_Conexion();
            SqlDataReader leer;
            DataTable tabla = new DataTable();
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "sp_servicio";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@ServicioIdBuscar", ServicioId);
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
            comando.CommandText = "sp_operaciones_servicio";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@ServicioId", datos.ServicioId);
            comando.Parameters.AddWithValue("@VehiculoId", datos.VehiculoId);
            comando.Parameters.AddWithValue("@EmpleadoId", datos.EmpleadoId);
            comando.Parameters.AddWithValue("@SDescripcion", datos.SDescripcion);
            comando.Parameters.AddWithValue("@SComentario", datos.SComentario);
            comando.Parameters.AddWithValue("@SPrecio", datos.SPrecio);
            comando.Parameters.AddWithValue("@accion", datos.accion);
            comando.ExecuteNonQuery();
            conexion.CerrarConexion();
        }
        public void Actualizar(int ServicioId, String accion)
        {
            CD_Conexion conexion = new CD_Conexion();
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "sp_servicio_actualizar";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@ServicioId", ServicioId);
            comando.Parameters.AddWithValue("@accion", accion);
            comando.ExecuteNonQuery();
            conexion.CerrarConexion();
        }
    }
}
