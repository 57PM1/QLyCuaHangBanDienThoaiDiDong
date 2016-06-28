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
    public partial class frmKhachHang : Form
    {
        public frmKhachHang()
        {
            InitializeComponent();
        }

        BU_KhachHang thucthi = new BU_KhachHang();
        GetData data = new GetData();
        EC_KhachHang kh = new EC_KhachHang();
        bool themmoi;
        int dong = 0;


        public void setnull()
        {
            txtMaKH.Text = "";
            txtTenKH.Text = "";
            txtDiaChi.Text = "";
            txtDT.Text = "";
        }
        public void locktext()
        {
            txtMaKH.Enabled = false;
            txtTenKH.Enabled = false;
            txtDiaChi.Enabled = false;
            txtDT.Enabled = false;
            txtEmail.Enabled = false;

            btnThem.Enabled = true;
            btnLuu.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }
        public void un_locktext()
        {
            txtMaKH.Enabled = true;
            txtTenKH.Enabled = true;
            txtDiaChi.Enabled = true;
            txtDT.Enabled = true;
            txtEmail.Enabled = true;

            btnThem.Enabled = false;
            btnLuu.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }
        public void hienthi()
        {
            DataTable dt = thucthi.getAll();
            if (dt != null)
            {
                DataGridView.DataSource = dt;
                DataGridView.Columns[0].HeaderText = "Mã Khách Hàng";
                DataGridView.Columns[1].HeaderText = "Tên Khách Hàng";
                DataGridView.Columns[2].HeaderText = "Điện Thoại";
                DataGridView.Columns[3].HeaderText = "Điạ Chỉ";
                DataGridView.Columns[4].HeaderText = "Email";
            }
                
            else
            {
                MessageBox.Show(thucthi.Error, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            locktext();
            hienthi();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            themmoi = true;
            un_locktext();
            setnull();
            txtMaKH.Enabled = true;
            txtMaKH.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaKH.Text != "")
            {
                if (themmoi == true)
                {
                    try
                    {
                        kh.MaKH = txtMaKH.Text;
                        kh.TenKH = txtTenKH.Text;
                        kh.DienThoai = txtDT.Text;
                        kh.DiaChi = txtDiaChi.Text;
                        kh.Email = txtEmail.Text;

                        thucthi.insertKH(kh);
                        locktext();
                        hienthi();
                        MessageBox.Show("Đã Lưu Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                    try
                    {
                        kh.MaKH = txtMaKH.Text;
                        kh.TenKH = txtTenKH.Text;
                        kh.DienThoai = txtDT.Text;
                        kh.DiaChi = txtDiaChi.Text;
                        kh.Email = txtEmail.Text;

                        thucthi.updateKH(kh);
                        MessageBox.Show("Đã Sửa Thành Công Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                txtMaKH.Enabled = true;
                locktext();
                hienthi();
            }
            else
            {
                MessageBox.Show("Mã Không được để trống", "Chú Ý", MessageBoxButtons.OK);
                txtMaKH.Focus();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            themmoi = false;
            un_locktext();
            txtMaKH.Enabled = false;
            txtTenKH.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xóa dữ liệu này?", "Chú Ý", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    kh.MaKH = txtMaKH.Text;

                    thucthi.deleteKH(kh);
                    MessageBox.Show("Đã Xóa Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    hienthi();
                    setnull();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi");
                }
            }
        }

        private void DataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                dong = e.RowIndex;
                txtMaKH.Text = DataGridView.Rows[dong].Cells[0].Value.ToString();
                txtTenKH.Text = DataGridView.Rows[dong].Cells[1].Value.ToString();
                txtDT.Text = DataGridView.Rows[dong].Cells[2].Value.ToString();
                txtDiaChi.Text = DataGridView.Rows[dong].Cells[3].Value.ToString();
                txtEmail.Text = DataGridView.Rows[dong].Cells[4].Value.ToString();
                locktext();
            }
           
        }

        private void radiobtnMaKH_CheckedChanged(object sender, EventArgs e)
        {
            if (radiobtnMaKH.Checked)
                radiobtnTenKH.Checked = false;
            if (radiobtnMaKH.Checked == false)
                radiobtnTenKH.Checked = true;
        }

        private void radiobtnTenKH_CheckedChanged(object sender, EventArgs e)
        {
            if (radiobtnTenKH.Checked)
                radiobtnMaKH.Checked = false;
            if (radiobtnTenKH.Checked == false)
                radiobtnMaKH.Checked = true;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (radiobtnMaKH.Checked)
            {
                if (txtTimMaKH.Text != "")
                {
                    //DataGridView.DataSource = thucthi.searchMaKH(txtTimMaKH.Text);
                    DataTable dt = thucthi.searchMaKH(txtTimMaKH.Text);
                    if (dt != null)
                        DataGridView.DataSource = dt;
                    else
                    {
                        MessageBox.Show(thucthi.Error, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    MessageBox.Show("Mã Không được để trống", "Chú Ý", MessageBoxButtons.OK);
            }
            if (radiobtnTenKH.Checked)
            {
                if (txtTimTenKH.Text != "")
                {
                    //DataGridView.DataSource = thucthi.searchTenKH(txtTimTenKH.Text);
                    DataTable dt = thucthi.searchTenKH(txtTimTenKH.Text);
                    if (dt != null)
                        DataGridView.DataSource = dt;
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
