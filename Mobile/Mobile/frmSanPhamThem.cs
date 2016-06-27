using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityClass;
using Business;

namespace Mobile
{
    public partial class frmSanPhamThem : Form
    {
        frmSanPham tg;
        public frmSanPhamThem(frmSanPham f)
        {
            InitializeComponent();
            tg = f;
        }

        private void frmSanPhamThem_Load(object sender, EventArgs e)
        {
            loadcombox();
        }
        public void loadcombox()
        {
            BU_NhaSanXuat thucthi = new BU_NhaSanXuat();
            DataTable dt = thucthi.getAll();
            if (dt != null)
            {
                cbxMaNSX.DataSource = dt;
                cbxMaNSX.ValueMember = "MANSX";
                cbxMaNSX.DisplayMember = "TENNSX";
            }
            else
            {
                MessageBox.Show(thucthi.Error, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
  

        private void btnThemNSX_Click(object sender, EventArgs e)
        {
            frmThemNSX f = new frmThemNSX(this);
            f.ShowDialog();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaSP.Text != "")
            {
                if (cbxMaNSX.Text != "")
                {
                    if (txtDVT.Text != "")
                    {
                        try
                        {
                            BU_SanPham thucthi = new BU_SanPham();
                            EC_SanPham hh = new EC_SanPham();
                            hh.MaSP = txtMaSP.Text;
                            hh.TenSP = txtTenSP.Text;
                            hh.MaNSX = cbxMaNSX.SelectedValue.ToString();
                            hh.DonViTinh = txtDVT.Text;
                            if (txtSoLuong.Text != "") hh.SoLuong = Int32.Parse(txtSoLuong.Text.ToString());
                            //hh.DONGIANHAP = txtDonGiaNhap.Text;
                            if (txtDonGiaBan.Text != "") hh.DonGiaBan = float.Parse(txtDonGiaBan.Text.ToString());
                            hh.HinhAnh = null;
                            hh.HeDieuHanh = txtHeDieuHanh.Text;
                            hh.KetNoi = txtKetNoi.Text;
                            hh.Pin = txtPin.Text;
                            hh.Ram = txtRam.Text;
                            hh.BoNho = txtBoNho.Text;
                            hh.Camera = txtCamera.Text;
                            hh.Cpu = txtCPU.Text;
                            //thucthi.;
                            thucthi.insertSP(hh);
                            MessageBox.Show("Đã Lưu Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            tg.hienthi();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString(), "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Bạn phải nhập đơn vị tính", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("Bạn phải nhập Mã sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtMaSP.Text = "";
            txtTenSP.Text = "";
            txtSoLuong.Text = "";
            txtDonGiaBan.Text = "";
            txtDVT.Text = "";
            txtHeDieuHanh.Text = "";
            txtCPU.Text = "";
            txtRam.Text = "";
            txtPin.Text = "";
            txtKetNoi.Text = "";
            txtBoNho.Text = "";
            txtCamera.Text = "";

        }
    }
}
