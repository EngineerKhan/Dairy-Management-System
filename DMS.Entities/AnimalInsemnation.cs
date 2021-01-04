using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMS.Entities
{
    public class AnimalInsemnation
    {
        Cattle currCattle;

        public Cattle CurrCattle
        {
            get { return currCattle; }
            set { currCattle = value; }
        }
        DateTime dateofInsemnation;

        public DateTime DateofInsemnation
        {
            get { return dateofInsemnation; }
            set { dateofInsemnation = value; }
        }

        string comments;

        public string Comments
        {
            get { return comments; }
            set { comments = value; }
        }
    }
}
