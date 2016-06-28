using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using EntityClass;
using DataAccess;

namespace Business
{
    public class BU_BaoHanh
    {
        private static DA_BaoHanh da = new DA_BaoHanh();
        public string Error = da.Error;

        public DataTable getAll()
        {
            return DA_BaoHanh.getAll();
        }

        public DataTable searchByID(string key)
        {
            return DA_BaoHanh.searchMaBH(key);
        }

        public DataTable searchIMEI(string key)
        {
            return DA_BaoHanh.searchIMEI(key);
        }
        public DataTable getAllKhachHang()
        {
            return DA_BaoHanh.getKhachHang();
        }
        public DataTable getSanPham()
        {
            return DA_BaoHanh.getSanPham();
        }
        public DataTable searchMaKH(string key)
        {
            return DA_BaoHanh.searchMaKH(key);
        }
        public bool insertBaoHanh(EC_BaoHanh bh)
        {
            return DA_BaoHanh.insertBaoHanh(bh);
        }
        public bool updateBaoHanh(EC_BaoHanh bh)
        {
            return DA_BaoHanh.updateBaoHanh(bh);
        }
        public bool deleteBaoHanh(EC_BaoHanh bh)
        {
            return DA_BaoHanh.deleteBaoHanh(bh);
        }
        public DataTable GetMaBH(string mabh)
        {
            return DA_BaoHanh.GetMaBH(mabh);
        }
    }
}
