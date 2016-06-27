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
using EntityClass;

namespace Mobile
{
    public partial class frmCTHDN : Form
    {
        frmHDN tg;
        public frmCTHDN(frmHDN f, String mahdn)
        {
            InitializeComponent();

            txtMaHDN.Text = mahdn;
            tg = f;
        }

        BU_CTHDN thucthi = new BU_CTHDN();
        public void loadData()
        {
            dataGridView1.DataSource = thucthi.getAll(txtMaHDN.Text);
        }

        private void frmCTHDN_Load(object sender, EventArgs e)
        {
            BU_SanPham sp = new BU_SanPham();
            cbsanpham.DataSource = sp.getAll();
            cbsanpham.DisplayMember = "TENSP";
            cbsanpham.ValueMember = "MASP";
            loadData();

            DataTable tb = sp.tkMa(cbsanpham.SelectedValue.ToString());
            foreach (DataRow row in tb.Rows)
            {
                txtdg.Text = row["DONGIABAN"].ToString();
            }
        }

        private void btmoi_Click(object sender, EventArgs e)
        {
            txtsl.Text = "";
            txtdg.Text = "";
            txttt.Text = "";
            cbsanpham.Text = "";
        }

        private void btluu_Click(object sender, EventArgs e)
        {
            EC_CTHDN hdn = new EC_CTHDN();

            hdn.MaHDN = txtMaHDN.Text;
            hdn.MaSP = cbsanpham.SelectedValue.ToString();
            if (txtdg.Text != "") hdn.DonGia = float.Parse(txtdg.Text);
            hdn.SoLuong = Int32.Parse(txtsl.Text);
            if (txttt.Text != "") hdn.ThanhTien = float.Parse(txttt.Text);
            if (thucthi.insertCTHDN(hdn))
            {
                MessageBox.Show("Thêm thành công");
                loadData();

            }
            else
            {
                MessageBox.Show("Thêm thất bại");
            }
        }

        private void btsua_Click(object sender, EventArgs e)
        {
            EC_CTHDN hdn = new EC_CTHDN();

            hdn.MaHDN = txtMaHDN.Text;
            hdn.MaSP = cbsanpham.SelectedValue.ToString();
            if (txtdg.Text != "") hdn.DonGia = float.Parse(txtdg.Text);
            hdn.SoLuong = Int32.Parse(txtsl.Text);
            if (txttt.Text != "") hdn.ThanhTien = float.Parse(txttt.Text);
            if (thucthi.updateCTHDN(hdn))
            {
                MessageBox.Show("Sửa thành công");
                loadData();

            }
            else
            {
                MessageBox.Show("Sửa thất bại");
            }
        }

        private void btxoa_Click(object sender, EventArgs e)
        {
            EC_CTHDN hdn = new EC_CTHDN();

            hdn.MaHDN = txtMaHDN.Text;
            hdn.MaSP = cbsanpham.SelectedValue.ToString();

            if (thucthi.deleteCTHDN(hdn))
            {
                MessageBox.Show("Xóa thành công");
                loadData();

            }
            else
            {
                MessageBox.Show("Xóa thất bại");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                var row = dataGridView1.Rows[e.RowIndex];
                cbsanpham.SelectedValue = row.Cells[1].Value.ToString();
                txtsl.Text = row.Cells[2].Value.ToString();
                txtdg.Text = row.Cells[3].Value.ToString();
                // txttt.Text = row.Cells[3].Value.ToString();
            }
        }

        private void frmCTHDN_FormClosed(object sender, FormClosedEventArgs e)
        {
            float thanhtien = 0;
            DataTable tb = thucthi.getAll(txtMaHDN.Text);
            foreach (DataRow row in tb.Rows)
            {
                thanhtien += float.Parse(row["THANHTIEN"].ToString());
            }
            tg.UpdateThanhTien(thanhtien);
        }

        private void txtdg_TextChanged(object sender, EventArgs e)
        {
            if (txtsl.Text != "")
            {
                txttt.Text = (Int32.Parse(txtsl.Text) * float.Parse(txtdg.Text)).ToString();
            }
        }

        private void txtsl_TextChanged(object sender, EventArgs e)
        {
            if (txtsl.Text != "" && txtdg.Text != "")
            {
                txttt.Text = (Int32.Parse(txtsl.Text) * float.Parse(txtdg.Text)).ToString();
            }
        }

        private void cbsanpham_SelectedIndexChanged(object sender, EventArgs e)
        {
            BU_CTHDN nhap = new BU_CTHDN();
        }

        private void cbsanpham_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            frmInHDN report = new frmInHDN(txtMaHDN.Text);
            report.Show();
        }
    }
}
