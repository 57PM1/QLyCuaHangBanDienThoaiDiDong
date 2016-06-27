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
using Business;
using EntityClass;

namespace Mobile
{
    public partial class frmDoiMatKhau : Form
    {
        public frmDoiMatKhau()
        {
            InitializeComponent();
        }

        BU_TaiKhoan thucthi = new BU_TaiKhoan();
        GetData data = new GetData();
        EC_TaiKhoan tk = new EC_TaiKhoan();
        private void XoaText()
        {
            txtTenDN.Text = "";
            txtMatKhauCu.Text = "";
            txtMatKhauMoi.Text = "";
            txtNhapLaiMK.Text = "";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                tk.TaiKhoan = txtTenDN.Text;
                tk.MatKhau = txtMatKhauCu.Text;
                if (thucthi.getUser(tk))
                {
                    if (txtMatKhauMoi.Text != txtNhapLaiMK.Text)
                        MessageBox.Show("Nhập lại mật khẩu không đúng!", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        tk.MatKhau = txtMatKhauMoi.Text;
                        if (thucthi.updateMK(tk))
                            MessageBox.Show("Thay đổi mật khẩu thành công!", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                            MessageBox.Show("Thay đổi mật khẩu không thành công!", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Tài khoản chưa đúng. Vui lòng kiểm tra lại.", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    XoaText();
                    txtTenDN.Focus();
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            XoaText();
        }
    }
}
