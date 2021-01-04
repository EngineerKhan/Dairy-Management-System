using DMS.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.DataLayer
{
    public class ExpensesDAL
    {

        /// <summary>
        /// For getting filtered expenses - Mar 18
        /// </summary>
        /// <param name="col"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public List<Expense> GetExpenses(string col, string param)
        {
            SqlCommand cmd = new SqlCommand("sp_selectExpensesFiltered", DALHelper.getConnection());
            cmd.Parameters.AddWithValue("@Column", col);
            cmd.Parameters.AddWithValue("@QueryString", param);
            return selectExpenses(cmd);
        }

        //Added - Dec 26th

        public List<Expense> GetExpenses()
        {
            SqlCommand cmd = new SqlCommand("sp_selectExpensesAll", DALHelper.getConnection());
            return selectExpenses(cmd);
        }

        //Added - Dec 27th
        //To populate listbox for Category

        public List<ExpenseCategory> GetExpenseCategories()
        {
            SqlCommand cmd = new SqlCommand("sp_selectExpenseCategoriesAll", DALHelper.getConnection());
            return selectExpenseCategories(cmd);
        }

        public List<ExpenseSubType> GetExpenseSubTypes()
        {
            SqlCommand cmd = new SqlCommand("sp_selectExpenseSubTypesAll", DALHelper.getConnection());
            return selectExpenseSubTypes(cmd);
        }

        public List<ExpenseSubType> GetExpenseSubTypes(int IDtoSearch)
        {
            SqlCommand cmd = new SqlCommand("sp_selectExpenseSubTypes_byParentID", DALHelper.getConnection());
            return selectExpenseSubTypes(cmd, IDtoSearch);
        }

        public List<Expense> GetExpenses(int fromRank, int toRank)
        {
            SqlCommand cmd = new SqlCommand("categories_selectbypriorityrank", DALHelper.getConnection());
            cmd.Parameters.AddWithValue("@from", fromRank);
            cmd.Parameters.AddWithValue("@to", toRank);
            return selectExpenses(cmd);
        }

        public Expense GetExpense(string id)
        {
            SqlCommand cmd = new SqlCommand("Expense_selectbyid", DALHelper.getConnection());
            cmd.Parameters.AddWithValue("@IdToSearch", id);
            //only one record will be found based on PK
            return selectExpenses(cmd)[0];
        }

        public int Insert(Expense exp, User currUser)
        {
            int cmd_success;
            SqlConnection con = DALHelper.getConnection();
            SqlCommand cmd = new SqlCommand("sp_insertExpense", con);
            cmd.CommandType = CommandType.StoredProcedure;

            //Be EXTRA CAREFUL WHILE ENTERING PARAMETERS as Compiler doesn't pick it

            cmd.Parameters.AddWithValue("@Date", DALHelper.getNullORValue(DateTime.Now));
            cmd.Parameters.AddWithValue("@Category", DALHelper.getNullORValue(exp.SubType.ParentCategory.ID));
            cmd.Parameters.AddWithValue("@SubType", DALHelper.getNullORValue(exp.SubType.ID));
            cmd.Parameters.AddWithValue("@CurrentUser", DALHelper.getNullORValue(currUser.ID));
            cmd.Parameters.AddWithValue("@Amount", DALHelper.getNullORValue(exp.Amount));
            cmd.Parameters.AddWithValue("@Comments", DALHelper.getNullORValue(exp.Comments));

            con.Open();
            using (con)
            {
                //Modified by Talha: Jan 26th, 2012 - Added Return variable to ensure data inserted successfully
                cmd_success = cmd.ExecuteNonQuery();
            }

            return cmd_success;
        }


        public void Update(Expense Expense)
        {
            SqlConnection con = DALHelper.getConnection();
            SqlCommand cmd = new SqlCommand("categories_update", con);

            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.AddWithValue("@IdToSearch", Expense.ID);
            //cmd.Parameters.AddWithValue("@name", Expense.Name);
            //cmd.Parameters.AddWithValue("@priorityrank", Expense.Father_Name);
            //cmd.Parameters.AddWithValue("@description", DALHelper.getNullORValue(Expense.Description));
            //cmd.Parameters.AddWithValue("@ImageUrl", DALHelper.getNullORValue(Expense.Class_Name));
            //cmd.Parameters.AddWithValue("@thumbnailUrl", DALHelper.getNullORValue(Expense.Section));

            con.Open();

            using (con)
            {
                int temp = cmd.ExecuteNonQuery();
            }
        }

        public void Delete(Expense Expense)
        {
            SqlConnection con = DALHelper.getConnection();
            SqlCommand cmd = new SqlCommand("categories_delete", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IdToSearch", Expense.ID);
            con.Open();
            using (con)
            {
                int temp = cmd.ExecuteNonQuery();
            }
        }

        private List<Expense> selectExpenses(SqlCommand cmd)
        {
            cmd.CommandType = CommandType.StoredProcedure;
            SqlConnection con = cmd.Connection;
            List<Expense> Expenses = new List<Expense>();
            con.Open();
            using (con)
            {
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    Expenses = new List<Expense>();
                    while (dr.Read())
                    {

                        #region List of columns returned by Procedure - Just for Reference of Front-End Developer in future - Dec 30th, 2014.

                        //ID
                        //Date
                        //Category (ID)
                        //Category (Desc)
                        //SubCategory (ID)
                        //SubCategory (Desc)
                        //Entered By (ID)
                        //Entered By (Desc)
                        //Amount
                        //Comments

                        #endregion

                        ExpenseCategory expCategory = new ExpenseCategory
                        {
                            ID = Convert.ToInt32(dr[2]),
                            Description = Convert.ToString(dr[3])
                        };

                        ExpenseSubType expSubType = new ExpenseSubType
                        {
                            ID = Convert.ToInt32(dr[4]),
                            Description = Convert.ToString(dr[5])
                        };

                        expSubType.ParentCategory = expCategory;

                        User usr = new User
                        {
                            ID = Convert.ToInt32(dr[6]),
                            UserName = Convert.ToString(dr[7])
                        };

                        Expense exp = new Expense
                        {
                            ID = Convert.ToInt32(dr[0]),
                            ExpenseDate = Convert.ToDateTime(dr[1]),
                            Amount = Convert.ToInt32(dr[8]),
                            Comments = Convert.ToString(dr[9])
                        };

                        exp.SubType = expSubType;
                        exp.EnteredBy = usr;

                        Expenses.Add(exp);
                    }
                }
                return Expenses;
            }
        }

        private List<ExpenseCategory> selectExpenseCategories(SqlCommand cmd)
        {
            cmd.CommandType = CommandType.StoredProcedure;
            SqlConnection con = cmd.Connection;
            List<ExpenseCategory> ExpenseCategories = new List<ExpenseCategory>();
            con.Open();
            using (con)
            {
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    ExpenseCategories = new List<ExpenseCategory>();
                    while (dr.Read())
                    {
                        ExpenseCategory Category = new ExpenseCategory
                        {
                            ID = Convert.ToInt32(dr[0]),
                            Description = Convert.ToString(dr[1])
                        };

                        ExpenseCategories.Add(Category);
                    }
                }
            }
            return ExpenseCategories;
        }

        private List<ExpenseSubType> selectExpenseSubTypes(SqlCommand cmd)
        {
            cmd.CommandType = CommandType.StoredProcedure;
            SqlConnection con = cmd.Connection;
            List<ExpenseSubType> ExpenseSubTypes = new List<ExpenseSubType>();
            con.Open();
            using (con)
            {
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    ExpenseSubTypes = new List<ExpenseSubType>();
                    while (dr.Read())
                    {

                        //ID
                        //Parent Category (ID)
                        //Parent Category (Desc)
                        //Description (of sub type)
                        //Comments

                        ExpenseCategory expCategory = new ExpenseCategory
                        {
                            ID = Convert.ToInt32(dr[1]),
                            Description = Convert.ToString(dr[2])
                        };

                        ExpenseSubType expSubType = new ExpenseSubType
                        {
                            ID = Convert.ToInt32(dr[0]),
                            Description = Convert.ToString(dr[3])
                        };

                        expSubType.ParentCategory = expCategory;

                        ExpenseSubTypes.Add(expSubType);
                    }
                }
            }
            return ExpenseSubTypes;
        }
        private List<ExpenseSubType> selectExpenseSubTypes(SqlCommand cmd, int parentID)
        {
            cmd.CommandType = CommandType.StoredProcedure;
            SqlConnection con = cmd.Connection;
            cmd.Parameters.AddWithValue("@ParentID", DALHelper.getNullORValue(parentID));
            List<ExpenseSubType> ExpenseSubTypes = new List<ExpenseSubType>();
            con.Open();
            using (con)
            {
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    ExpenseSubTypes = new List<ExpenseSubType>();
                    while (dr.Read())
                    {

                        //ID
                        //Parent Category (ID)
                        //Parent Category (Desc)
                        //Description (of sub type)
                        //Comments

                        ExpenseCategory expCategory = new ExpenseCategory
                        {
                            ID = Convert.ToInt32(dr[1]),
                            Description = Convert.ToString(dr[2])
                        };

                        ExpenseSubType expSubType = new ExpenseSubType
                        {
                            ID = Convert.ToInt32(dr[0]),
                            Description = Convert.ToString(dr[3])
                        };

                        expSubType.ParentCategory = expCategory;

                        ExpenseSubTypes.Add(expSubType);
                    }
                }
            }
            return ExpenseSubTypes;
        }

    }
}
