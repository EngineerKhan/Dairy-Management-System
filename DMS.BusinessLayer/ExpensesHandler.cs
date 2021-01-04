using DMS.DataLayer;
using DMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace DMS.LogicLayer
{
    public class ExpensesHandler
    {

        public List<Expense> GetExpenses()
        {
            return new ExpensesDAL().GetExpenses();
        }

        public List<Expense> GetExpenses(string col, string param)
        {
            return new ExpensesDAL().GetExpenses(col, param);
        }

        public List<ExpenseCategory> GetExpenseCategories()
        {
            return new ExpensesDAL().GetExpenseCategories();
        }

        public List<ExpenseSubType> GetExpenseSubTypes()
        {
            return new ExpensesDAL().GetExpenseSubTypes();
        }

        public List<ExpenseSubType> GetExpenseSubTypes(int id)
        {
            return new ExpensesDAL().GetExpenseSubTypes(id);
        }

        public List<Expense> GetExpenses(int fromRank, int toRank)
        {
            return new ExpensesDAL().GetExpenses(fromRank, toRank);
        }

        public Expense GetExpense(string id)
        {
            return new ExpensesDAL().GetExpense(id);
        }

        public int AddExpense(Expense expense, User curruser)
        {
            //Modified by Talha: Jan 26th, 2012 - Added Return variable to ensure data inserted successfully
            int cmd_success;
            cmd_success = new ExpensesDAL().Insert(expense, curruser);
            return cmd_success;
        }


        public void UpdateExpense(Expense Expense)
        {
            new ExpensesDAL().Update(Expense);
        }

        public void DeleteExpense(Expense Expense)
        {
            new ExpensesDAL().Delete(Expense);
        }
    }
}
