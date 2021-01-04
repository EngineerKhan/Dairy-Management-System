namespace DMS.Entities
{
    public class AnimalStatus : MasterTables
    {
        bool isMilking;

        public bool IsMilking
        {
            get
            {
                return isMilking;
            }

            set
            {
                isMilking = value;
            }
        }

        public override string ToString()
        {
            //Modified on April-01.
            //Status should show Milking if IsMilking = true

            if (IsMilking == true)
            {
                return Description + " - MILKING";
            }
            else
            {
                return Description;
            }
        }
    }
}