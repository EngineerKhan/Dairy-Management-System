using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMS.Entities
{
    public class AnimalStatusNew : AnimalStatus
    {
        bool isFemale, isCalf;

        public bool IsFemale
        {
            get { return isFemale; }
            set { isFemale = value; }
        }

        public bool IsCalf
        {
            get { return isCalf; }
            set { isCalf = value; }
        }
    }
}
