using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMS.Entities
{
    public class AnimalWithStatus
    {

        DateTime updationTime;

        public DateTime UpdationTime
        {
            get { return updationTime; }
            set { updationTime = value; }
        }

        int id;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        string tagNo;

        public string TagNo
        {
            get { return tagNo; }
            set { tagNo = value; }
        }
        AnimalStatusNew status;

        public AnimalStatusNew Status
        {
            get { return status; }
            set { status = value; }
        }
    }
}
