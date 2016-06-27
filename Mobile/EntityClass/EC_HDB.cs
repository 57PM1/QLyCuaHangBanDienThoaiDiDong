using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityClass
{
    public class EC_HDB
    {
        private string _maHDB;

        public string MaHDB
        {
            get { return _maHDB; }
            set { _maHDB = value; }
        }
        private DateTime _ngayBan;

        public DateTime NgayBan
        {
            get { return _ngayBan; }
            set { _ngayBan = value; }
        }
        private string _maNV;

        public string MaNV
        {
            get { return _maNV; }
            set { _maNV = value; }
        }
        private string _maKH;

        public string MaKH
        {
            get { return _maKH; }
            set { _maKH = value; }
        }

        private float _tongTien;

        public float TongTien
        {
            get { return _tongTien; }
            set { _tongTien = value; }
        }
    }
}
