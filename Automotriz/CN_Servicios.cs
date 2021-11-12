using System;
using System.Data;

namespace Automotriz
{
    class CN_Servicios
    {
        private CD_Servicios servicio = new CD_Servicios();

        public DataTable MostrarServicio()
        {
            DataTable tabla = new DataTable();
            tabla = servicio.Mostrar();
            return tabla;
        }
        public DataTable MostrarServicioNuevos()
        {
            DataTable tabla = new DataTable();
            tabla = servicio.MostrarNuevos();
            return tabla;
        }
        public DataTable MostrarServicioTerminados()
        {
            DataTable tabla = new DataTable();
            tabla = servicio.MostrarTerminados();
            return tabla;
        }

        public void CN_Operaciones(Datos datos)
        {
            servicio.Operaciones(datos);
        }
        public void Actualizar(int ServicioId, String accion)
        {
            servicio.Actualizar(ServicioId, accion);
        }
        public DataTable ReporteServicioId(int ServicioId)
        {
            DataTable tabla = new DataTable();
            tabla = servicio.ReporteServicioId(ServicioId);
            return tabla;
        }
    }
}
