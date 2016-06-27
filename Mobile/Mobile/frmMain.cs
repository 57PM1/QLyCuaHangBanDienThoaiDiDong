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

namespace Mobile
{
    public partial class frmMain : Form
    {
        
        public frmMain()
        {
            InitializeComponent();
        }
        EC_TaiKhoan tk = new EC_TaiKhoan();
        string manv;
        
        public void adInPanel(Panel p, Form f)
        {
            p.Controls.Clear();
            f.TopLevel = false;
            p.Controls.Add(f);
            f.Show();

            f.Left = (p.Width - f.Width) / 2;
            f.Top = (p.Height - f.Height) / 2;
        }
        public void loadMaNV(string manv)
        {
            this.manv = manv;
        }
        private void QuyenQL()
        {
            đăngNhậpToolStripMenuItem.Enabled = false;
            đăngXuấtToolStripMenuItem.Enabled = true;
            đổiMậtKhẩuToolStripMenuItem.Enabled = true;
            sảnPhẩmToolStripMenuItem.Enabled = true;
            kháchHàngToolStripMenuItem.Enabled = true;
            nhàCungCấpToolStripMenuItem.Enabled = true;
            nhânViênToolStripMenuItem.Enabled = true;
            tàiKhoảnToolStripMenuItem.Enabled = true;
            nhậpHàngToolStripMenuItem.Enabled = true;
            xuấtHàngToolStripMenuItem.Enabled = true;
        }

        private void QuyenNV()
        {
            đăngNhậpToolStripMenuItem.Enabled = false;
            đăngXuấtToolStripMenuItem.Enabled = true;
            đổiMậtKhẩuToolStripMenuItem.Enabled = true;
            sảnPhẩmToolStripMenuItem.Enabled = true;
            kháchHàngToolStripMenuItem.Enabled = true;
            nhàCungCấpToolStripMenuItem.Enabled = true;
            nhânViênToolStripMenuItem.Enabled = false;
            tàiKhoảnToolStripMenuItem.Enabled = false;
            nhậpHàngToolStripMenuItem.Enabled = true;
            xuấtHàngToolStripMenuItem.Enabled = true;
        }
        private void QuyenKhach()
        {
            đăngNhậpToolStripMenuItem.Enabled = true;
            đăngXuấtToolStripMenuItem.Enabled = false;
            đổiMậtKhẩuToolStripMenuItem.Enabled = false;
            sảnPhẩmToolStripMenuItem.Enabled = false;
            kháchHàngToolStripMenuItem.Enabled = false;
            nhàCungCấpToolStripMenuItem.Enabled = false;
            nhânViênToolStripMenuItem.Enabled = false;
            tàiKhoảnToolStripMenuItem.Enabled = false;
            nhậpHàngToolStripMenuItem.Enabled = false;
            xuấtHàngToolStripMenuItem.Enabled = false;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            QuyenKhach();
        }

        private void đăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDangNhap f = new frmDangNhap(this);
            f.ShowDialog();
            String TaiKhoan = f.TaiKhoan;
            String Quyen = f.Quyen;
            switch (Quyen)
            {
                case "quanly": QuyenQL(); break;
                case "nhanvien": QuyenNV(); break;
                default: QuyenKhach(); break;
            }
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult h = new DialogResult();
            
            h = MessageBox.Show("Đăng Xuất", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (h.ToString() == "OK")
            {
                QuyenKhach();
                // Thoát các Form hết
                foreach (Form f in this.MdiChildren)
                {
                    f.Close();
                }
                tk = null;
                frmDangNhap fr = new frmDangNhap(this);
                fr.ShowDialog();
            }
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void sảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSanPham f = new frmSanPham();
            adInPanel(panel, f);
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKhachHang f = new frmKhachHang();
            adInPanel(panel, f);
        }

        private void nhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNhaCungCap f = new frmNhaCungCap();
            adInPanel(panel, f);
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNhanVien f = new frmNhanVien();
            adInPanel(panel, f);
        }

        private void tàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTaiKhoan f = new frmTaiKhoan();
            adInPanel(panel, f);
        }

        private void nhậpHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHDN f = new frmHDN(manv);
            adInPanel(panel, f);
        }

        private void xuấtHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHDB f = new frmHDB(manv);
            adInPanel(panel, f);
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDoiMatKhau f = new frmDoiMatKhau();
            adInPanel(panel, f);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAbout f = new frmAbout();
            adInPanel(panel, f);
        }

        private void bảoHànhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBaoHanh f = new frmBaoHanh();
            adInPanel(panel, f);
        }

        private void nhàSảnXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNhaSanXuat f = new frmNhaSanXuat();
            adInPanel(panel, f);
        }
    }
}
