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
    public partial class frmHDB : Form
    {
        string manv;
        public frmHDB(string manv)
        {
            InitializeComponent();
            this.manv = manv;
        }
        BU_HDB thucthi = new BU_HDB();

        private void frmHDB_Load(object sender, EventArgs e)
        {
            dgvHoaDonBan.DataSource = thucthi.getAll();
            LoadCombox();
        }
        public void LoadCombox()
        {
            BU_KhachHang kh = new BU_KhachHang();
            cbxKH.DataSource = kh.getAll();
            cbxKH.DisplayMember = "TENKH";
            cbxKH.ValueMember = "MAKH";
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMaHDB.Text = "";
            txtThanhTien.Text = "";
        }
        public void taidulieu(float t)
        {
            txtThanhTien.Text = t.ToString();
        }
        public void loadData()
        {
            dgvHoaDonBan.DataSource = thucthi.getAll();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaHDB.Text != "")
            {
                EC_HDB ban = new EC_HDB();
                ban.MaHDB = txtMaHDB.Text;
                ban.MaKH = cbxKH.SelectedValue.ToString();
                ban.NgayBan = dateNgayBan.Value;
                ban.MaNV = manv;
                if (txtThanhTien.Text != "") ban.TongTien = Int32.Parse(txtThanhTien.Text);
                if (thucthi.insertHDN(ban))
                {
                    MessageBox.Show("Thêm thành công");
                    loadData();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại");
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaHDB.Text != "")
            {
                EC_HDB ban = new EC_HDB();
                ban.MaHDB = txtMaHDB.Text;
                ban.MaKH = cbxKH.SelectedValue.ToString();
                ban.NgayBan = dateNgayBan.Value;
                ban.MaNV = manv;
                if (txtThanhTien.Text != "") ban.TongTien = float.Parse(txtThanhTien.Text);
                if (thucthi.updateHDB(ban))
                {
                    MessageBox.Show("Sửa thành công");
                    loadData();
                }
                else
                {
                    MessageBox.Show("Sửa thất bại");
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaHDB.Text != "")
            {
                EC_HDB ban = new EC_HDB();
                ban.MaHDB = txtMaHDB.Text;


                if (thucthi.deleteHDB(ban))
                {
                    MessageBox.Show("Xóa thành công");
                    loadData();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại");
                }
            }
        }

        private void dgvHoaDonBan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                var row = dgvHoaDonBan.Rows[e.RowIndex];
                txtMaHDB.Text = row.Cells[0].Value.ToString();
                dateNgayBan.Value = DateTime.Parse(row.Cells[1].Value.ToString());

                cbxKH.SelectedValue = row.Cells[3].Value.ToString();
                txtThanhTien.Text = row.Cells[4].Value.ToString();
            }
        }

        private void btnThemCTHDB_Click(object sender, EventArgs e)
        {
            if (txtMaHDB.Text != "")
            {
                frmCTHDB f = new frmCTHDB(txtMaHDB.Text, this);
                f.Show();
            }
            else
            {
                MessageBox.Show("Bạn phải nhập mã hóa đơn bán");
            }

        }

        private void btnThemKH_Click(object sender, EventArgs e)
        {
            frmThemKH frm = new frmThemKH(this);
            frm.ShowDialog();
        }
    }
    
    
}
