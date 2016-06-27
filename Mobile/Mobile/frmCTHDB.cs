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
    public partial class frmCTHDB : Form
    {
        frmHDB tg;
        public frmCTHDB(string mahdb, frmHDB f)
        {
            InitializeComponent();
            txtMaHDB.Text = mahdb;
            tg = f;
        }
        BU_CTHDB thucthi = new BU_CTHDB();

        private void frmCTHDB_Load(object sender, EventArgs e)
        {
            loaddata();
            BU_SanPham sp = new BU_SanPham();
            cbxMaHang.DataSource = sp.getAll();
            cbxMaHang.DisplayMember = "TENSP";
            cbxMaHang.ValueMember = "MASP";

            DataTable tb = sp.tkMa(cbxMaHang.SelectedValue.ToString());
            foreach (DataRow row in tb.Rows)
            {
                txtDonGia.Text = row["DONGIABAN"].ToString();
            }
        }
        public void loaddata()
        {
            DataTable tb = thucthi.getAll(txtMaHDB.Text);
            dgvCTHDB.DataSource = tb;
            float tong = 0;
            foreach (DataRow row in tb.Rows)
            {
                tong += float.Parse(row["THANHTIEN"].ToString());
            }
            tg.taidulieu(tong);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtSoLuong.Text = "";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtSoLuong.Text != "")
            {
                EC_CTHDB ban = new EC_CTHDB();
                ban.MaHDB = txtMaHDB.Text;
                ban.MaSP = cbxMaHang.SelectedValue.ToString();
                if (txtSoLuong.Text != "") ban.SoLuong = Int32.Parse(txtSoLuong.Text);
                if (txtDonGia.Text != "") ban.DonGia = float.Parse(txtDonGia.Text);
                if (txtThanhtien.Text != "") ban.thanhTien = float.Parse(txtThanhtien.Text);
                if (thucthi.insertCTHDB(ban))
                {
                    MessageBox.Show("Thêm thành công");
                    loaddata();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại");
                }
            }
            else
            {
                MessageBox.Show("Bạn phải nhập số lượng");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtSoLuong.Text != "")
            {
                EC_CTHDB ban = new EC_CTHDB();
                ban.MaHDB = txtMaHDB.Text;
                ban.MaSP = cbxMaHang.SelectedValue.ToString();
                if (txtSoLuong.Text != "") ban.SoLuong = Int32.Parse(txtSoLuong.Text);
                if (txtDonGia.Text != "") ban.DonGia = float.Parse(txtDonGia.Text);
                if (txtThanhtien.Text != "") ban.thanhTien = float.Parse(txtThanhtien.Text);
                if (thucthi.updateCTHDB(ban))
                {
                    MessageBox.Show("Sửa thành công");
                    loaddata();
                }
                else
                {
                    MessageBox.Show("Sửa thất bại");
                }
            }
            else
            {
                MessageBox.Show("Bạn phải nhập số lượng");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            EC_CTHDB ban = new EC_CTHDB();
            ban.MaHDB = txtMaHDB.Text;
            ban.MaSP = cbxMaHang.SelectedValue.ToString();

            if (thucthi.deleteCTHDB(ban))
            {
                MessageBox.Show("Xóa thành công");
                loaddata();
            }
            else
            {
                MessageBox.Show("Xóa thất bại");
            }

        }

        private void dgvCTHDB_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                var row = dgvCTHDB.Rows[e.RowIndex];
                txtMaHDB.Text = row.Cells[0].Value.ToString();
                cbxMaHang.SelectedValue = row.Cells[1].Value.ToString();
                txtSoLuong.Text = row.Cells[2].Value.ToString();
                txtDonGia.Text = row.Cells[3].Value.ToString();
                txtThanhtien.Text = row.Cells[4].Value.ToString();
            }
        }

        private void cbxMaHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            BU_SanPham sp = new BU_SanPham();
            DataTable tb = sp.tkMa(cbxMaHang.SelectedValue.ToString());
            foreach (DataRow row in tb.Rows)
            {
                txtDonGia.Text = row["DONGIABAN"].ToString();
            }
        }

        private void txtDonGia_TextChanged(object sender, EventArgs e)
        {
            if (txtSoLuong.Text != "")
            {
                txtThanhtien.Text = (Int32.Parse(txtSoLuong.Text) * float.Parse(txtDonGia.Text)).ToString();
            }
        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            if (txtSoLuong.Text != "")
            {
                txtThanhtien.Text = (Int32.Parse(txtSoLuong.Text) * float.Parse(txtDonGia.Text)).ToString();
            }
        }

        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            frmInHDB report = new frmInHDB(txtMaHDB.Text);
            report.Show();
        }
    }
}
