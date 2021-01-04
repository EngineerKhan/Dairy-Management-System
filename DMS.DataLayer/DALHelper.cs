using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.DataLayer
{
    internal class DALHelper
    {
        internal static SqlConnection getConnection()
        {
            //string conStr = @"Data Source=TALHA-LAPTOP;Initial Catalog=DairyDB;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";
            string conStr = @"Data Source=.\SQLExpress;Initial Catalog=DairyDB;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";
            return new SqlConnection(conStr);
        }

        internal static object getNullORValue(object obj)
        {
            if (obj == null)
            {
                return DBNull.Value;
            }
            else
            {
                return obj;
            }
        }


    }
}
