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
    public partial class frmSanPhamSua : Form
    {
        frmSanPham tg;
        public frmSanPhamSua(frmSanPham f, string masp)
        {
            InitializeComponent();
            BU_NhaSanXuat nsx = new BU_NhaSanXuat();
            cbxMaNSX.DataSource = nsx.getAll();
            cbxMaNSX.DisplayMember = "TENNSX";
            cbxMaNSX.ValueMember = "MANSX";
            tg = f;
            txtMaSP.Text = masp;
            BU_SanPham sp = new BU_SanPham();
            DataTable tb = sp.tkMa(masp);
            DataRow row = tb.Rows[0];
            txtBoNho.Text = row["BONHO"].ToString();
            txtCamera.Text = row["CAMERA"].ToString();
            txtCPU.Text = row["CPU"].ToString();
            txtDonGiaBan.Text = row["DONGIABAN"].ToString();
            //txtDonGiaNhap.Text = row["DONGIANHAP"].ToString();
            txtDVT.Text = row["DONVITINH"].ToString();
            txtHeDieuHanh.Text = row["HEDIEUHANH"].ToString();
            txtKetNoi.Text = row["KETNOI"].ToString();
            txtPin.Text = row["PIN"].ToString();
            txtRam.Text = row["RAM"].ToString();
            txtSoLuong.Text = row["SOLUONG"].ToString();
            txtTenSP.Text = row["TENSP"].ToString();
            cbxMaNSX.SelectedValue = row["MANSX"].ToString();
        }
        BU_SanPham thucthi = new BU_SanPham();
        private void frmSanPhamSua_Load(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
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
                            if (txtSoLuong.Text != "") hh.SoLuong = Int32.Parse(txtSoLuong.Text);
                            //hh.DONGIANHAP = txtDonGiaNhap.Text;
                            if (txtDonGiaBan.Text != "") hh.DonGiaBan = float.Parse(txtDonGiaBan.Text);
                            //hh.HinhAnh = null;
                            hh.HeDieuHanh = txtHeDieuHanh.Text;
                            hh.KetNoi = txtKetNoi.Text;
                            hh.Pin = txtPin.Text;
                            hh.Ram = txtRam.Text;
                            hh.BoNho = txtBoNho.Text;
                            hh.Camera = txtCamera.Text;
                            hh.Cpu = txtCPU.Text;
                            //thucthi.;
                            thucthi.updateSP(hh);
                            this.Close();
                            MessageBox.Show("Đã Sửa Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (txtMaSP.Text != "")
            {
                try
                {
                    BU_SanPham thucthi = new BU_SanPham();
                    EC_SanPham hh = new EC_SanPham();
                    hh.MaSP = txtMaSP.Text;

                    //thucthi.;
                    thucthi.deleteSP(hh);
                    this.Close();
                    MessageBox.Show("Đã Xóa Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    tg.hienthi();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Sản phẩm này có liên kết với bảng chi tiết nhập và bán", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            else
            {
                MessageBox.Show("Bạn phải nhập Mã sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
