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
    public partial class frmTKDTNhanVien : Form
    {
        private string manhanvien = "";
        BU_NhanVien dtnv = new BU_NhanVien();
        public frmTKDTNhanVien(string manv)
        {
            InitializeComponent();
            manhanvien = manv;
        }

        private void frmTKDTNhanVien_Load(object sender, EventArgs e)
        {
            CrystalReportTKDTNV report = new CrystalReportTKDTNV();

            report.SetDataSource(dtnv.GetDoanhThu(manhanvien));
            ReportViewerDTNV.ReportSource = report;
            ReportViewerDTNV.Refresh();
        }
    }
}
