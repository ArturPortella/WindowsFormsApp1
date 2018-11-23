using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace WindowsFormsApp1
{
    public partial class PreviewReq : Form
    {
        private DataSet DocDB;
        public DataSet DataSource
        {
            set
            {
                DocDB = value;
            }
            get
            {
                return DocDB;
            }
        }
    
        public PreviewReq (string outorganteemail, string outorgantecr, string outorgantecpf, string outorgantelogra, string outorgantebairro, string outorgantecep, string outorgantecidade,
        string outorganteestado, string outorganterg, string outorganteexped, string outorganteexpdata, string outorgantenacional, string outorgantenome,
        string outorganteempresa, string outorgantecnpj, string outorgantelogcom, string outorgantebairrocom, string outorgantecepcom,
        string outorgantecidadecom, string outorganteufcom, string dataatual, string cr, string rr, string ar, string canc, string segvia, string pessoa) 
        {
            InitializeComponent();
            reportViewer4.LocalReport.ReportEmbeddedResource = "WindowsFormsApp1.ReqPJS.rdlc";
            Microsoft.Reporting.WinForms.ReportParameter[] p = new Microsoft.Reporting.WinForms.ReportParameter[27];
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
            p[19] = new Microsoft.Reporting.WinForms.ReportParameter("cr", cr);
            p[20] = new Microsoft.Reporting.WinForms.ReportParameter("rr", rr);
            p[21] = new Microsoft.Reporting.WinForms.ReportParameter("ar", ar);
            p[22] = new Microsoft.Reporting.WinForms.ReportParameter("canc", canc);
            p[23] = new Microsoft.Reporting.WinForms.ReportParameter("segvia", segvia);
            p[24] = new Microsoft.Reporting.WinForms.ReportParameter("outorganteemail", outorganteemail);
            p[25] = new Microsoft.Reporting.WinForms.ReportParameter("outorgantecr", outorgantecr);
            p[26] = new Microsoft.Reporting.WinForms.ReportParameter("pessoa", pessoa);

            reportViewer4.LocalReport.SetParameters(p);
        }

        private void Form4_Load(object sender, EventArgs e)
        {
        }
        private void reportViewer4_Load(object sender, EventArgs e)
        {
        }

        private void PreviewReq_Load(object sender, EventArgs e)
        {
            //((ISupportInitialize)bindingSource1).BeginInit();
            //bindingSource1.DataMember = DocDB.Tables["Docs"].TableName;
            //bindingSource1.DataSource = DocDB;
            //var reportDataSource1 = new ReportDataSource("Docs", DocDB.Tables["Docs"]);
            //this.reportViewer4.LocalReport.DataSources.Add(reportDataSource1);
            CopiaDataSet copiaDS = new CopiaDataSet();]

            this.copiaDS.Tables["Docs"].Add(DocDB.Tables["Docs"]);
            this.reportViewer4.LocalReport.Refresh();
            this.reportViewer4.RefreshReport();
        }
    }
}