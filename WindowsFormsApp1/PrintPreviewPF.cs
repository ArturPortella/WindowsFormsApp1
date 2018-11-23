using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrintPF
{
    public partial class PrintPreviewPF : Form
    {
        public PrintPreviewPF(string outorgantecpf, string outorgantelogra, string outorgantebairro, string outorgantecep, string outorgantecidade,
            string outorganteestado, string outorganterg, string outorganteexped, string outorganteexpdata, string outorgantenacional, string outorgantenome, string dataatual)
        {
            InitializeComponent();

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.ReportEmbeddedResource = "WindowsFormsApp1.ProcPF.rdlc";
            Microsoft.Reporting.WinForms.ReportParameter[] p = new Microsoft.Reporting.WinForms.ReportParameter[12];

            p[0] = new Microsoft.Reporting.WinForms.ReportParameter("outorgantecpf", outorgantecpf);
            p[1] = new Microsoft.Reporting.WinForms.ReportParameter("outorgantelogra", outorgantelogra);
            p[2] = new Microsoft.Reporting.WinForms.ReportParameter("outorgantebairro", outorgantebairro);
            p[3] = new Microsoft.Reporting.WinForms.ReportParameter("outorgantecep", outorgantecep);
            p[4] = new Microsoft.Reporting.WinForms.ReportParameter("outorgantecidade", outorgantecidade);
            p[5] = new Microsoft.Reporting.WinForms.ReportParameter("outorganteestado", outorganteestado);
            p[6] = new Microsoft.Reporting.WinForms.ReportParameter("outorganterg", outorganterg);
            p[7] = new Microsoft.Reporting.WinForms.ReportParameter("outorganteexped", outorganteexped);
            p[8] = new Microsoft.Reporting.WinForms.ReportParameter("outorganteexpdata", outorganteexpdata);
            p[9] = new Microsoft.Reporting.WinForms.ReportParameter("outorgantenacional", outorgantenacional);
            p[10] = new Microsoft.Reporting.WinForms.ReportParameter("outorgantenome", outorgantenome);
            p[11] = new Microsoft.Reporting.WinForms.ReportParameter("dataatual", dataatual);

            reportViewer1.LocalReport.SetParameters(p);
            reportViewer1.LocalReport.Refresh();
            reportViewer1.RefreshReport();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
