using DMS.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DMS.DataLayer
{
    public class CustomersDAL
    {

        /// <summary>
        /// March 18
        /// </summary>
        /// <param name="col"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public List<Customer> GetCustomers(string col, string param)
        {
            SqlCommand cmd = new SqlCommand("sp_selectCustomersFiltered", DALHelper.getConnection());
            cmd.Parameters.AddWithValue("@Column", col);
            cmd.Parameters.AddWithValue("@QueryString", param);
            return selectCustomers(cmd);
        }

        //Added - Dec 26th
        /// <summary>
        /// Modified March 13 - Updated SP to customersall2
        /// </summary>
        /// <returns></returns>
        public List<Customer> GetCustomers()
        {
            SqlCommand cmd = new SqlCommand("sp_selectCustomersAll2", DALHelper.getConnection());
            return selectCustomers(cmd);
        }

        public List<Customer> GetCustomers(int fromRank, int toRank)
        {
            SqlCommand cmd = new SqlCommand("categories_selectbypriorityrank", DALHelper.getConnection());
            cmd.Parameters.AddWithValue("@from", fromRank);
            cmd.Parameters.AddWithValue("@to", toRank);
            return selectCustomers(cmd);
        }

        public List<MasterTables> GetPriceCategories()
        {
            SqlCommand cmd = new SqlCommand("sp_selectMilk_PriceCategoriesAll", DALHelper.getConnection());
            return selectMasterTablesData(cmd);
        }

        public List<MasterTables> GetTimeCategories()
        {
            SqlCommand cmd = new SqlCommand("sp_selectMilk_TimeCategoriesAll", DALHelper.getConnection());
            return selectMasterTablesData(cmd);
        }

        public List<MasterTables> selectMasterTablesData(SqlCommand cmd)
        {
            cmd.CommandType = CommandType.StoredProcedure;
            SqlConnection con = cmd.Connection;
            List<MasterTables> masterList = new List<MasterTables>();
            con.Open();
            using (con)
            {
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    masterList = new List<MasterTables>();
                    while (dr.Read())
                    {
                        MasterTables mObject = new MasterTables()
                        {
                            ID = Convert.ToInt32(dr[0]),
                            Description = Convert.ToString(dr[1]),
                            Comments = Convert.ToString(dr[2])
                        };

                        masterList.Add(mObject);
                    }
                }
            }
            return masterList;
        }

        public Customer GetCustomer(string id)
        {
            SqlCommand cmd = new SqlCommand("Customer_selectbyid", DALHelper.getConnection());
            cmd.Parameters.AddWithValue("@IdToSearch", id);
            //only one record will be found based on PK
            return selectCustomers(cmd)[0];
        }

        public int Insert(Customer cust)
        {
            int cmd_success;
            SqlConnection con = DALHelper.getConnection();
            SqlCommand cmd = new SqlCommand("sp_insertCustomer", con);
            cmd.CommandType = CommandType.StoredProcedure;

            //Be EXTRA CAREFUL WHILE ENTERING PARAMETERS as Compiler doesn't pick it
    //        @DairyID varchar (15),
    //@Name varchar(50),
    //@Address varchar(80),
    //@ContactNo varchar(15),
    //@CNIC_No varchar(15),
    //@Quantity float,
    //@Type int,
    //@PriceCategory int,
    //@Reg_Date date,
    //@Del_Time time


            cmd.Parameters.AddWithValue("@DairyID", DALHelper.getNullORValue(cust.DairyID));
            cmd.Parameters.AddWithValue("@Name", DALHelper.getNullORValue(cust.Name));
            cmd.Parameters.AddWithValue("@Address", DALHelper.getNullORValue(cust.CurrentAddress));
            cmd.Parameters.AddWithValue("@ContactNo", DALHelper.getNullORValue(cust.ContactNo));
            cmd.Parameters.AddWithValue("@CNIC_No", DALHelper.getNullORValue(cust.CNIC_No));
            cmd.Parameters.AddWithValue("@Reg_Date", DALHelper.getNullORValue(cust.RegistrationDate));

            //Commented - 13 March Talha

            //cmd.Parameters.AddWithValue("@Quantity", DALHelper.getNullORValue(cust.Quantity));
            //cmd.Parameters.AddWithValue("@Type", DALHelper.getNullORValue(cust.MilkType.ID));
            //cmd.Parameters.AddWithValue("@PriceCategory", DALHelper.getNullORValue(cust.PriceCat.ID));
            //cmd.Parameters.AddWithValue("@Reg_Date", DALHelper.getNullORValue(cust.RegistrationDate));
            //cmd.Parameters.AddWithValue("@Del_Time", DALHelper.getNullORValue(cust.DelieveryTime.ID));

            con.Open();
            using (con)
            {
                //Modified by Talha: Jan 26th, 2012 - Added Return variable to ensure data inserted successfully
                cmd_success = cmd.ExecuteNonQuery();
            }

            return cmd_success;
        }


        public void Update(Customer Customer)
        {
            SqlConnection con = DALHelper.getConnection();
            SqlCommand cmd = new SqlCommand("categories_update", con);

            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.AddWithValue("@IdToSearch", Customer.ID);
            //cmd.Parameters.AddWithValue("@name", Customer.Name);
            //cmd.Parameters.AddWithValue("@priorityrank", Customer.Father_Name);
            //cmd.Parameters.AddWithValue("@description", DALHelper.getNullORValue(Customer.Description));
            //cmd.Parameters.AddWithValue("@ImageUrl", DALHelper.getNullORValue(Customer.Class_Name));
            //cmd.Parameters.AddWithValue("@thumbnailUrl", DALHelper.getNullORValue(Customer.Section));

            con.Open();

            using (con)
            {
                int temp = cmd.ExecuteNonQuery();
            }
        }

        public void Delete(Customer Customer)
        {
            SqlConnection con = DALHelper.getConnection();
            SqlCommand cmd = new SqlCommand("categories_delete", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IdToSearch", Customer.ID);
            con.Open();
            using (con)
            {
                int temp = cmd.ExecuteNonQuery();
            }
        }

        private List<Customer> selectCustomers(SqlCommand cmd)
        {
            cmd.CommandType = CommandType.StoredProcedure;
            SqlConnection con = cmd.Connection;
            List<Customer> Customers = new List<Customer>();
            con.Open();
            using (con)
            {
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    Customers = new List<Customer>();
                    while (dr.Read())
                    {

                        #region List of columns returned by Procedure - Just for Reference of Front-End Developer in future - Updated March 13

      //                  c.[ID]
      //,[DairyID]
      //,[Name]
      //,[Address]
      //,[ContactNo]
      //,[CNIC_No]
      //,[Reg_Date]

                        #endregion

                        Customer cust = new Customer
                        {
                            ID = Convert.ToString(dr[0]),
                            DairyID = Convert.ToString(dr[1]),
                            Name = Convert.ToString(dr[2]),
                            CurrentAddress = Convert.ToString(dr[3]),
                            ContactNo = Convert.ToString(dr[4]),
                            CNIC_No = Convert.ToString(dr[5]),
                            RegistrationDate = Convert.ToDateTime(dr[6])
                        };

                        Customers.Add(cust);
                    }
                }
                return Customers;
            }
        }


    }
}
