using System.Data;
using System.Data.SqlClient;

namespace Automotriz
{
    class CD_Clientes
    {
        public DataTable Mostrar()
        {
            CD_Conexion conexion = new CD_Conexion();
            SqlDataReader leer;
            DataTable tabla = new DataTable();
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "sp_listar_clientes";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            leer = null;
            return tabla;
        }

        public DataTable BuscarCliente(int ClienteId)
        {
            CD_Conexion conexion = new CD_Conexion();
            SqlDataReader leer;
            DataTable tabla = new DataTable();
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "sp_buscar_cliente";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@ClienteId", ClienteId);
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
            comando.CommandText = "sp_operaciones_cliente";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@ClienteId", datos.ClienteId);
            comando.Parameters.AddWithValue("@CNombre", datos.CNombre);
            comando.Parameters.AddWithValue("@CApellidos", datos.CApellidos);
            comando.Parameters.AddWithValue("@CTelefono", datos.CTelefono);
            comando.Parameters.AddWithValue("@CEmail", datos.CEmail);
            comando.Parameters.AddWithValue("@CDireccion", datos.CDomicilio);
            comando.Parameters.AddWithValue("@accion", datos.accion);
            comando.ExecuteNonQuery();
            conexion.CerrarConexion();
        }
    }
}
