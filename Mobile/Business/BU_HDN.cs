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
    public class BU_HDN
    {
        public DataTable getAll()
        {
            return DA_HDN.getAll();
        }
        public bool insertHDN(EC_HDN cthdn)
        {
            return DA_HDN.insertHDN(cthdn);
        }
        public bool updateHDN(EC_HDN cthdn)
        {
            return DA_HDN.updateHDN(cthdn);
        }
        public bool deleteHDN(EC_HDN cthdn)
        {
            return DA_HDN.deleteHDN(cthdn);
        }

        public DataTable GetTTHoaDon(string mahd)
        {
            return DA_HDN.GetTTHoaDon(mahd);
        }

    }
}
