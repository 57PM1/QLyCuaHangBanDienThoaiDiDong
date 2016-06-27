using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business;
namespace Mobile
{
    public partial class frmInHDB : Form
    {
        private string mahoadon = "";
        BU_HDB ct_hoadon = new BU_HDB();
        public frmInHDB(string mahd)
        {
            InitializeComponent();
            mahoadon = mahd;

        }

        private void frmInHDB_Load(object sender, EventArgs e)
        {
            CrystalReportHDB report = new CrystalReportHDB();

            report.SetDataSource(ct_hoadon.GetTTHoaDon(mahoadon));
            crvHDB.ReportSource = report;
            crvHDB.Refresh();
        }
    }
}
