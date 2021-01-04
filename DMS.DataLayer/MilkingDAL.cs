using DMS.Entities;
using System.Collections.Generic;
using System.Data.SqlClient;
using System;
using System.Data;

namespace DMS.DataLayer
{
    public class MilkingDAL
    {

        public List<MilkingEntry> GetMilkingEntries(string col, string param)
        {
            SqlCommand cmd = new SqlCommand("sp_selectMilkEntriesFiltered", DALHelper.getConnection());
            cmd.Parameters.AddWithValue("@Column", col);
            cmd.Parameters.AddWithValue("@QueryString", param);
            return selectMilkingEntries(cmd);
        }

        public List<MilkingEntry> GetMilkingEntries()
        {
            SqlCommand cmd = new SqlCommand("sp_selectMilkEntriesAll", DALHelper.getConnection());
            return selectMilkingEntries(cmd);
        }

        public int Insert(MilkingEntry milkEntry)
        {
            int cmd_success;
            SqlConnection con = DALHelper.getConnection();
            SqlCommand cmd = new SqlCommand("sp_insertMilkEntry", con); 
            cmd.CommandType = CommandType.StoredProcedure;

            #region Procedure Parameters
            //@TagNo varchar(30),
   //         @RegistrationDate datetime,
   //         @MilkingDate date,
		 //@Shift varchar(7),
   //      @Quantity float,
   //        @Comments varchar(50)
            #endregion

            cmd.Parameters.AddWithValue("@ID", DALHelper.getNullORValue(milkEntry.MilkingCattle.ID));   //Modified on 01-Apr
            cmd.Parameters.AddWithValue("@RegistrationDate", DALHelper.getNullORValue(DateTime.Now));
            cmd.Parameters.AddWithValue("@MilkingDate", DALHelper.getNullORValue(milkEntry.MilkingDate));
            cmd.Parameters.AddWithValue("@Shift", DALHelper.getNullORValue(milkEntry.MilkingShift));
            cmd.Parameters.AddWithValue("@Quantity", DALHelper.getNullORValue(milkEntry.Quantity));
            cmd.Parameters.AddWithValue("@Comments", DALHelper.getNullORValue(milkEntry.Comments));

            con.Open();
            using (con)
            {
                //Modified by Talha: Jan 26th, 2012 - Added Return variable to ensure data inserted successfully
                cmd_success = cmd.ExecuteNonQuery();
            }

            return cmd_success;
        }

        private List<MilkingEntry> selectMilkingEntries(SqlCommand cmd)
        {
            cmd.CommandType = CommandType.StoredProcedure;
            SqlConnection con = cmd.Connection;
            List<MilkingEntry> listMilkEntry = new List<MilkingEntry>();

            con.Open();
            using (con)
            {
                SqlDataReader dr = cmd.ExecuteReader();

      //          [ID]
      //,[Milk_Animal]
      //,[EntryDate]
      //,[MilkingDate]
      //,[Shift]
      //,[Quantity]
      //,[Comments]


                if (dr.HasRows)
                {
                    listMilkEntry = new List<MilkingEntry>();

                    while (dr.Read())
                    {

                        Cattle currCattle = new Cattle();

                        currCattle.TagNo = Convert.ToString(dr[1]);

                        MilkingEntry currMilkEntry = new MilkingEntry
                        {
                            Comments = Convert.ToString(dr[6]),
                            EntryTime = Convert.ToDateTime(dr[2]),
                            MilkingDate = Convert.ToDateTime(dr[3]),
                            MilkingShift = Convert.ToString(dr[4]),
                            Quantity = Convert.ToDouble(dr[5]),
                            MilkingCattle = currCattle
                        };

                        listMilkEntry.Add(currMilkEntry);
                    }
                }
            }
            return listMilkEntry;
        }
    }
}