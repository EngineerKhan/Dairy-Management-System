using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Entities
{
    public class User
    {
        int id;
        string userName;
        string passWord;
        UserType type;
        string comments;

        public int ID
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string UserName
        {
            get
            {
                return userName;
            }

            set
            {
                userName = value;
            }
        }

        public string PassWord
        {
            get
            {
                return passWord;
            }

            set
            {
                passWord = value;
            }
        }


        public string Comments
        {
            get
            {
                return comments;
            }

            set
            {
                comments = value;
            }
        }

        public UserType Type
        {
            get
            {
                return type;
            }

            set
            {
                type = value;
            }
        }

        public override string ToString()
        {
            return UserName;
        }
    }
}
