using DMS.Entities;
using System.Collections.Generic;

namespace DMS.Presentation
{
    public static class GlobalSettings
    {
        static User currApplictionUser;
        static List<DBTransaction> transList;
        static AdminModule2 adminPage;

        public static AdminModule2 AdminPage
        {
            get { return GlobalSettings.adminPage; }
            set { GlobalSettings.adminPage = value; }
        }

        static GlobalSettings()
        {
            transList = new List<DBTransaction>();
        }

        public static User CurrApplictionUser
        {
            get
            {
                return currApplictionUser;
            }

            set
            {
                currApplictionUser = value;
            }
        }

        public static List<DBTransaction> TransList
        {
            get
            {
                return transList;
            }

            set
            {
                transList = value;
            }
        }
    }
}
