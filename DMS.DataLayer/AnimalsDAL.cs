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
    public class AnimalsDAL
    {

        public List<Cattle> GetCattles()
        {
            SqlCommand cmd = new SqlCommand("sp_selectAnimalsAll", DALHelper.getConnection());
            return selectCattles(cmd);
        }

        public List<Cattle> GetCattlesMale()
        {
            SqlCommand cmd = new SqlCommand("sp_selectAnimals_byGenderAll", DALHelper.getConnection());
            cmd.Parameters.AddWithValue("@Gender", DALHelper.getNullORValue("M"));  //Modified 31 March
            return selectCattles(cmd);
        }

        public List<Cattle> GetCattlesFemale()
        {
            SqlCommand cmd = new SqlCommand("sp_selectAnimals_byGenderAll", DALHelper.getConnection());
            cmd.Parameters.AddWithValue("@Gender", DALHelper.getNullORValue("F"));      //Modified 31 March
            return selectCattles(cmd);
        }

        //Added 5 Jan, 2015
        //Select only those cattles whose status of giving milk is 'Y'
        public List<Cattle> GetCattles_GivingMilk()
        {
            SqlCommand cmd = new SqlCommand("sp_selectAnimalsAll_Milking", DALHelper.getConnection());
            return selectCattles(cmd);
        }

        /// <summary>
        /// March 18
        /// </summary>
        /// <param name="col"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public List<Calf> GetCalfs(string col, string param)
        {
            SqlCommand cmd = new SqlCommand("sp_selectCalfsFiltered", DALHelper.getConnection());
            cmd.Parameters.AddWithValue("@Column", col);
            cmd.Parameters.AddWithValue("@QueryString", param);
            return selectCalfs(cmd);
        }

        public List<Calf> GetCalfs()
        {
            SqlCommand cmd = new SqlCommand("sp_selectCalfsAll", DALHelper.getConnection());
            return selectCalfs(cmd);
        }

        public List<Cattle> GetCattles(string column, string queryValue)
        {
            SqlCommand cmd = new SqlCommand("sp_selectAnimalsFiltered", DALHelper.getConnection());
            cmd.Parameters.AddWithValue("@Column", column);
            cmd.Parameters.AddWithValue("@QueryString", queryValue);
            return selectCattles(cmd);
        }

        public List<Cattle> GetCattles(int fromRank, int toRank)
        {
            SqlCommand cmd = new SqlCommand("categories_selectbypriorityrank", DALHelper.getConnection());
            cmd.Parameters.AddWithValue("@from", fromRank);
            cmd.Parameters.AddWithValue("@to", toRank);
            return selectCattles(cmd);
        }

        //Added 2-Jan, 2015
        public List<MasterTables> GetAnimalTypes()
        {

            SqlCommand cmd = new SqlCommand("sp_selectAnimalTypesAll", DALHelper.getConnection());
            return selectMasterTablesData(cmd);
        }

        public List<MasterTables> GetAnimalBreeds()
        {

            SqlCommand cmd = new SqlCommand("sp_selectAnimalBreedsAll", DALHelper.getConnection());
            return selectMasterTablesData(cmd);
        }

        public List<MasterTables> GetCattlesources()
        {

            SqlCommand cmd = new SqlCommand("sp_selectAnimalSourcesAll", DALHelper.getConnection());
            return selectMasterTablesData(cmd);
        }

        public List<AnimalStatus> GetCattlestatuses()
        {

            SqlCommand cmd = new SqlCommand("sp_selectAnimalStatusesAll", DALHelper.getConnection());
            return selectCattleStatuses(cmd);
        }


        public List<AnimalStatus> GetCattlestatuses(string p)
        {
            SqlCommand cmd = new SqlCommand("[sp_selectAnimalStatusesbyGender]", DALHelper.getConnection());
            cmd.Parameters.AddWithValue("@Gender", p);
            return selectCattleStatuses(cmd);
        }

        private List<AnimalStatus> selectCattleStatuses(SqlCommand cmd)
        {
            cmd.CommandType = CommandType.StoredProcedure;
            SqlConnection con = cmd.Connection;
            List<AnimalStatus> listCattleStatus = new List<AnimalStatus>();
            con.Open();
            using (con)
            {
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    listCattleStatus = new List<AnimalStatus>();
                    while (dr.Read())
                    {

                        string isMilk = Convert.ToString(dr[3]);

                        AnimalStatus status = new AnimalStatus()
                        {
                            ID = Convert.ToInt32(dr[0]),
                            Description = Convert.ToString(dr[1]),
                            Comments = Convert.ToString(dr[2])
                        };

                        if(isMilk=="Y")
                        {
                            status.IsMilking = true;
                        }

                        listCattleStatus.Add(status);
                    }
                }
            }
            return listCattleStatus;
        }

        public List<MasterTables> GetGenders()
        {

            SqlCommand cmd = new SqlCommand("sp_selectGendersAll", DALHelper.getConnection());
            return selectMasterTablesData(cmd);
        }

        public List<AnimalWithStatus> GetAnimals_All_WithStatuses()
        {
            List<AnimalWithStatus> statusList = new List<AnimalWithStatus>();

            SqlCommand cmd = new SqlCommand("sp_selectAnimals_all_withStatus", DALHelper.getConnection());
            cmd.CommandType = CommandType.StoredProcedure;
            SqlConnection con = cmd.Connection;

            con.Open();
            using (con)
            {
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    statusList = new List<AnimalWithStatus>();
                    while (dr.Read())
                    {
                        AnimalStatusNew mObject = new AnimalStatusNew();

                        mObject.ID = Convert.ToInt32(dr[0]);
                        mObject.Description = Convert.ToString(dr[3]);
                        mObject.Comments = Convert.ToString(dr[4]);

                        if (Convert.ToChar(dr[5]) == 'N')
                        {
                            mObject.IsMilking = false;
                        }
                        else
                        {
                            mObject.IsMilking = true;
                        }

                        if (Convert.ToChar(dr[6]) == 'N')
                        {
                            mObject.IsFemale = false;
                        }
                        else
                        {
                            mObject.IsFemale = true;
                        }

                        if (Convert.ToChar(dr[7]) == 'N')
                        {
                            mObject.IsCalf = false;
                        }
                        else
                        {
                            mObject.IsCalf = true;
                        }

                        AnimalWithStatus ct = new AnimalWithStatus();

                        ct.ID = Convert.ToInt32(dr[8]);
                        ct.TagNo = Convert.ToString(dr[1]);
                        ct.UpdationTime = Convert.ToDateTime(dr[2]);
                        ct.Status = mObject;

                        statusList.Add(ct);
                    }
                }
            }


            return statusList;
        }

        public List<AnimalStatusNew> GetAnimalStatuses()
        {
            List<AnimalStatusNew> statusList = new List<AnimalStatusNew>();

            SqlCommand cmd = new SqlCommand("sp_selectAnimalStatusesAll", DALHelper.getConnection());
            cmd.CommandType = CommandType.StoredProcedure;
            SqlConnection con = cmd.Connection;
            
            con.Open();
            using (con)
            {
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    statusList = new List<AnimalStatusNew>();
                    while (dr.Read())
                    {
                        AnimalStatusNew mObject = new AnimalStatusNew();

                        mObject.ID = Convert.ToInt32(dr[0]);
                        mObject.Description = Convert.ToString(dr[1]);
                        mObject.Comments = Convert.ToString(dr[2]);

                        if (Convert.ToChar(dr[3]) == 'N')
                        {
                            mObject.IsMilking = false;
                        }
                        else
                        {
                            mObject.IsMilking = true;
                        }

                        if (Convert.ToChar(dr[4]) == 'N')
                        {
                            mObject.IsFemale = false;
                        }
                        else
                        {
                            mObject.IsFemale = true;
                        }

                        if (Convert.ToChar(dr[5]) == 'N')
                        {
                            mObject.IsCalf = false;
                        }
                        else
                        {
                            mObject.IsCalf = true;
                        }

                        statusList.Add(mObject);
                    }
                }
            }
            

            return statusList;
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


        public Animal GetAnimal(string id)
        {
            SqlCommand cmd = new SqlCommand("Animal_selectbyid", DALHelper.getConnection());
            cmd.Parameters.AddWithValue("@IdToSearch", id);
            //only one record will be found based on PK
            return selectAnimals(cmd)[0];
        }

        //Added 14 May
        public int GetAnimalStatusID(AnimalStatusNew ast)
        {
            int id = 0;

            SqlConnection con = DALHelper.getConnection();
            SqlCommand cmd = new SqlCommand("sp_select_AnimalStatus_ID", con);
            cmd.CommandType = CommandType.StoredProcedure;

            char isFemale = 'Y';
            char IsMilk = 'Y';

            if (ast.IsFemale == false)
            {
                isFemale = 'N';
            }

            if (ast.IsMilking == false)
            {
                IsMilk = 'N';
            }

            cmd.Parameters.AddWithValue("@Desc", DALHelper.getNullORValue(ast.Description));
            cmd.Parameters.AddWithValue("@IsFemale", DALHelper.getNullORValue(isFemale));
            cmd.Parameters.AddWithValue("@IsMilk", DALHelper.getNullORValue(IsMilk));

            con.Open();

            using (con)
            {
                id = (Int32)cmd.ExecuteScalar();
            }

            return id;
        }

        //Added 17 April
        public void UpdateStatus(Cattle selectedAnimal, int updatedStatus)
        {
            SqlConnection con = DALHelper.getConnection();
            SqlCommand cmd = new SqlCommand("sp_updateAnimalStatus", con); 
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ID", DALHelper.getNullORValue(selectedAnimal.ID));
            cmd.Parameters.AddWithValue("@NewStatus", DALHelper.getNullORValue(updatedStatus));
            cmd.Parameters.AddWithValue("@Date", DALHelper.getNullORValue(DateTime.Now));
            cmd.Parameters.AddWithValue("@Comments", DALHelper.getNullORValue(""));

            con.Open();

            using (con)
            {
                cmd.ExecuteNonQuery();
            }
        }

        public int Insert(Cattle cattle)
        {
            int cmd_success;
            SqlConnection con = DALHelper.getConnection();
            SqlCommand cmd = new SqlCommand("sp_insertAnimal", con); //This procedure is actually for Cattle. In DB Animal = Front-end Cattle
            cmd.CommandType = CommandType.StoredProcedure;

            #region Procedure Parameters
            //@TagNo,
            // @RegistrationDate,
            //@AnimalType,
            //@Gender,
            //@BirthDate,
            //@Weight,
            //@Height,
            //@Length,
            //@Width,
            //@Price,
            //@Source,
            //@Breed,
            //@Status,
            //@OtherDetails
            #endregion

            cmd.Parameters.AddWithValue("@TagNo", DALHelper.getNullORValue(cattle.TagNo));
            cmd.Parameters.AddWithValue("@RegistrationDate", DALHelper.getNullORValue(DateTime.Now));
            cmd.Parameters.AddWithValue("@AnimalType", DALHelper.getNullORValue(cattle.Type.ID));
            cmd.Parameters.AddWithValue("@Gender", DALHelper.getNullORValue(cattle.Gender.Description[0])); //Changed 31-Mar. Now Gender is direct
            cmd.Parameters.AddWithValue("@BirthDate", DALHelper.getNullORValue(cattle.BirthDate));
            cmd.Parameters.AddWithValue("@Weight", DALHelper.getNullORValue(cattle.CurrPhysicalAttribs.Weight));
            cmd.Parameters.AddWithValue("@Height", DALHelper.getNullORValue(cattle.CurrPhysicalAttribs.CurrentSize.Height));
            cmd.Parameters.AddWithValue("@Length", DALHelper.getNullORValue(cattle.CurrPhysicalAttribs.CurrentSize.Length));

            cmd.Parameters.AddWithValue("@Width", DALHelper.getNullORValue(cattle.CurrPhysicalAttribs.CurrentSize.Width));
            cmd.Parameters.AddWithValue("@Price", DALHelper.getNullORValue(cattle.Price));
            cmd.Parameters.AddWithValue("@Source", DALHelper.getNullORValue(cattle.Source.ID));
            cmd.Parameters.AddWithValue("@Breed", DALHelper.getNullORValue(cattle.Breed.ID));
            cmd.Parameters.AddWithValue("@Status", DALHelper.getNullORValue(cattle.Status.ID));
            cmd.Parameters.AddWithValue("@IsCalf", 'N'); //Added 31-March as added IsCalf column. Will be N for cattle and Y for Calf
            cmd.Parameters.AddWithValue("@OtherDetails", DALHelper.getNullORValue(cattle.OtherDetails));

            con.Open();
            using (con)
            {
                //Modified by Talha: Jan 26th, 2012 - Added Return variable to ensure data inserted successfully
                cmd_success = cmd.ExecuteNonQuery();
            }

            return cmd_success;
        }
        /// <summary>
        /// 14 March
        /// </summary>
        /// <param name="cattle"></param>
        /// <returns></returns>
        public int Update(Cattle cattle)
        {
            int cmd_success;
            SqlConnection con = DALHelper.getConnection();
            SqlCommand cmd = new SqlCommand("sp_updateAnimal", con); //This procedure is actually for Cattle. In DB Animal = Front-end Cattle
            cmd.CommandType = CommandType.StoredProcedure;

            #region Procedure Parameters
            //@TagNo,
            // @RegistrationDate,
            //@AnimalType,
            //@Gender,
            //@BirthDate,
            //@Weight,
            //@Height,
            //@Length,
            //@Width,
            //@Price,
            //@Source,
            //@Breed,
            //@Status,
            //@OtherDetails
            #endregion

            cmd.Parameters.AddWithValue("@TagNo", DALHelper.getNullORValue(cattle.TagNo));
            cmd.Parameters.AddWithValue("@RegistrationDate", DALHelper.getNullORValue(DateTime.Now));
            cmd.Parameters.AddWithValue("@AnimalType", DALHelper.getNullORValue(cattle.Type.ID));
            cmd.Parameters.AddWithValue("@Gender", DALHelper.getNullORValue(cattle.Gender.ID));
            cmd.Parameters.AddWithValue("@BirthDate", DALHelper.getNullORValue(cattle.BirthDate));
            cmd.Parameters.AddWithValue("@Weight", DALHelper.getNullORValue(cattle.CurrPhysicalAttribs.Weight));
            cmd.Parameters.AddWithValue("@Height", DALHelper.getNullORValue(cattle.CurrPhysicalAttribs.CurrentSize.Height));
            cmd.Parameters.AddWithValue("@Length", DALHelper.getNullORValue(cattle.CurrPhysicalAttribs.CurrentSize.Length));

            cmd.Parameters.AddWithValue("@Width", DALHelper.getNullORValue(cattle.CurrPhysicalAttribs.CurrentSize.Width));
            cmd.Parameters.AddWithValue("@Price", DALHelper.getNullORValue(cattle.Price));
            cmd.Parameters.AddWithValue("@Source", DALHelper.getNullORValue(cattle.Source.ID));
            cmd.Parameters.AddWithValue("@Breed", DALHelper.getNullORValue(cattle.Breed.ID));
            cmd.Parameters.AddWithValue("@Status", DALHelper.getNullORValue(cattle.Status.ID));
            cmd.Parameters.AddWithValue("@OtherDetails", DALHelper.getNullORValue(cattle.OtherDetails));

            con.Open();
            using (con)
            {
                //Modified by Talha: Jan 26th, 2012 - Added Return variable to ensure data inserted successfully
                cmd_success = cmd.ExecuteNonQuery();
            }

            return cmd_success;
        }



        //Made on 5-Jan
        public int Insert(Calf currCalf)
        {
            int cmd_success;
            SqlConnection con = DALHelper.getConnection();
            SqlCommand cmd = new SqlCommand("sp_insertCalf", con); 
            cmd.CommandType = CommandType.StoredProcedure;

            #region Procedure Parameters
            //@TagNo,
            // @RegistrationDate,
            //@AnimalType,
            //@Gender,
            //@BirthDate,
            //@Weight,
            //@Height,
            //@Length,
            //@Width,
            //@Price,
            //@Source,
            //@Breed,
            //@Status,
            //@OtherDetails
            //Mother
            //@Father
            #endregion

            cmd.Parameters.AddWithValue("@TagNo", DALHelper.getNullORValue(currCalf.TagNo));
            cmd.Parameters.AddWithValue("@RegistrationDate", DALHelper.getNullORValue(DateTime.Now));
            cmd.Parameters.AddWithValue("@AnimalType", DALHelper.getNullORValue(currCalf.Type.ID));
            cmd.Parameters.AddWithValue("@Gender", DALHelper.getNullORValue(currCalf.Gender.Description));
            cmd.Parameters.AddWithValue("@BirthDate", DALHelper.getNullORValue(currCalf.BirthDate));
            cmd.Parameters.AddWithValue("@Weight", DALHelper.getNullORValue(currCalf.CurrPhysicalAttribs.Weight));
            cmd.Parameters.AddWithValue("@Height", DALHelper.getNullORValue(currCalf.CurrPhysicalAttribs.CurrentSize.Height));
            cmd.Parameters.AddWithValue("@Length", DALHelper.getNullORValue(currCalf.CurrPhysicalAttribs.CurrentSize.Length));

            cmd.Parameters.AddWithValue("@Width", DALHelper.getNullORValue(currCalf.CurrPhysicalAttribs.CurrentSize.Width));
            cmd.Parameters.AddWithValue("@Price", DALHelper.getNullORValue(currCalf.Price));
            cmd.Parameters.AddWithValue("@Source", DALHelper.getNullORValue(currCalf.Source.ID));
            cmd.Parameters.AddWithValue("@Breed", DALHelper.getNullORValue(currCalf.Breed.ID));
            cmd.Parameters.AddWithValue("@Status", DALHelper.getNullORValue(1));    //Modified 01-Apr
            cmd.Parameters.AddWithValue("@OtherDetails", DALHelper.getNullORValue(currCalf.OtherDetails));

            con.Open();
            using (con)
            {
                //Modified by Talha: Jan 26th, 2012 - Added Return variable to ensure data inserted successfully
                cmd_success = cmd.ExecuteNonQuery();
            }

            return cmd_success;
        }

        public int Insert(Calf currCalf, int parentID, char isMother)
        {
            int cmd_success;
            SqlConnection con = DALHelper.getConnection();
            SqlCommand cmd = new SqlCommand("sp_insertCalfSingleParent", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Procedure Parameters
            //@TagNo,
            // @RegistrationDate,
            //@AnimalType,
            //@Gender,
            //@BirthDate,
            //@Weight,
            //@Height,
            //@Length,
            //@Width,
            //@Price,
            //@Source,
            //@Breed,
            //@Status,
            //@OtherDetails
            //Mother
            //@Father
            #endregion

            cmd.Parameters.AddWithValue("@TagNo", DALHelper.getNullORValue(currCalf.TagNo));
            cmd.Parameters.AddWithValue("@RegistrationDate", DALHelper.getNullORValue(DateTime.Now));
            cmd.Parameters.AddWithValue("@AnimalType", DALHelper.getNullORValue(currCalf.Type.ID));
            cmd.Parameters.AddWithValue("@Gender", DALHelper.getNullORValue(currCalf.Gender.Description));
            cmd.Parameters.AddWithValue("@BirthDate", DALHelper.getNullORValue(currCalf.BirthDate));
            cmd.Parameters.AddWithValue("@Weight", DALHelper.getNullORValue(currCalf.CurrPhysicalAttribs.Weight));
            cmd.Parameters.AddWithValue("@Height", DALHelper.getNullORValue(currCalf.CurrPhysicalAttribs.CurrentSize.Height));
            cmd.Parameters.AddWithValue("@Length", DALHelper.getNullORValue(currCalf.CurrPhysicalAttribs.CurrentSize.Length));

            cmd.Parameters.AddWithValue("@Width", DALHelper.getNullORValue(currCalf.CurrPhysicalAttribs.CurrentSize.Width));
            cmd.Parameters.AddWithValue("@Price", DALHelper.getNullORValue(currCalf.Price));
            cmd.Parameters.AddWithValue("@Source", DALHelper.getNullORValue(currCalf.Source.ID));
            cmd.Parameters.AddWithValue("@Breed", DALHelper.getNullORValue(currCalf.Breed.ID));
            cmd.Parameters.AddWithValue("@Status", DALHelper.getNullORValue(1));    //Modified 01-Apr
            cmd.Parameters.AddWithValue("@OtherDetails", DALHelper.getNullORValue(currCalf.OtherDetails));

            cmd.Parameters.AddWithValue("@Parent", DALHelper.getNullORValue(parentID));
            cmd.Parameters.AddWithValue("@IsMother", DALHelper.getNullORValue(isMother));   

            con.Open();
            using (con)
            {
                //Modified by Talha: Jan 26th, 2012 - Added Return variable to ensure data inserted successfully
                cmd_success = cmd.ExecuteNonQuery();
            }

            return cmd_success;
        }

        public int Insert(Calf currCalf, int motherID, int fatherID)
        {
            int cmd_success;
            SqlConnection con = DALHelper.getConnection();
            SqlCommand cmd = new SqlCommand("sp_insertCalfwithMotherandFather", con);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Procedure Parameters
            //@TagNo,
            // @RegistrationDate,
            //@AnimalType,
            //@Gender,
            //@BirthDate,
            //@Weight,
            //@Height,
            //@Length,
            //@Width,
            //@Price,
            //@Source,
            //@Breed,
            //@Status,
            //@OtherDetails
            //Mother
            //@Father
            #endregion

            cmd.Parameters.AddWithValue("@TagNo", DALHelper.getNullORValue(currCalf.TagNo));
            cmd.Parameters.AddWithValue("@RegistrationDate", DALHelper.getNullORValue(DateTime.Now));
            cmd.Parameters.AddWithValue("@AnimalType", DALHelper.getNullORValue(currCalf.Type.ID));
            cmd.Parameters.AddWithValue("@Gender", DALHelper.getNullORValue(currCalf.Gender.Description));
            cmd.Parameters.AddWithValue("@BirthDate", DALHelper.getNullORValue(currCalf.BirthDate));
            cmd.Parameters.AddWithValue("@Weight", DALHelper.getNullORValue(currCalf.CurrPhysicalAttribs.Weight));
            cmd.Parameters.AddWithValue("@Height", DALHelper.getNullORValue(currCalf.CurrPhysicalAttribs.CurrentSize.Height));
            cmd.Parameters.AddWithValue("@Length", DALHelper.getNullORValue(currCalf.CurrPhysicalAttribs.CurrentSize.Length));

            cmd.Parameters.AddWithValue("@Width", DALHelper.getNullORValue(currCalf.CurrPhysicalAttribs.CurrentSize.Width));
            cmd.Parameters.AddWithValue("@Price", DALHelper.getNullORValue(currCalf.Price));
            cmd.Parameters.AddWithValue("@Source", DALHelper.getNullORValue(currCalf.Source.ID));
            cmd.Parameters.AddWithValue("@Breed", DALHelper.getNullORValue(currCalf.Breed.ID));
            cmd.Parameters.AddWithValue("@Status", DALHelper.getNullORValue(1));    //Modified 01-Apr
            cmd.Parameters.AddWithValue("@OtherDetails", DALHelper.getNullORValue(currCalf.OtherDetails));

            cmd.Parameters.AddWithValue("@Mother", DALHelper.getNullORValue(motherID));   //Modified 31 March
            cmd.Parameters.AddWithValue("@Father", DALHelper.getNullORValue(fatherID));   //Modified 31 March

            con.Open();
            using (con)
            {
                //Modified by Talha: Jan 26th, 2012 - Added Return variable to ensure data inserted successfully
                cmd_success = cmd.ExecuteNonQuery();
            }

            return cmd_success;
        }


        public int Insert(Animal Animal)
        {
            int cmd_success;
            SqlConnection con = DALHelper.getConnection();
            SqlCommand cmd = new SqlCommand("Animals_insert_1", con); //Procedure without image for testing Talha
            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.AddWithValue("@ID", DALHelper.getNullORValue(Animal.ID));


            con.Open();
            using (con)
            {
                //Modified by Talha: Jan 26th, 2012 - Added Return variable to ensure data inserted successfully
                cmd_success = cmd.ExecuteNonQuery();
            }

            return cmd_success;
        }

        public void Delete(Animal Animal)
        {
            SqlConnection con = DALHelper.getConnection();
            SqlCommand cmd = new SqlCommand("categories_delete", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IdToSearch", Animal.ID);
            con.Open();
            using (con)
            {
                int temp = cmd.ExecuteNonQuery();
            }
        }

        private List<Cattle> selectCattles(SqlCommand cmd)
        {
            cmd.CommandType = CommandType.StoredProcedure;
            SqlConnection con = cmd.Connection;
            List<Cattle> listCattles = new List<Cattle>();
            con.Open();
            using (con)
            {
                SqlDataReader dr = cmd.ExecuteReader();

                //              [TagNo]                     0
                //   ,[RegistrationDate]                    1
                //   ,[AnimalType]                          2
                //,at.Description                           3
                //   ,[Gender]                              4
                //ID                                            5
                //   ,[BirthDate]                       6
                //   ,[Weight]                      7
                //   ,[Height]                      8
                //   ,[Length]                      9
                //   ,[Width]                       10
                //   ,[Price]                           11
                //   ,[Source]                          12
                //,aso.Description                      13
                //   ,[Breed]                                   14
                //,ab.Description                          15
                //   ,[Status]                                16
                //,ast.Description                     17
                //   ,[OtherDetails]                 18

                //Added 31-March
                //ID as surrogate PK  and removed Gender FK

                if (dr.HasRows)
                {
                    listCattles = new List<Cattle>();
                    while (dr.Read())
                    {

                        AnimalBreed currCattleBreed = new AnimalBreed           //14,15
                        {
                            ID = Convert.ToInt32(dr[14]),
                            Description = Convert.ToString(dr[15])
                        };

                        AnimalSource currCattleSource = new AnimalSource  //12,13
                        {
                            ID = Convert.ToInt32(dr[12]),
                            Description = Convert.ToString(dr[13])
                        };
                        AnimalStatus currCattleStatus = new AnimalStatus        //16 , 17
                        {
                            ID = Convert.ToInt32(dr[16]),
                            Description = Convert.ToString(dr[17])
                        };
                        AnimalType currCattleType = new AnimalType()            //2, 3
                        {
                            ID = Convert.ToInt32(dr[2]),
                            Description = Convert.ToString(dr[3])
                        };
                        Gender currCattleGender = new Gender()                  //4 , 5
                        {
                           // ID = Convert.ToInt32(dr[4]),
                            Description = Convert.ToString(dr[4])
                        };

                        PhysicalAttributes currPhysicalAttribs = new PhysicalAttributes();

                        currPhysicalAttribs.Weight = Convert.ToDouble(dr[7]);       //7

                        Entities.Size currSize = new Entities.Size();           //TO avoid ambiguity among .Net's Size function

                        currSize.Height = Convert.ToDouble(dr[8]);
                        currSize.Length = Convert.ToDouble(dr[9]);
                        currSize.Width = Convert.ToDouble(dr[10]);

                        currPhysicalAttribs.CurrentSize = currSize;

                        Cattle currCattle = new Cattle
                        {
                            ID = Convert.ToInt32(dr[5]),
                            TagNo = Convert.ToString(dr[0]),
                            RegistrationDate = Convert.ToDateTime(dr[1]),
                            BirthDate = Convert.ToDateTime(dr[6]),
                            Price = Convert.ToInt32(dr[11]),
                            OtherDetails = Convert.ToString(dr[18])
                        };

                        currCattle.Breed = currCattleBreed;
                        currCattle.Gender = currCattleGender;
                        currCattle.CurrPhysicalAttribs = currPhysicalAttribs;
                        currCattle.Source = currCattleSource;
                        currCattle.Status = currCattleStatus;
                        currCattle.Type = currCattleType;

                        listCattles.Add(currCattle);
                    }
                }
            }
            return listCattles;
        }

        private List<Calf> selectCalfs(SqlCommand cmd)
        {
            cmd.CommandType = CommandType.StoredProcedure;
            SqlConnection con = cmd.Connection;
            List<Calf> listCalfs = new List<Calf>();
            con.Open();
            using (con)
            {
                SqlDataReader dr = cmd.ExecuteReader();

                //              [TagNo]                     0
                //   ,[RegistrationDate]                    1
                //   ,[AnimalType]                          2
                //,at.Description                           3
                //   ,[Gender]                              4
                //ID                                            5
                //   ,[BirthDate]                       6
                //   ,[Weight]                      7
                //   ,[Height]                      8
                //   ,[Length]                      9
                //   ,[Width]                       10
                //   ,[Price]                           11
                //   ,[Source]                          12
                //,aso.Description                      13
                //   ,[Breed]                                   14
                //,ab.Description                          15
                //   ,[Status]                                16
                //,ast.Description                     17
                //   ,[OtherDetails]                 18
                //   Mother                                19
                // Mother TagNo                     20              Added Apr-02
                //Father                                   21
                // Father TagNo                    22              Added Apr-02

                if (dr.HasRows)
                {
                    listCalfs = new List<Calf>();
                    while (dr.Read())
                    {

                        AnimalBreed currCattleBreed = new AnimalBreed           //14,15
                        {
                            ID = Convert.ToInt32(dr[14]),
                            Description = Convert.ToString(dr[15])
                        };

                        AnimalSource currCattleSource = new AnimalSource  //12,13
                        {
                            ID = Convert.ToInt32(dr[12]),
                            Description = Convert.ToString(dr[13])
                        };
                        AnimalStatus currCattleStatus = new AnimalStatus        //16 , 17
                        {
                            ID = Convert.ToInt32(dr[16]),
                            Description = Convert.ToString(dr[17])
                        };
                        AnimalType currCattleType = new AnimalType()            //2, 3
                        {
                            ID = Convert.ToInt32(dr[2]),
                            Description = Convert.ToString(dr[3])
                        };
                        Gender currCattleGender = new Gender()                  //4 , 5
                        {
                            Description = Convert.ToString(dr[4])
                        };

                        PhysicalAttributes currPhysicalAttribs = new PhysicalAttributes();

                        currPhysicalAttribs.Weight = Convert.ToDouble(dr[7]);       //7

                        Entities.Size currSize = new Entities.Size();           //TO avoid ambiguity among .Net's Size function

                        currSize.Height = Convert.ToDouble(dr[8]);
                        currSize.Length = Convert.ToDouble(dr[9]);
                        currSize.Width = Convert.ToDouble(dr[10]);

                        currPhysicalAttribs.CurrentSize = currSize;

                        Cattle currCalfMother = new Cattle();
                        Cattle currCalfFather = new Cattle();

                        //Added April-02

                        currCalfMother.ID = Convert.ToInt32(dr[20]);        

                        if (currCalfMother.ID == 0)
                        {
                            currCalfMother.TagNo = "Other Farm";
                        }
                        else
                        {
                            currCalfMother.TagNo = Convert.ToString(dr[19]);
                        }
                        
                        currCalfFather.ID = Convert.ToInt32(dr[22]);            

                        if (currCalfFather.ID == 0)
                        {
                            currCalfFather.TagNo = "Artificial Insemnation";
                        }
                        else
                        {
                            currCalfFather.TagNo = Convert.ToString(dr[21]);
                        }

                        //Addition Ends. April-02

                        Calf currCalf = new Calf
                        {
                            ID = Convert.ToInt32(dr[5]),
                            TagNo = Convert.ToString(dr[0]),
                            RegistrationDate = Convert.ToDateTime(dr[1]),
                            BirthDate = Convert.ToDateTime(dr[6]),
                            Price = Convert.ToInt32(dr[11]),
                            OtherDetails = Convert.ToString(dr[18])
                        };

                        currCalf.Mother = currCalfMother;
                        currCalf.Father = currCalfFather;

                        currCalf.Breed = currCattleBreed;
                        currCalf.Gender = currCattleGender;
                        currCalf.CurrPhysicalAttribs = currPhysicalAttribs;
                        currCalf.Source = currCattleSource;
                        currCalf.Status = currCattleStatus;
                        currCalf.Type = currCattleType;

                        listCalfs.Add(currCalf);
                    }
                }
            }
            return listCalfs;
        }
        private List<Animal> selectAnimals(SqlCommand cmd)
        {
            cmd.CommandType = CommandType.StoredProcedure;
            SqlConnection con = cmd.Connection;
            List<Animal> Animals = new List<Animal>();
            con.Open();
            using (con)
            {
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    Animals = new List<Animal>();
                    while (dr.Read())
                    {
                        Animal a = new Animal
                        {
                            ID = Convert.ToInt32(dr["Id"])
                        };

                        Animals.Add(a);
                    }
                }
            }
            return Animals;
        }
    }
}
