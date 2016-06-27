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
    public partial class frmHDN : Form
    {
        public frmHDN(string manv)
        {
            InitializeComponent();
            this.manv = manv;
        }
        BU_HDN thucthi = new BU_HDN();
        String manv;

        private void frmHDN_Load(object sender, EventArgs e)
        {
            loaddata();
            LoadCombox();
        }
       
        public void LoadCombox()
        {
            BU_NhaCungCap ncc = new BU_NhaCungCap();
            cbxNCC.DataSource = ncc.getAll();
            cbxNCC.DisplayMember = "TENNCC";
            cbxNCC.ValueMember = "MANCC";
        }
        public void UpdateThanhTien(float thanhtien)
        {
            txtThanhTien.Text = thanhtien.ToString();
        }
        public void loaddata()
        {
            dgvHoaDonNhap.DataSource = thucthi.getAll();
        }


        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMaHDN.Text = "";
    
        }

        private void btLuu_Click(object sender, EventArgs e)
        {
            if (txtMaHDN.Text != "")
            {
                EC_HDN hdn = new EC_HDN();
                hdn.MaHDN = txtMaHDN.Text;
                hdn.MaNCC = cbxNCC.SelectedValue.ToString();
                hdn.MaNV = manv;
                hdn.NgayNhap = dateNgayNhap.Value;
                if (thucthi.insertHDN(hdn))
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
                MessageBox.Show("Mã hóa đơn rỗng");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {

            if (txtMaHDN.Text != "")
            {

                EC_HDN hdn = new EC_HDN();
                hdn.MaHDN = txtMaHDN.Text;
                hdn.MaNCC = cbxNCC.SelectedValue.ToString();
                hdn.MaNV = manv;
                hdn.NgayNhap = dateNgayNhap.Value;
                if (thucthi.updateHDN(hdn))
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
                MessageBox.Show("Mã hóa đơn rỗng");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaHDN.Text != "")
            {
                if (manv != "")
                {
                    EC_HDN hdn = new EC_HDN();
                    hdn.MaHDN = txtMaHDN.Text;

                    if (thucthi.deleteHDN(hdn))
                    {
                        MessageBox.Show("Xóa thành công");
                        loaddata();
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại");
                    }
                }

            }
            else
            {
                MessageBox.Show("Mã hóa đơn rỗng");
            }
        }

        private void dgvHoaDonNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                var row = dgvHoaDonNhap.Rows[e.RowIndex];
                txtMaHDN.Text = row.Cells[0].Value.ToString();
                if (row.Cells[1].Value.ToString() != "") dateNgayNhap.Value = DateTime.Parse(row.Cells[1].Value.ToString());
                manv = row.Cells[2].Value.ToString();
                cbxNCC.SelectedValue = row.Cells[3].Value.ToString();
                txtThanhTien.Text = row.Cells[4].Value.ToString();
            }
        }

        private void btnThemCT_Click(object sender, EventArgs e)
        {
            if (txtMaHDN.Text != "")
            {
                frmCTHDN f = new frmCTHDN(this, txtMaHDN.Text);
                f.Show();
            }
            else
            {
                MessageBox.Show("Bạn Phải nhập ma HDN");
                txtMaHDN.Focus();
            }
        }

        private void btnThemNCC_Click(object sender, EventArgs e)
        {
            frmThemNCC f = new frmThemNCC(this);
            f.ShowDialog();
        }
    }
}
