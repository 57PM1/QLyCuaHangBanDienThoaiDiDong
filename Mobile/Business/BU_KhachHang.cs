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
    public class BU_KhachHang
    {

        private static DA_KhachHang da = new DA_KhachHang();

        public string Error = da.Error;


        public DataTable getAll()
        {
            return DA_KhachHang.getAll();
        }
        //public DataTable getAllforReport()
        //{
        //    return da.getAllforReport();
        //}
        public DataTable searchMaKH(string key)
        {
            return DA_KhachHang.searchMaKH(key);
        }
        public DataTable searchTenKH(string key)
        {
            return DA_KhachHang.searchTenKH(key);
        }
        public bool insertKH(EC_KhachHang khach)
        {
            return DA_KhachHang.insertKH(khach);
        }
        public bool updateKH(EC_KhachHang khach)
        {
            return DA_KhachHang.updateKH(khach);
        }
        public bool deleteKH(EC_KhachHang khach)
        {
            return DA_KhachHang.deleteKH(khach);
        }

    }
}
