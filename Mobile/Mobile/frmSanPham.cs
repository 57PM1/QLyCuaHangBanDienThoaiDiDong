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
using DataAccess;
using EntityClass;

namespace Mobile
{
    public partial class frmSanPham : Form
    {
        public frmSanPham()
        {
            InitializeComponent();
        }
        BU_SanPham thucthi = new BU_SanPham();

        public void hienthi()
        {
            DataTable dt = thucthi.getAll();
            if (dt != null)
            {
                dgvSanPham.DataSource = dt;
                dgvSanPham.Columns[0].HeaderText = "Mã sản phẩm";
                dgvSanPham.Columns[1].HeaderText = "Tên sản phẩm";
                dgvSanPham.Columns[2].HeaderText = "Số lượng";
                dgvSanPham.Columns[3].HeaderText = "Giá bán";
                dgvSanPham.Columns[4].HeaderText = "Đơn vị tính";
                dgvSanPham.Columns[5].HeaderText = "Mã Nhà sản xuất";
                dgvSanPham.Columns[6].HeaderText = "Hệ điều hành";
                dgvSanPham.Columns[7].HeaderText = "CPU";
                dgvSanPham.Columns[8].HeaderText = "Ram";
                dgvSanPham.Columns[9].HeaderText = "Pin";
                dgvSanPham.Columns[10].HeaderText = "Kết nối";
                dgvSanPham.Columns[11].HeaderText = "Bộ nhớ";
                dgvSanPham.Columns[12].HeaderText = "Camera";

            }

            else
            {
                MessageBox.Show(thucthi.Error, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void frmSanPham_Load(object sender, EventArgs e)
        {
            hienthi();

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            frmSanPhamThem f = new frmSanPhamThem(this);
            f.Show();
        }

        private void dgvSanPham_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                var row = dgvSanPham.Rows[e.RowIndex];
                frmSanPhamSua f = new frmSanPhamSua(this, row.Cells[0].Value.ToString());
                f.Show();
            }
        }

        private void radiobtnMaSP_CheckedChanged(object sender, EventArgs e)
        {
            if (radiobtnMaSP.Checked)
                radiobtnTenSP.Checked = false;
            if (radiobtnMaSP.Checked == false)
                radiobtnTenSP.Checked = true;
        }

        private void radiobtnTenSP_CheckedChanged(object sender, EventArgs e)
        {
            if (radiobtnTenSP.Checked)
                radiobtnMaSP.Checked = false;
            if (radiobtnTenSP.Checked == false)
                radiobtnMaSP.Checked = true;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (radiobtnMaSP.Checked)
            {
                if (txtTimMaSanPham.Text != "")
                {
                    DataTable dt = thucthi.tkMa(txtTimMaSanPham.Text);
                    if (dt != null)
                        dgvSanPham.DataSource = dt;
                    else
                    {
                        MessageBox.Show(thucthi.Error, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    MessageBox.Show("Mã Không được để trống", "Chú Ý", MessageBoxButtons.OK);
            }
            if (radiobtnTenSP.Checked)
            {
                if (txtTimTenSanPham.Text != "")
                {
                    DataTable dt = thucthi.tkTen(txtTimTenSanPham.Text);
                    if (dt != null)
                        dgvSanPham.DataSource = dt;
                    else
                    {
                        MessageBox.Show(thucthi.Error, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    MessageBox.Show("Tên Không được để trống", "Chú Ý", MessageBoxButtons.OK);
            }
        }

    }
}

