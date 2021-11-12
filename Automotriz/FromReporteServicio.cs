using System;
using System.Windows.Forms;

namespace Automotriz
{
    public partial class FromReporteServicio : Form
    {
        int idServicio;

        public FromReporteServicio(int idServicio)
        {
            this.idServicio = idServicio;
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            CrystalReportService data = new CrystalReportService();
            CN_Servicios servicio = new CN_Servicios();
            data.SetDataSource(servicio.ReporteServicioId(idServicio));
            crystalReportViewer1.ReportSource = data;
            //crystalReportViewer1.RefreshReport();
            crystalReportViewer1.EnableRefresh = true;
            crystalReportViewer1.ShowCopyButton = false;
            crystalReportViewer1.ShowGroupTreeButton = false;
            crystalReportViewer1.ShowExportButton = false;
            crystalReportViewer1.ShowPageNavigateButtons = false;
            crystalReportViewer1.ShowParameterPanelButton = false;


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

        private void Otro_Load(object sender, EventArgs e)
        {
            crystalReportViewer1.PrintReport();
        }
    }
}
