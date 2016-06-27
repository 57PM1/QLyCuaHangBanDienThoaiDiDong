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
   public  class BU_NhaCungCap
    {
        private static DA_NhaCungCap da = new DA_NhaCungCap();
        public string Error = da.Error;

        public DataTable getAll()
        {
            return DA_NhaCungCap.getAll();
        }
        public bool insertNCC(EC_NhaCungCap nsx)
        {
            return DA_NhaCungCap.insertNCC(nsx);
        }
        public bool updateNCC(EC_NhaCungCap nsx)
        {
            return DA_NhaCungCap.updateNCC(nsx);
        }
        public bool deleteNCC(EC_NhaCungCap nsx)
        {
            return DA_NhaCungCap.deleteNCC(nsx);
        }
        public DataTable searchMaNCC(string key)
        {
            return DA_NhaCungCap.searchMaNCC(key);
        }
        public DataTable searchTenNCC(string key)
        {
            return DA_NhaCungCap.searchTenNCC(key);
        }

    }
}
