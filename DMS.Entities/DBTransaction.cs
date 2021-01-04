using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Entities
{
    public class DBTransaction
    {
        DateTime transTime;
        User usr;

        public DBTransaction(DateTime dt, User user)
        {
            transTime = dt;
            usr = user;
        }

        public DateTime TransTime
        {
            get
            {
                return transTime;
            }

            set
            {
                transTime = value;
            }
        }

        public User Usr
        {
            get
            {
                return usr;
            }

            set
            {
                usr = value;
            }
        }
    }
}
