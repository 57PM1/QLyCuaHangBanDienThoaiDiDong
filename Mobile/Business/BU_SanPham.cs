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
    public class BU_SanPham
    {
        private static DA_SanPham da = new DA_SanPham();
        public string Error = da.Error;

        public DataTable getAll()
        {
            return DA_SanPham.getAll();
        }
        public bool insertSP(EC_SanPham sp)
        {
            return DA_SanPham.insertSanPham(sp);
        }
        public bool updateSP(EC_SanPham sp)
        {
            return DA_SanPham.updateSanPham(sp);
        }
        public bool deleteSP(EC_SanPham sp)
        {
            return DA_SanPham.deleteSP(sp);
        }
        public DataTable tkMa(string key)
        {
            return DA_SanPham.tkMa(key);
        }
        public DataTable tkTen(string key)
        {
            return DA_SanPham.tkTen(key);
        }
    }
}
