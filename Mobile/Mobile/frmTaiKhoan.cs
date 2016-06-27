using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccess;
using EntityClass;
using Business;

namespace Mobile
{
    public partial class frmTaiKhoan : Form
    {
        public frmTaiKhoan()
        {
            InitializeComponent();
        }

        BU_TaiKhoan thucthi = new BU_TaiKhoan();
        GetData data = new GetData();
        EC_TaiKhoan tk = new EC_TaiKhoan();
        bool themmoi;
        int dong = 0;
        public void LoadCombox()
        {
            BU_NhanVien nv = new BU_NhanVien();
            cbxNhanVien.DataSource = nv.getAll();
            cbxNhanVien.DisplayMember = "TENNV";
            cbxNhanVien.ValueMember = "MANV";
        }

        public void setnull()
        {
            txtTenTK.Text = "";
            txtMatKhau.Text = "";
            cbxQuyen.Text = "";
            cbxNhanVien.Text = "";
        }
        public void locktext()
        {
            txtTenTK.Enabled = false;
            txtMatKhau.Enabled = false;
            cbxQuyen.Enabled = false;
            cbxNhanVien.Enabled = false;

            btnThem.Enabled = true;
            btnLuu.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }
        public void un_locktext()
        {
            txtTenTK.Enabled = true;
            txtMatKhau.Enabled = true;
            cbxQuyen.Enabled = true;
            cbxNhanVien.Enabled = true;

            btnThem.Enabled = false;
            btnLuu.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        public void hienthi()
        {
            DataTable dt = thucthi.getAll();
            if (dt != null) {
                dataGridView.DataSource = dt;
                dataGridView.Columns[0].HeaderText = "Tên Tài Khoản";
                dataGridView.Columns[1].HeaderText = "Mật Khẩu";
                dataGridView.Columns[2].HeaderText = "Quyền";
                dataGridView.Columns[3].HeaderText = "Nhân Viên";

            }
               
            else
            {
                MessageBox.Show(thucthi.Error, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void frmTaiKhoan_Load(object sender, EventArgs e)
        {

            
            locktext();
            hienthi();
            LoadCombox();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            themmoi = true;
            un_locktext();
            setnull();
            txtTenTK.Enabled = true;
            txtTenTK.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtTenTK.Text != "")
            {
                if (themmoi == true)
                {
                    try
                    {
                        tk.TaiKhoan = txtTenTK.Text;
                        tk.MatKhau = txtMatKhau.Text;
                        tk.Quyen = cbxQuyen.Text;
                        tk.MaNV = cbxNhanVien.Text;
                        //tk.Quyen = cbxQuyen.SelectedValue.ToString();
                        //tk.MaNV = cbxNhanVien.SelectedValue.ToString();

                        thucthi.insertTK(tk);
                        locktext();
                        //hienthi();
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
                        tk.TaiKhoan = txtTenTK.Text;
                        tk.MatKhau = txtMatKhau.Text;
                        tk.Quyen = cbxQuyen.Text;
                        tk.MaNV = cbxNhanVien.Text;
                        //tk.Quyen = cbxQuyen.SelectedValue.ToString();
                        //tk.MaNV = cbxNhanVien.SelectedValue.ToString();

                        thucthi.updateTK(tk);
                        MessageBox.Show("Đã Sửa Thành Công Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                txtTenTK.Enabled = true;
                locktext();
                hienthi();
            }
            else
            {
                MessageBox.Show("Tên Không được để trống", "Chú Ý", MessageBoxButtons.OK);
                txtTenTK.Focus();
            }
        }




        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                dong = e.RowIndex;
                txtTenTK.Text = dataGridView.Rows[dong].Cells[0].Value.ToString();
                txtMatKhau.Text = dataGridView.Rows[dong].Cells[1].Value.ToString();
                cbxQuyen.Text = dataGridView.Rows[dong].Cells[2].Value.ToString();
                cbxNhanVien.Text = dataGridView.Rows[dong].Cells[3].Value.ToString();
                locktext();
            }

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            themmoi = false;
            un_locktext();
            txtTenTK.Enabled = false;
            txtTenTK.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xóa dữ liệu này?", "Chú Ý", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    tk.TaiKhoan = txtTenTK.Text;

                    thucthi.deleteTK(tk);
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

        private void radiobtnTenTK_CheckedChanged(object sender, EventArgs e)
        {
            if (radiobtnTenTK.Checked)
                radiobtnQuyen.Checked = false;
            if (radiobtnTenTK.Checked == false)
                radiobtnQuyen.Checked = true;
        }

        private void radiobtnQuyen_CheckedChanged(object sender, EventArgs e)
        {
            if (radiobtnQuyen.Checked)
                radiobtnTenTK.Checked = false;
            if (radiobtnQuyen.Checked == false)
                radiobtnTenTK.Checked = true;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (radiobtnTenTK.Checked)
            {
                if (txtTimTenTK.Text != "")
                {
                    //dataGridView.DataSource = thucthi.tkTenTK(txtTimTenTK.Text);
                    DataTable dt = thucthi.tkTenTK(txtTimTenTK.Text);
                    if (dt != null)
                        dataGridView.DataSource = dt;
                    else
                    {
                        MessageBox.Show(thucthi.Error, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    MessageBox.Show("Tên Không được để trống", "Chú Ý", MessageBoxButtons.OK);
            }
            if (radiobtnQuyen.Checked)
            {
                if (txtTimTenTK.Text != "")
                {
                    //dataGridView.DataSource = thucthi.tkQuyen(txtTimQuyen.Text);
                    DataTable dt = thucthi.tkQuyen(txtTimQuyen.Text);
                    if (dt != null)
                        dataGridView.DataSource = dt;
                    else
                    {
                        MessageBox.Show(thucthi.Error, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    MessageBox.Show("Quyền Không được để trống", "Chú Ý", MessageBoxButtons.OK);
            }
        }
    }
}
