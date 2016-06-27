using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityClass;
using DataAccess;
using System.Data;


namespace Business
{
    public class BU_NhanVien
    {
        private static DA_NhanVien da = new DA_NhanVien();

        public string Error = da.Error;

        public DataTable getAll()
        {
            return DA_NhanVien.getAll();
        }
        public bool insertNV(EC_NhanVien nv)
        {
            return DA_NhanVien.insertNV(nv);
        }
        public bool updateNV(EC_NhanVien nv)
        {
            return DA_NhanVien.updateNV(nv);
        }
        public bool deleteNV(EC_NhanVien nv)
        {
            return DA_NhanVien.deleteNV(nv);
        }
        public DataTable tkMa(string key)
        {
            return DA_NhanVien.tkMa(key);
        }
        public DataTable tkTen(string key)
        {
            return DA_NhanVien.tkTen(key);
        }
        public DataTable GetDoanhThu(string manv)
        {
            return DA_NhanVien.GetDoanhThu(manv);
        }

    }
}
