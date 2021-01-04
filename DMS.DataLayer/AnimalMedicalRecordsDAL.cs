using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DMS.Entities;

namespace DMS.DataLayer
{
    public class AnimalMedicalRecordsDAL
    {
        /// <summary>
        /// Added 18 March
        /// </summary>
        /// <param name="col"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public List<AnimalMedicalRecord> GetAnimalMedicalRecords(string col, string param)
        {
            SqlCommand cmd = new SqlCommand("sp_selectAnimalMedicalRecords_Filtered", DALHelper.getConnection());
            
            cmd.Parameters.AddWithValue("@Column", col);
            cmd.Parameters.AddWithValue("@QueryString", param);

            return selectAnimalMedicalRecords(cmd);
        }

        public List<AnimalMedicalRecord> GetAnimalMedicalRecords()
        {
            SqlCommand cmd = new SqlCommand("sp_selectAnimalMedicalRecordsAll", DALHelper.getConnection());
            return selectAnimalMedicalRecords(cmd);
        }

        /// <summary>
        /// Added on March 12 - For updating the edited rows
        /// </summary>
        /// <param name="medRecord">Edited Row (containing ID as well)</param>
        /// <returns>Success as int </returns>

        public int Update(AnimalMedicalRecord medRecord)
        {
            int cmd_success;
            SqlConnection con = DALHelper.getConnection();
            SqlCommand cmd = new SqlCommand("sp_updateAnimalMedicalRecord", con); 
            cmd.CommandType = CommandType.StoredProcedure;

            #region Procedure Parameters
            //@ID int,
            // @Date datetime,
            //@Animal varchar(30),
            //@Diagnosis varchar(50),
            //@Treatment varchar(50),
            //@Prognosis varchar(50)
            #endregion

            cmd.Parameters.AddWithValue("@ID", DALHelper.getNullORValue(medRecord.ID));
            cmd.Parameters.AddWithValue("@Animal", DALHelper.getNullORValue(medRecord.IllAnimal.ID));   //Modified 31-Mar
            cmd.Parameters.AddWithValue("@Date", DALHelper.getNullORValue(medRecord.EntryDate));
            cmd.Parameters.AddWithValue("@Diagnosis", DALHelper.getNullORValue(medRecord.Diagnosis));
            cmd.Parameters.AddWithValue("@Treatment", DALHelper.getNullORValue(medRecord.Treatment));
            cmd.Parameters.AddWithValue("@Prognosis", DALHelper.getNullORValue(medRecord.Prognosis));

            con.Open();
            using (con)
            {
                //Modified by Talha: Jan 26th, 2012 - Added Return variable to ensure data inserted successfully
                cmd_success = cmd.ExecuteNonQuery();
            }

            return cmd_success;
        }

        public int Insert(AnimalMedicalRecord medRecord)
        {
            int cmd_success;
            SqlConnection con = DALHelper.getConnection();
            SqlCommand cmd = new SqlCommand("sp_insertAnimalMedicalRecord", con); //This procedure is actually for AnimalMedicalRecord. In DB Animal = Front-end AnimalMedicalRecord
            cmd.CommandType = CommandType.StoredProcedure;

            #region Procedure Parameters
           // @Date datetime,
           //@Animal varchar(30),
           //@Diagnosis varchar(50),
           //@Treatment varchar(50),
           //@Prognosis varchar(50)
            #endregion

            cmd.Parameters.AddWithValue("@Animal", DALHelper.getNullORValue(medRecord.IllAnimal.ID));   //Changed 31-Mar from Tag to ID
            cmd.Parameters.AddWithValue("@Date", DALHelper.getNullORValue(DateTime.Now));
            cmd.Parameters.AddWithValue("@Diagnosis", DALHelper.getNullORValue(medRecord.Diagnosis));
            cmd.Parameters.AddWithValue("@Treatment", DALHelper.getNullORValue(medRecord.Treatment));
            cmd.Parameters.AddWithValue("@Prognosis", DALHelper.getNullORValue(medRecord.Prognosis));

            con.Open();
            using (con)
            {
                //Modified by Talha: Jan 26th, 2012 - Added Return variable to ensure data inserted successfully
                cmd_success = cmd.ExecuteNonQuery();
            }

            return cmd_success;
        }
        private List<AnimalMedicalRecord> selectAnimalMedicalRecords(SqlCommand cmd)
        {
            cmd.CommandType = CommandType.StoredProcedure;
            SqlConnection con = cmd.Connection;
            List<AnimalMedicalRecord> listAnimalMedicalRecords = new List<AnimalMedicalRecord>();

            con.Open();
            using (con)
            {
                SqlDataReader dr = cmd.ExecuteReader();

   //             amr.[ID]      0
   //   ,[Date]                 1
   //   ,[Animal]
	  //,at.[ID]                    3
	  //,at.[Description]
	  //,a.[BirthDate]          5
   //   ,[Diagnosis]            6
   //   ,[Treatment]
   //   ,[Prognosis]            8
                //a.TagNo 9         Added on 31-March

                if (dr.HasRows)
                {
                    listAnimalMedicalRecords = new List<AnimalMedicalRecord>();
                    while (dr.Read())
                    {

                        AnimalType currAnimalType = new AnimalType()            //2, 3
                        {
                            ID = Convert.ToInt32(dr[3]),
                            Description = Convert.ToString(dr[4])
                        };

                        Cattle currAnimal = new Cattle();

                        currAnimal.ID = Convert.ToInt32(dr[2]);
                        currAnimal.TagNo = Convert.ToString(dr[9]);
                        currAnimal.Type = currAnimalType;

                        AnimalMedicalRecord currAnimalMedicalRecord = new AnimalMedicalRecord
                        {
                            ID = Convert.ToInt32(dr[0]),
                            Diagnosis = Convert.ToString(dr[6]),
                            Treatment = Convert.ToString(dr[7]),
                            Prognosis = Convert.ToString(dr[8])
                        };

                        currAnimalMedicalRecord.IllAnimal = currAnimal;
                        currAnimalMedicalRecord.EntryDate = Convert.ToDateTime(dr[1]);

                        listAnimalMedicalRecords.Add(currAnimalMedicalRecord);
                    }
                }
            }
            return listAnimalMedicalRecords;
        }

    }
}
