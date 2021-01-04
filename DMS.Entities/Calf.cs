using System;


namespace DMS.Entities
{
    public class Calf : Cattle
    {
        Cattle mother, father;

        public Cattle Father
        {
            get
            {
                return father;
            }

            set
            {
                father = value;
            }
        }

        public Cattle Mother
        {
            get
            {
                return mother;
            }

            set
            {
                mother = value;
            }
        }
    }
}