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
    public class BU_NhaSanXuat
    {
        private static DA_NhaSanXuat da = new DA_NhaSanXuat();
        public string Error = da.Error;

        public DataTable getAll()
        {
            return DA_NhaSanXuat.getAll();
        }
        public bool insertNSX(EC_NhaSanXuat nsx)
        {
            return DA_NhaSanXuat.insertNSX(nsx);
        }
        public bool updateNSX(EC_NhaSanXuat nsx)
        {
            return DA_NhaSanXuat.updateNSX(nsx);
        }
        public bool deleteNSX(EC_NhaSanXuat nsx)
        {
            return DA_NhaSanXuat.deleteNSX(nsx);
        }
        public DataTable tkMa(string key)
        {
            return DA_NhaSanXuat.tkMa(key);
        }
        public DataTable tkTen(string key)
        {
            return DA_NhaSanXuat.tkTen(key);
        }
    }
}
