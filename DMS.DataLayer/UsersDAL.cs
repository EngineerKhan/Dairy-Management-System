using DMS.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DMS.DataLayer
{
    public class UsersDAL
    {

        //Added - Dec 26th

        public List<User> GetUsers()
        {

            #region Extra
            //Hard-coded values for testing

            //List<User> list = new List<User>();

            //list.Add(new User("Ali"));
            //list.Add(new User("Bilal"));
            //list.Add(new User("Kashif"));
            //list.Add(new User("Mehmood"));

            //return list;

            //Uncomment code below when Backend is configured. Talha. Dec 26
            #endregion
            try
            {
                SqlCommand cmd = new SqlCommand("sp_selectUsersAll", DALHelper.getConnection());
                return selectUsers(cmd);
            }

            catch(Exception e)
            {
                return new List<User>();
            }
        }

        //Added - Dec 27th
        //To populate listbox for role

        public List<UserType> GetUserTypes()
        {
            SqlCommand cmd = new SqlCommand("sp_selectUserTypesAll", DALHelper.getConnection());
            return selectUserTypes(cmd);
        }

        public List<User> GetUsers(int fromRank, int toRank)
        {
            SqlCommand cmd = new SqlCommand("categories_selectbypriorityrank", DALHelper.getConnection());
            cmd.Parameters.AddWithValue("@from", fromRank);
            cmd.Parameters.AddWithValue("@to", toRank);
            return selectUsers(cmd);
        }

        public User GetUser(string id)
        {
            SqlCommand cmd = new SqlCommand("User_selectbyid", DALHelper.getConnection());
            cmd.Parameters.AddWithValue("@IdToSearch", id);
            //only one record will be found based on PK
            return selectUsers(cmd)[0];
        }

        public int Insert(User emp)
        {
            int cmd_success;
            SqlConnection con = DALHelper.getConnection();
            SqlCommand cmd = new SqlCommand("sp_insertUser", con);
            cmd.CommandType = CommandType.StoredProcedure;

            //Be EXTRA CAREFUL WHILE ENTERING PARAMETERS as Compiler doesn't pick it

           // cmd.Parameters.AddWithValue("@Name", DALHelper.getNullORValue(emp.Name));
            


            con.Open();
            using (con)
            {
                //Modified by Talha: Jan 26th, 2012 - Added Return variable to ensure data inserted successfully
                cmd_success = cmd.ExecuteNonQuery();
            }

            return cmd_success;
        }


        public void Update(User User)
        {
            SqlConnection con = DALHelper.getConnection();
            SqlCommand cmd = new SqlCommand("categories_update", con);

            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.AddWithValue("@IdToSearch", User.ID);
            //cmd.Parameters.AddWithValue("@name", User.Name);
            //cmd.Parameters.AddWithValue("@priorityrank", User.Father_Name);
            //cmd.Parameters.AddWithValue("@description", DALHelper.getNullORValue(User.Description));
            //cmd.Parameters.AddWithValue("@ImageUrl", DALHelper.getNullORValue(User.Class_Name));
            //cmd.Parameters.AddWithValue("@thumbnailUrl", DALHelper.getNullORValue(User.Section));

            con.Open();

            using (con)
            {
                int temp = cmd.ExecuteNonQuery();
            }
        }

        public void Delete(User User)
        {
            SqlConnection con = DALHelper.getConnection();
            SqlCommand cmd = new SqlCommand("categories_delete", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IdToSearch", User.ID);
            con.Open();
            using (con)
            {
                int temp = cmd.ExecuteNonQuery();
            }
        }

        private List<User> selectUsers(SqlCommand cmd)
        {
            cmd.CommandType = CommandType.StoredProcedure;
            SqlConnection con = cmd.Connection;
            List<User> Users = new List<User>();
            con.Open();
            using (con)
            {
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    Users = new List<User>();
                    while (dr.Read())
                    {

                        //Returned Columns Order

                        //ID
                        //Type (ID)
                        //Type (Desc)
                        //UserName
                        //Password
                        //Comments (about user)

                        UserType userType = new UserType
                        {
                            ID = Convert.ToInt32(dr[1]),
                            Description = Convert.ToString(dr[2])
                        };

                        User usr = new User
                        {
                            ID = Convert.ToInt32(dr[0]),
                            UserName = Convert.ToString(dr[3]),
                            PassWord = Convert.ToString(dr[4]),
                            Comments = Convert.ToString(dr[5])
                        };

                        usr.Type = userType;

                        Users.Add(usr);
                    }
                }
            }
            return Users;
        }

        private List<UserType> selectUserTypes(SqlCommand cmd)
        {
            cmd.CommandType = CommandType.StoredProcedure;
            SqlConnection con = cmd.Connection;
            List<UserType> UserTypes = new List<UserType>();
            con.Open();
            using (con)
            {
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    UserTypes = new List<UserType>();
                    while (dr.Read())
                    {
                        UserType role = new UserType
                        {
                            ID = Convert.ToInt32(dr[0]),
                            Description = Convert.ToString(dr[1])
                        };

                        UserTypes.Add(role);
                    }
                }
            }
            return UserTypes;
        }

    }
}
