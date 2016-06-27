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
    public class BU_TaiKhoan
    {
        private static DA_TaiKhoan da = new DA_TaiKhoan();
        public string Error = da.Error;

        public DataTable getAll()
        {
            return DA_TaiKhoan.getAll();
        }
        public bool insertTK(EC_TaiKhoan tk)
        {
            return DA_TaiKhoan.insertTK(tk);
        }
        public bool updateTK(EC_TaiKhoan tk)
        {
            return DA_TaiKhoan.updateTK(tk);
        }
        public bool deleteTK(EC_TaiKhoan tk)
        {
            return DA_TaiKhoan.deleteTK(tk);
        }
        public DataTable tkTenTK(string key)
        {
            return DA_TaiKhoan.tkTenTK(key);
        }
        public DataTable tkQuyen(string key)
        {
            return DA_TaiKhoan.tkQuyen(key);
        }
        public bool getUser(EC_TaiKhoan tk)
        {
            return DA_TaiKhoan.getUser(tk);
        }
        public bool updateMK(EC_TaiKhoan tk)
        {
            return DA_TaiKhoan.updateMK(tk);
        }
    }
}
