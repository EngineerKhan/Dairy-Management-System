using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DMS.Entities;

using System.Data;
using System.Data.SqlClient;

namespace DMS.DataLayer
{
    public class AnimalInseminationsDAL
    {
        public void Add(AnimalInsemnation currAnimalInsemnation)
        {
            SqlConnection con = DALHelper.getConnection();
            SqlCommand cmd = new SqlCommand("sp_insertAnimalInsemnation", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Animal", DALHelper.getNullORValue(currAnimalInsemnation.CurrCattle.ID));   
            cmd.Parameters.AddWithValue("@Date", DALHelper.getNullORValue(currAnimalInsemnation.DateofInsemnation));
            cmd.Parameters.AddWithValue("@Comments", DALHelper.getNullORValue(currAnimalInsemnation.Comments)); 

            con.Open();
            using (con)
            {                
                cmd.ExecuteNonQuery();
            }

            //return cmd_success;

        }

        public List<AnimalInsemnation> GetAnimalInsemnations()
        {
            SqlCommand cmd = new SqlCommand("sp_selectAnimalInsemnationsAll", DALHelper.getConnection());
            return selectInsemnations(cmd);
        }

        public List<AnimalInsemnation> GetAnimalInsemnations(string col, string param)
        {
            SqlCommand cmd = new SqlCommand("sp_selectAnimalInsemnationsFiltered", DALHelper.getConnection());

            cmd.Parameters.AddWithValue("@Column", col);
            cmd.Parameters.AddWithValue("@QueryString", param);

            return selectInsemnations(cmd);
        }

        private List<AnimalInsemnation> selectInsemnations(SqlCommand cmd)
        {
            cmd.CommandType = CommandType.StoredProcedure;
            SqlConnection con = cmd.Connection;
            List<AnimalInsemnation> listInsemnation = new List<AnimalInsemnation>();
            con.Open();
            using (con)
            {
                SqlDataReader dr = cmd.ExecuteReader();

    //            i.ID,
    //i.Animal,
    //a.TagNo,
    //i.Date,
    //i.Comments

                if (dr.HasRows)
                {
                    listInsemnation = new List<AnimalInsemnation>();
                    while (dr.Read())
                    {

                        Cattle currCattle = new Cattle
                        {
                            ID = Convert.ToInt32(dr[1]),
                            TagNo = Convert.ToString(dr[2]),
                        };

                        AnimalInsemnation currInsem = new AnimalInsemnation();

                        currInsem.CurrCattle = currCattle;
                        currInsem.Comments = Convert.ToString(dr[4]);
                        currInsem.DateofInsemnation = Convert.ToDateTime(dr[3]);

                        listInsemnation.Add(currInsem);
                    }
                }
            }
            return listInsemnation;
        }

    }
}
