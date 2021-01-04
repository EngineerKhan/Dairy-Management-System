using DMS.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DMS.DataLayer
{
    public class MastersDAL
    {

        public List<MasterTables> GetMasterTablesData(string procedureName)
        {
            SqlCommand cmd = new SqlCommand(procedureName, DALHelper.getConnection());
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
    }
}
