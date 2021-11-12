using System.Data;

namespace Automotriz
{
    class CN_Vehiculos
    {
        private CD_Vehiculo vehiculo = new CD_Vehiculo();

        public DataTable MostrarVehiculo()
        {
            DataTable tabla = new DataTable();
            tabla = vehiculo.MostrarVehiculo();
            return tabla;
        }
        public DataTable MostrarClienteCB()
        {
            DataTable tabla = new DataTable();
            tabla = vehiculo.MostrarClienteCB();
            return tabla;
        }
        public DataTable MostrarEmpleadoCB()
        {
            DataTable tabla = new DataTable();
            tabla = vehiculo.MostrarEmpleadoCB();
            return tabla;
        }
        public DataTable MostrarVehciculosClienteCB(int IdCliente)
        {
            DataTable tabla = new DataTable();
            tabla = vehiculo.MostrarVehciculosClienteCB(IdCliente);
            return tabla;
        }
        public void CN_Operaciones(Datos datos)
        {
            vehiculo.Operaciones(datos);
        }

    }
}
