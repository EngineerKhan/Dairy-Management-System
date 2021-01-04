namespace DMS.Entities
{
    public class ExpenseCategory
    {
        int id;
        string description;

        public int ID
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Description
        {
            get
            {
                return description;
            }

            set
            {
                description = value;
            }
        }

        public override string ToString()
        {
            return ID.ToString() + " - " + Description;
        }
    }
}