namespace DMS.Entities
{
    public class EmployeeRole
    {
        int id;
        string description;

        #region Constructors

        public EmployeeRole()
        {

        }

        public EmployeeRole(int i, string desc)
        {
            ID = i;
            Description = desc;
        }

        #endregion

        #region Properties

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

        #endregion

        //Made to facilitate view in combobox without extra coding

        public override string ToString()
        {
            return /*ID.ToString() + " - " +*/ Description;
        }
    }
}