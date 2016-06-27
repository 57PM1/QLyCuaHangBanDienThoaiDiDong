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
    public class BU_HDB
    {
        public DataTable getAll()
        {
            return DA_HDB.getAll();
        }
        public bool insertHDN(EC_HDB cthdn)
        {
            return DA_HDB.insertHDB(cthdn);
        }
        public bool updateHDB(EC_HDB cthdn)
        {
            return DA_HDB.updateHDB(cthdn);
        }
        public bool deleteHDB(EC_HDB cthdn)
        {
            return DA_HDB.deleteHDB(cthdn);
        }
        public DataTable GetTTHoaDon(string mahd)
        {
            return DA_HDB.GetTTHoaDon(mahd);
        }
    }
}
