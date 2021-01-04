namespace DMS.Entities
{
    public class MasterTables
    {
        int id;
        string description;
        string comments;

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

        public string Comments
        {
            get
            {
                return comments;
            }

            set
            {
                comments = value;
            }
        }

        public override string ToString()
        {
            return Description;
        }
    }
}