using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Automotriz
{
    public partial class txt : Form
    {


        private const int EM_SETCUEBANNER = 0x1501;
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);
        Cache cache = new Cache();
        int Fila = 0;

        public txt()
        {
            InitializeComponent();
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }
        private void Inicio_Load(object sender, EventArgs e)
        {
            CN_Servicios servicios = new CN_Servicios();
            cache.Tables.Add(servicios.MostrarServicioNuevos());
            cache.Tables.Add(servicios.MostrarServicioTerminados());

            dgvServiciosNuevos.DataSource = cache.Tables[0];
            dgvServiciosTerminados.DataSource = cache.Tables[1];

            dgvServiciosNuevos.Columns[0].HeaderText = ("IdServicio");
            dgvServiciosNuevos.Columns[1].HeaderText = ("IdCliente");
            dgvServiciosNuevos.Columns[2].HeaderText = ("IdEmpleado");
            dgvServiciosNuevos.Columns[3].HeaderText = ("IdVehiculo");
            dgvServiciosNuevos.Columns[4].HeaderText = ("Vehiculo");
            dgvServiciosNuevos.Columns[5].HeaderText = ("Precio");
            dgvServiciosNuevos.Columns[6].HeaderText = ("Descripcion");
            dgvServiciosNuevos.Columns[7].HeaderText = ("Comentario");
            dgvServiciosNuevos.Columns[8].HeaderText = ("Registro");
            dgvServiciosNuevos.Columns[0].Width = 80;
            dgvServiciosNuevos.Columns[1].Width = 70;
            dgvServiciosNuevos.Columns[2].Width = 90;
            dgvServiciosNuevos.Columns[3].Width = 85;
            dgvServiciosNuevos.Columns[8].Width = 89;
            dgvServiciosNuevos.Columns[5].Width = 79;

            dgvServiciosTerminados.Columns[0].HeaderText = ("Id Servicio");
            dgvServiciosTerminados.Columns[1].HeaderText = ("Vehiculo");
            dgvServiciosTerminados.Columns[2].HeaderText = ("Cliente");
            dgvServiciosTerminados.Columns[3].HeaderText = ("Telefono");
            dgvServiciosTerminados.Columns[4].HeaderText = ("Email");
            dgvServiciosTerminados.Columns[5].HeaderText = ("Descripcion");
            dgvServiciosTerminados.Columns[6].HeaderText = ("Precio");
            dgvServiciosTerminados.Columns[7].HeaderText = ("Registro");
            dgvServiciosTerminados.Columns[8].HeaderText = ("Terminado");
            dgvServiciosTerminados.Columns[0].Width = 94;
            dgvServiciosTerminados.Columns[1].Width = 98;
            dgvServiciosTerminados.Columns[6].Width = 69;
            dgvServiciosTerminados.Columns[7].Width = 89;
            dgvServiciosTerminados.Columns[8].Width = 89;
            rbIdServicioN.Checked = true;
            rbIdServicioT.Checked = true;

            SendMessage(txtBusqueNuevo.Handle, EM_SETCUEBANNER, 0, "Buscar Nuevo");
            SendMessage(txtServicioTerminado.Handle, EM_SETCUEBANNER, 0, "Buscar Terminado");
        }

        private void dgvServiciosNuevos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnRegistrar.Enabled = true;
            Fila = dgvServiciosNuevos.CurrentCell.RowIndex;

        }



        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            ChangeServicio editar = new ChangeServicio();
            editar.ServicioId = Convert.ToInt32(dgvServiciosNuevos[0, Fila].Value.ToString());
            editar.ClienteId = Convert.ToInt32(dgvServiciosNuevos[1, Fila].Value.ToString());
            editar.EmpleadoId = Convert.ToInt32(dgvServiciosNuevos[2, Fila].Value.ToString());
            editar.VehiculoId = Convert.ToInt32(dgvServiciosNuevos[3, Fila].Value.ToString());
            editar.txtPrecio.Text = dgvServiciosNuevos[5, Fila].Value.ToString();
            editar.txtDescripcion.Text = dgvServiciosNuevos[6, Fila].Value.ToString();
            editar.txtComentario.Text = dgvServiciosNuevos[7, Fila].Value.ToString();
            editar.lblRegistro.Text = "Registro:" + Convert.ToDateTime((dgvServiciosNuevos[8, Fila].Value.ToString())).ToString("dd/MM/yyyy");
            editar.lblRegistro.Visible = true;
            editar.accion = "2";
            editar.ShowDialog();
            cache.Tables.RemoveAt(0);
            cache.Tables.RemoveAt(0);
            btnRegistrar.Enabled = false;
            Inicio_Load(sender, e);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            btnRegistrar.Enabled = false;
            ChangeServicio nuevo = new ChangeServicio();
            nuevo.lblRegistro.Visible = false;
            nuevo.accion = "1";
            nuevo.ShowDialog();
            cache.Tables.RemoveAt(0);
            cache.Tables.RemoveAt(0);
            Inicio_Load(sender, e);
        }

        private void dgvServiciosNuevos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int idServicio = Convert.ToInt32(dgvServiciosNuevos[0, dgvServiciosNuevos.CurrentCell.RowIndex].Value.ToString());
            MensajeOkCancel confirmacion = new MensajeOkCancel("Confirmacion", $"¿Estas seguro que quieres terminar el servicio {idServicio}?");
            DialogResult result = confirmacion.ShowDialog();
            if (result == DialogResult.OK)
            {
                CN_Servicios servicios = new CN_Servicios();
                servicios.Actualizar(idServicio, "1");
                cache.Tables.RemoveAt(0);
                cache.Tables.RemoveAt(0);
                Inicio_Load(sender, e);
                btnRegistrar.Enabled = false;
                MensajeOK mensaje = new MensajeOK("Aviso", "¡Se termino el servicio de Id: " + idServicio + "!");
                mensaje.ShowDialog();
            }
        }

        private void dgvServiciosTerminados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnRegistrar.Enabled = false;
            MensajeOkCancel confirmacion = new MensajeOkCancel("Confirmacion", $"¿Estas seguro que quieres entregar el servicio {dgvServiciosTerminados[0, dgvServiciosTerminados.CurrentCell.RowIndex].Value.ToString()}?");
            DialogResult result = confirmacion.ShowDialog();
            if (result == DialogResult.OK)
            {
                CN_Servicios servicios = new CN_Servicios();
                int idServicio = Convert.ToInt32(dgvServiciosTerminados[0, dgvServiciosTerminados.CurrentCell.RowIndex].Value.ToString());

                servicios.Actualizar(idServicio, "2");
                cache.Tables.RemoveAt(0);
                cache.Tables.RemoveAt(0);
                Inicio_Load(sender, e);
                FromReporteServicio reporte = new FromReporteServicio(idServicio);
                reporte.ShowDialog();
                MensajeOK mensaje = new MensajeOK("Aviso", "¡Se Completo el servicio de Id: " + idServicio + "!");
                mensaje.ShowDialog();
            }
        }

        private void txtBusqueNuevo_TextChanged(object sender, EventArgs e)
        {
            String colname = "";
            if (rbIdServicioN.Checked == true)
            {
                colname = "ServicioId";
            }
            if (rbIdClienteN.Checked == true)
            {
                colname = "ClienteId";
            }
            if (rbIdEmpleadoN.Checked == true)
            {
                colname = "EmpleadoId";
            }
            if (rbIdVehiculoN.Checked == true)
            {
                colname = "VehiculoId";
            }

            cache.Tables[0].DefaultView.RowFilter = "CONVERT(" + colname + ", System.String) like '" + txtBusqueNuevo.Text + "%'";
            dgvServiciosNuevos.DataSource = cache.Tables[0].DefaultView;
        }

        private void rbIdServicio_CheckedChanged(object sender, EventArgs e)
        {
            txtBusqueNuevo_TextChanged(sender, e);
        }

        private void txtServicioTerminado_TextChanged(object sender, EventArgs e)
        {
            String colname = "";
            if (rbIdServicioT.Checked == true)
            {
                colname = "ServicioId";
            }
            if (rbClienteT.Checked == true)
            {
                colname = "nombreCompleto";
            }
            if (rbVehiculoT.Checked == true)
            {
                colname = "MarcaVehiculo";
            }
            cache.Tables[1].DefaultView.RowFilter = "CONVERT(" + colname + ", System.String) like '" + txtServicioTerminado.Text + "%'";
            dgvServiciosTerminados.DataSource = cache.Tables[1].DefaultView;
        }

        private void rbIdServicioT_CheckedChanged(object sender, EventArgs e)
        {
            txtServicioTerminado_TextChanged(sender, e);
        }

        private void txt_Click(object sender, EventArgs e)
        {
            btnRegistrar.Enabled = false;
        }
    }
}
