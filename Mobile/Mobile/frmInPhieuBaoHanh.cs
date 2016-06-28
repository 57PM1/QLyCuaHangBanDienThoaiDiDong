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
    public partial class frmInPhieuBaoHanh : Form
    {
        private string mabaohanh = "";
        BU_BaoHanh phieubaohanh = new BU_BaoHanh();
        public frmInPhieuBaoHanh(string mabh)
        {
            InitializeComponent();
            mabaohanh = mabh;
        }

        private void frmInPhieuBaoHanh_Load(object sender, EventArgs e)
        {
            CrystalReportPhieuBH report = new CrystalReportPhieuBH();

            report.SetDataSource(phieubaohanh.GetMaBH(mabaohanh));
            crvPhieuBaoHanh.ReportSource = report;
            crvPhieuBaoHanh.Refresh();
        }
    }
}
