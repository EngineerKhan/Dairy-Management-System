using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMS.Presentation
{
    public class ColumnTuple
    {
        string frontEndName;
        string backEndName;


        public ColumnTuple()
        {
        }

        public ColumnTuple(string showName, string dbName)
        {
            frontEndName = showName;
            backEndName = dbName;
        }

        public override string ToString()
        {
            return FrontEndName;
        }

        public string BackEndName
        {
            get { return backEndName; }
            set { backEndName = value; }
        }

        public string FrontEndName
        {
            get { return frontEndName; }
            set { frontEndName = value; }
        }

    }
}
