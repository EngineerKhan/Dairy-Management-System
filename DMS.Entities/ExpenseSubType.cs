namespace DMS.Entities
{
    public class ExpenseSubType
    {
        int id;
        ExpenseCategory parentCategory;
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

        public ExpenseCategory ParentCategory
        {
            get
            {
                return parentCategory;
            }

            set
            {
                parentCategory = value;
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