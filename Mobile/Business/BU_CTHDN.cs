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
    public class BU_CTHDN
    {
        private static DA_CTHDN da = new DA_CTHDN();
        public string Error = da.Error;

        public DataTable getAll(string key)
        {
            return DA_CTHDN.getAllByIDMaHDN(key);
        }
        public bool insertCTHDN(EC_CTHDN cthdn)
        {
            return DA_CTHDN.insertCTHDN(cthdn);
        }
        public bool updateCTHDN(EC_CTHDN cthdn)
        {
            return DA_CTHDN.updateCTHDN(cthdn);
        }
        public bool deleteCTHDN(EC_CTHDN cthdn)
        {
            return DA_CTHDN.deleteCTHDN(cthdn);
        }
    }
}
