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
    public class BU_CTHDB
    {
        private static DA_CTHDB da = new DA_CTHDB();
        public string Error = da.Error;

        public DataTable getAll(string key)
        {
            return DA_CTHDB.getAllByIDMaHDB(key);
        }
        public bool insertCTHDB(EC_CTHDB cthdn)
        {
            return DA_CTHDB.insertCTHDB(cthdn);
        }
        public bool updateCTHDB(EC_CTHDB cthdn)
        {
            return DA_CTHDB.updateCTHDB(cthdn);
        }
        public bool deleteCTHDB(EC_CTHDB cthdn)
        {
            return DA_CTHDB.deleteCTHDB(cthdn);
        }
    }
}
