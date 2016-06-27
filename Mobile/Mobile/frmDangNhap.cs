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
using System.Data.SqlClient;
using System.IO;
using Mobile;

namespace Mobile
{
    public partial class frmDangNhap : Form
    {
        frmMain tg;
        public frmDangNhap(frmMain f)
        {
            InitializeComponent();
            tg = f;
        }
        public EC_TaiKhoan tk = new EC_TaiKhoan();


        public String TaiKhoan = "";
        public String MatKhau = "";
        public String Quyen = "";
        public String MaNV = "";
        private void btnOK_Click(object sender, EventArgs e)
        {
            GetData db = new GetData();
            if (db.CheckLogin(txtUserName.Text, txtPassword.Text))
            {

                TaiKhoan = txtUserName.Text;
                MatKhau = txtPassword.Text;
                MessageBox.Show("Đăng nhập thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.None);
                txtUserName.Text = "";
                txtPassword.Text = "";
                Quyen = db.getQuyen(TaiKhoan, MatKhau);
                tg.loadMaNV(db.getMaNV(TaiKhoan, MatKhau));
                MessageBox.Show("Chào mừng nhân viên" + " " + db.getMaNV(TaiKhoan, MatKhau));
                this.Close();
            }
            else
            {
                MessageBox.Show("Đăng nhập thất bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUserName.Text = "";
                txtPassword.Text = "";
                txtUserName.Focus();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtUserName_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == 13)
                SendKeys.Send("{TAB}");
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnOK.Enabled = false;
                btnOK_Click(sender, e);
            }
        }
    }
}
