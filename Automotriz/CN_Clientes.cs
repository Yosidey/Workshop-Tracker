using System.Data;

namespace Automotriz
{
    class CN_Clientes
    {
        private CD_Clientes cliente = new CD_Clientes();

        public DataTable MostrarCliente()
        {
            DataTable tabla = new DataTable();
            tabla = cliente.Mostrar();
            return tabla;
        }
        public DataTable BuscarCliente(int ClienteId)
        {
            DataTable tabla = new DataTable();
            tabla = cliente.BuscarCliente(ClienteId);
            return tabla;
        }
        public void CN_Operaciones(Datos datos)
        {
            cliente.Operaciones(datos);
        }
    }
}
