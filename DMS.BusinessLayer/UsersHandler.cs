using DMS.DataLayer;
using DMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.LogicLayer
{
    public class UsersHandler
    {

        public List<User> GetUsers()
        {
            return new UsersDAL().GetUsers();
        }

        public List<UserType> GetUserTypes()
        {
            return new UsersDAL().GetUserTypes();
        }

        public List<User> GetUsers(int fromRank, int toRank)
        {
            return new UsersDAL().GetUsers(fromRank, toRank);
        }

        public User GetUser(string id)
        {
            return new UsersDAL().GetUser(id);
        }

        public int AddUser(User User)
        {
            //Modified by Talha: Jan 26th, 2012 - Added Return variable to ensure data inserted successfully
            int cmd_success;
            cmd_success = new UsersDAL().Insert(User);
            return cmd_success;
        }


        public void UpdateUser(User User)
        {
            new UsersDAL().Update(User);
        }

        public void DeleteUser(User User)
        {
            new UsersDAL().Delete(User);
        }
    }
}
