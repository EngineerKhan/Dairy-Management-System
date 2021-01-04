using System;

namespace DMS.Entities
{
    public class Expense
    {
        int id;         //Used in DB as PK. Nothing special use of it
        DateTime expenseDate;
        ExpenseSubType subType;         //It contains the Category as well
        User enteredBy;
        int amount;
        string comments;

        public int Amount
        {
            get
            {
                return amount;
            }

            set
            {
                amount = value;
            }
        }


        public DateTime ExpenseDate
        {
            get
            {
                return expenseDate;
            }

            set
            {
                expenseDate = value;
            }
        }

        public ExpenseSubType SubType
        {
            get
            {
                return subType;
            }

            set
            {
                subType = value;
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

        public User EnteredBy
        {
            get
            {
                return enteredBy;
            }

            set
            {
                enteredBy = value;
            }
        }
    }

}

