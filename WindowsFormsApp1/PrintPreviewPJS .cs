using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class PrintPreviewPJS : Form
    {
        public PrintPreviewPJS (string outorgantecpf, string outorgantelogra, string outorgantebairro, string outorgantecep, string outorgantecidade,
        string outorganteestado, string outorganterg, string outorganteexped, string outorganteexpdata, string outorgantenacional, string outorgantenome,
        string outorganteempresa, string outorgantecnpj, string outorgantelogcom, string outorgantebairrocom, string outorgantecepcom, 
        string outorgantecidadecom, string outorganteufcom, string dataatual)
        {
            InitializeComponent();

            reportViewer3.LocalReport.DataSources.Clear();
            reportViewer3.LocalReport.ReportEmbeddedResource = "WindowsFormsApp1.ProcPJS.rdlc";
            Microsoft.Reporting.WinForms.ReportParameter[] p = new Microsoft.Reporting.WinForms.ReportParameter[19];

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
            p[11] = new Microsoft.Reporting.WinForms.ReportParameter("outorganteempresa", outorganteempresa);
            p[12] = new Microsoft.Reporting.WinForms.ReportParameter("outorgantecnpj", outorgantecnpj);
            p[13] = new Microsoft.Reporting.WinForms.ReportParameter("outorgantelogcom", outorgantelogcom);
            p[14] = new Microsoft.Reporting.WinForms.ReportParameter("outorgantebairrocom", outorgantebairrocom);
            p[15] = new Microsoft.Reporting.WinForms.ReportParameter("outorgantecepcom", outorgantecepcom);
            p[16] = new Microsoft.Reporting.WinForms.ReportParameter("outorgantecidadecom", outorgantecidadecom);
            p[17] = new Microsoft.Reporting.WinForms.ReportParameter("outorganteufcom", outorganteufcom);
            p[18] = new Microsoft.Reporting.WinForms.ReportParameter("dataatual", dataatual);

            reportViewer3.LocalReport.SetParameters(p);
            reportViewer3.LocalReport.Refresh();
            reportViewer3.RefreshReport();
        }

        public static DataSet DataSource { get; internal set; }

        private void reportViewer2_Load(object sender, EventArgs e)
        {

        }

        private void reportViewer2_Load_1(object sender, EventArgs e)
        {

        }
    }
}