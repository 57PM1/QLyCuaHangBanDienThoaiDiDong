using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityClass
{
   public class EC_CTHDN
    {
        private string _maHDN;

        public string MaHDN
        {
            get { return _maHDN; }
            set { _maHDN = value; }
        }
        private string _maSP;

        public string MaSP
        {
            get { return _maSP; }
            set { _maSP = value; }
        }
        private int _soLuong;

        public int SoLuong
        {
            get { return _soLuong; }
            set { _soLuong = value; }
        }
        private float _donGia;

        public float DonGia
        {
            get { return _donGia; }
            set { _donGia = value; }
        }
        private float _thanhTien;

        public float ThanhTien
        {
            get { return _thanhTien; }
            set { _thanhTien = value; }
        }
    }
}
