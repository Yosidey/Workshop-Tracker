using System.Data;

namespace Automotriz
{
    class CN_Empleados
    {
        private CD_Empleados empleado = new CD_Empleados();

        public DataTable MostrarEmpleado()
        {
            DataTable tabla = new DataTable();
            tabla = empleado.Mostrar();
            return tabla;
        }
        public void CN_Operaciones(Datos datos)
        {
            empleado.Operaciones(datos);
        }
        public void CN_Activar_Empleo(Datos datos)
        {
            empleado.Activar(datos);
        }
        public void CN_Desactivar_Empleo(Datos datos)
        {
            empleado.Desactivar(datos);
        }
        public int ConsultarServicio(int EmpleadoId)
        {
            int registros = empleado.ConsultarServicioActivo(EmpleadoId);
            return registros;
        }
    }
}
